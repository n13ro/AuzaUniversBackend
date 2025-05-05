using DataAccess;
using DataAccess.Entites;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Services.Stud;
using DataAccess.Repository.Stud;
namespace AppTests
{
    public class AppDbContextTest : IAsyncLifetime
    {
        private readonly DbContextOptions<AppDbContext> _dbContextOptions;
        private AppDbContext _dbContext;
        private StudentService _studentService;

        public AppDbContextTest()
        {
            //_dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
            //    .UseNpgsql<AppDbContext>("Host=localhost;Port=5432;Database=AuzaUniversDbTest;Username=postgres;Password=12345")
            //    .Options;
            _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestStudentDb_" + Guid.NewGuid().ToString()).Options;
        }

        public async Task InitializeAsync()
        {
            _dbContext = new AppDbContext(_dbContextOptions);
            await _dbContext.Database.EnsureCreatedAsync();
            _studentService = new StudentService(new StudentRepository(_dbContext));
        }

        public async Task DisposeAsync()
        {
            await _dbContext.Database.EnsureDeletedAsync();
            await _dbContext.DisposeAsync();
        }

        [Fact]
        public async Task TestStudentDatabaseIsCreated()
        {
            var newStud = new Student
            {
                Name = "gsgdfgdfg",
                Email = "dfgdfgdfg",
                FirstName = "fgdfgdfgdfg",
                LastName = "dfgdf;lsipo",
                Phone = "fdgdfgdf"
            };

            var createdUserId = await _studentService.AddStudentServiceAsync(newStud.Name, newStud.FirstName, newStud.LastName, newStud.Email, newStud.Phone, CancellationToken.None);
            var userInDb = await _dbContext.Students.FindAsync(createdUserId.Id);

            Assert.NotNull(userInDb);
            Assert.Equal(newStud.Name, userInDb.Name);
            Assert.Equal(newStud.Email, userInDb.Email);
            Assert.Equal(newStud.FirstName, userInDb.FirstName);
            Assert.Equal(newStud.LastName, userInDb.LastName);
        }
    }
}

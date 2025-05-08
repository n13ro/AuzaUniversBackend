//using BusinessLogic.Services.Stud;
//using DataAccess.Entites;
//using DataAccess.Repository.Stud;
//using Moq;
//using Xunit;

//namespace AppTests;

//public class TestStudentServiñe
//{
//    private readonly IStudentRepository _studentRepository;
//    private readonly IStudentService _studentService;

//    public TestStudentServiñe(IStudentRepository? studentRepository = null, IStudentService? studentService = null) 
//    {
//        _studentRepository = studentRepository ?? new Mock<IStudentRepository>().Object;
//        _studentService = studentService ?? new Mock<IStudentService>().Object; 
//    }
//    public async Task<IEnumerable<Student>> GetAllStudTest()
//    {
//        return await _studentRepository.GetAllStudentRepositoryAsync();
//    }
//    public async Task<Student> GetStudByIdAsyncTest(int id, CancellationToken cancellationToken)
//    {
//        return await _studentRepository.GetByIdStudentRepositoryAsync(id, cancellationToken);
//    }

//    public async Task<bool> AddStudenRepoTest(Student student)
//    {
//        await _studentRepository.AddStudentRepositoryAsync(student);
//        return true;
//    }
//    public async Task<bool> AddStudenServiceTest(string Name, string FirstName, string LastName, string Email, string Phone)
//    {
//        await _studentService.AddStudentServiceAsync(Name, FirstName, LastName, Email, Phone);
//        return true;
//    }

//    [Fact]
//    public async Task GetAllStudentsSuccessTest()
//    {
//        //arr
//        var repObj = new Mock<IStudentRepository>();
//        // Íàñòðîéòå çàãëóøêó äëÿ âîçâðàòà ñïèñêà ñ ýëåìåíòàìè
//        var students = new List<Student>
//        {
//            new Student 
//            { 
//                Email = "S@g", 
//                FirstName = "dan", 
//                Id = 1, 
//                LastName = "danon" 
//            },
//        };
//        repObj.Setup(obj => obj.GetAllStudentRepositoryAsync(It.IsAny<CancellationToken>()))
//              .ReturnsAsync(students);

//        var service = new TestStudentServiñe(repObj.Object);

//        //act
//        var result = await service.GetAllStudTest();

//        //assert
//        Assert.NotNull(result);
//        Assert.NotEmpty(result);
//    }

//    [Fact]
//    public async Task GetStudentByIdSuccessTest()
//    {
//        //arr
//        var repObj = new Mock<IStudentRepository>();
//        // Íàñòðîéòå çàãëóøêó äëÿ âîçâðàòà ñïèñêà ñ ýëåìåíòàìè
//        var oneStud = new Student 
//        { 
//            Id = 1, 
//            Name= "Danil", 
//            Email = "fsdfs", 
//            FirstName= "dfsf", 
//            LastName= "Danil" 
//        };

//        repObj.Setup(obj => obj.GetByIdStudentRepositoryAsync(1, It.IsAny<CancellationToken>()))
//            .ReturnsAsync(oneStud);

//        var service = new TestStudentServiñe(repObj.Object);

//        //act
//        var result = await service.GetStudByIdAsyncTest(1, CancellationToken.None);

//        //assert
//        Assert.Multiple(() =>
//        {
//            Assert.NotNull(result);
//            Assert.Equal(oneStud.Id, result.Id);
//            Assert.Equal(oneStud.Name, result.Name);
//            Assert.Equal(oneStud.FirstName, result.FirstName);
//        });

        
//    }
//    [Fact]
//    public async Task AddStudentSuccessTest()
//    {
//        //arr
//        var repObj = new Mock<IStudentRepository>();

//        var newStud = new Student
//        {
//            Id = 1,
//            Name = "Danil",
//            Email = "fsdfs",
//            FirstName = "dfsf",
//            LastName = "Danil"
//        };

//        repObj.Setup(o => o.AddStudentRepositoryAsync(newStud, It.IsAny<CancellationToken>()));
//        var service = new TestStudentServiñe(repObj.Object);

//        //act
//        var res = await service.AddStudenRepoTest(newStud);
//        //assert
//        Assert.True(res);
//        //Assert.False(res);
//    }
//    [Fact]
//    public async Task AddServiceTestSuccess()
//    {
//        var servObj = new Mock<IStudentService>();
//        var newStud = new
//        {
//            Id = 234,
//            Name = "gsgdfgdfg",
//            Email = "dfgdfgdfg",
//            FirstName = "fgdfgdfgdfg",
//            LastName = "dfgdf;lsipo",
//            Phone = "fdgdfgdf"
//        };
//        servObj.Setup(s => s.AddStudentServiceAsync(newStud.Name, newStud.Email, newStud.FirstName, newStud.LastName, newStud.Phone, It.IsAny<CancellationToken>()));
//        var testService = new TestStudentServiñe();

//        var res = await testService.AddStudenServiceTest(newStud.Name, newStud.Email, newStud.FirstName, newStud.LastName, newStud.Phone);

//        Assert.True(res);
//    }
//}


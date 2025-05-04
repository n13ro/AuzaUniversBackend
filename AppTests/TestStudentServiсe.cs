using BusinessLogic.Services.Stud;
using DataAccess.Entites;
using DataAccess.Repository.Stud;
using Moq;
using Xunit;

namespace AppTests;

public class TestStudentServiсe
{
    private readonly IStudentRepository _studentRepository;
    

    public TestStudentServiсe(IStudentRepository? studentRepository = null) 
    {
        _studentRepository = studentRepository ?? new Mock<IStudentRepository>().Object;
    }
    public async Task<IEnumerable<Student>> GetAllStudTest()
    {
        return await _studentRepository.GetAllStudentRepositoryAsync();
    }
    public async Task<Student> GetStudByIdAsyncTest(int id, CancellationToken cancellationToken)
    {
        return await _studentRepository.GetByIdStudentRepositoryAsync(id, cancellationToken);
    }

    public async Task<bool> AddStudentTest(Student student)
    {
        await _studentRepository.AddStudentRepositoryAsync(student);
        return true;
    }

    [Fact]
    public async Task GetAllStudentsSuccessTest()
    {
        //arr
        var repObj = new Mock<IStudentRepository>();
        // Настройте заглушку для возврата списка с элементами
        var students = new List<Student>
        {
            new Student 
            { 
                Email = "S@g", 
                FirstName = "dan", 
                Id = 1, 
                LastName = "danon" 
            },
        };
        repObj.Setup(obj => obj.GetAllStudentRepositoryAsync(It.IsAny<CancellationToken>()))
              .ReturnsAsync(students);

        var service = new TestStudentServiсe(repObj.Object);

        //act
        var result = await service.GetAllStudTest();

        //assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
    }

    [Fact]
    public async Task GetStudentByIdSuccessTest()
    {
        //arr
        var repObj = new Mock<IStudentRepository>();
        // Настройте заглушку для возврата списка с элементами
        var oneStud = new Student 
        { 
            Id = 1, 
            Name= "Danil", 
            Email = "fsdfs", 
            FirstName= "dfsf", 
            LastName= "Danil" 
        };

        repObj.Setup(obj => obj.GetByIdStudentRepositoryAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync(oneStud);

        var service = new TestStudentServiсe(repObj.Object);

        //act
        var result = await service.GetStudByIdAsyncTest(1, CancellationToken.None);

        //assert
        Assert.Multiple(() =>
        {
            Assert.NotNull(result);
            Assert.Equal(oneStud.Id, result.Id);
            Assert.Equal(oneStud.Name, result.Name);
            Assert.Equal(oneStud.FirstName, result.FirstName);
        });

        
    }
    [Fact]
    public async Task AddStudentSuccessTest()
    {
        //arr
        var repObj = new Mock<IStudentRepository>();

        var newStud = new Student
        {
            Id = 1,
            Name = "Danil",
            Email = "fsdfs",
            FirstName = "dfsf",
            LastName = "Danil"
        };

        repObj.Setup(o => o.AddStudentRepositoryAsync(newStud, It.IsAny<CancellationToken>()));
        var service = new TestStudentServiсe(repObj.Object);

        //act
        var res = await service.AddStudentTest(newStud);
        //assert
        Assert.True(res);
        //Assert.False(res);
    }
}


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
        return await _studentRepository.GetAllAsync();
    }
    public async Task<Student> GetStudByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _studentRepository.GetByIdAsync(id, cancellationToken);
    }

    [Fact]
    public async Task GetAllStudentsSuccessTest()
    {
        //arr
        var repObj = new Mock<IStudentRepository>();
        // Настройте заглушку для возврата списка с элементами
        var students = new List<Student>
        {
            new Student { Email = "S@g", FirstName = "dan", Id = 1, LastName = "danon" },
        };
        repObj.Setup(obj => obj.GetAllAsync(It.IsAny<CancellationToken>()))
              .ReturnsAsync(students);

        var service = new TestStudentServiсe(repObj.Object);

        //act
        var Result = await service.GetAllStudTest();

        //assert
        Assert.NotNull(Result);
        Assert.NotEmpty(Result);
    }

    [Fact]
    public async Task GetStudentByIdSuccessTest()
    {
        //arr
        var repObj = new Mock<IStudentRepository>();
        // Настройте заглушку для возврата списка с элементами
        var oneStud = new Student { Id = 1, Name= "Danil", Email = "fsdfs", FirstName= "dfsf", LastName= "Danil" };

        repObj.Setup(obj => obj.GetByIdAsync(1, It.IsAny<CancellationToken>()))
            .ReturnsAsync(oneStud);

        var service = new TestStudentServiсe(repObj.Object);

        //act
        var result = await service.GetStudByIdAsync(1, CancellationToken.None);

        //assert
        Assert.NotNull(result);
        Assert.Equal(oneStud.Id, result.Id);
        Assert.Equal(oneStud.Name, result.Name);
        Assert.Equal(oneStud.FirstName, result.FirstName);
        

    }

}


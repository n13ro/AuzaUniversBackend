using AutoFixture.AutoMoq;
using AutoFixture;
using DataAccess.DTOs.Stud;
using DataAccess.Entites;
using DataAccess.Repository.Stud;
using Moq;


namespace AppTests.TestRepository
{
    public class TestStudentRepository
    {
       
        private readonly IStudentRepository _studentRepository;

        public static Fixture _fixture = (Fixture)new Fixture().Customize(new AutoMoqCustomization());


        public TestStudentRepository(IStudentRepository? studentRepository = null)
        {
            _studentRepository = studentRepository;
        }


        [Fact]
        public async Task TestStudentGetAllIsNotNull()
        {
            //arr

            var allStud = _fixture.Build<DTOStudentRepository>().CreateMany(3).ToList();
            var mockRepo = _fixture.Freeze<Mock<IStudentRepository>>();

            mockRepo.Setup(o =>
                o.GetAllStudentRepositoryAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(allStud);
                

            
            var repository = new TestStudentRepository(mockRepo.Object);

            //act
            var res = await repository._studentRepository.GetAllStudentRepositoryAsync();

            //assert
            Assert.NotNull(res);
            Assert.NotEmpty(res);
            Assert.Equal(3, res.Count());

            mockRepo.Verify(o => 
                o.GetAllStudentRepositoryAsync(It.IsAny<CancellationToken>()),Times.Once);

        }


        [Fact]
        public async Task TestStudentGetByIdIsNotNull()
        {
            //arr
            const int testId = 1;
            var oneStudent = _fixture.Build<Student>().With(s => s.Id, testId).Without(s => s.MyPair).Create();
            var mockRepo = _fixture.Freeze<Mock<IStudentRepository>>();

            mockRepo.Setup(o =>
                o.GetByIdStudentRepositoryAsync(1, It.IsAny<CancellationToken>()))
                .ReturnsAsync(oneStudent);

            var repository = new TestStudentRepository(mockRepo.Object);

            //act
            var res = await repository._studentRepository.GetByIdStudentRepositoryAsync(testId, CancellationToken.None);

            //assert
            Assert.NotNull(res);
            Assert.Equal(testId, res.Id);


            mockRepo.Verify(o =>
                o.GetByIdStudentRepositoryAsync(testId, It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task TestAddStudentRepositoryIsSuccess()
        {
            // Arr
            var mockRepo = _fixture.Freeze<Mock<IStudentRepository>>();
            var newStud = _fixture.Create<DTOCreateStudentRepository>();

            mockRepo.Setup(o => o.AddStudentRepositoryAsync(newStud,It.IsAny<CancellationToken>()));

            var repository = new TestStudentRepository(mockRepo.Object);

            // Act
            await repository._studentRepository.AddStudentRepositoryAsync(newStud, CancellationToken.None);

            // Assert
            mockRepo.Verify(o => o.AddStudentRepositoryAsync(
                newStud,
                It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Fact]
        public async Task TestUpdateStudentRepositoryIsSuccess()
        {
            var mockRepo = _fixture.Freeze<Mock<IStudentRepository>>();
            var updateStudentDto = new DTOUpdateStudentRepository
            {
                Id = 1,
                Name = "Updated Name",
                FirstName = "Updated FirstName",
                LastName = "Updated LastName",
                Email = "updated@email.com",
                Phone = "0987654321"
            };

            var repository = new TestStudentRepository(mockRepo.Object);

            await repository._studentRepository.UpdateStudentRepositoryAsync(updateStudentDto, CancellationToken.None);

            mockRepo.Verify(o => o.UpdateStudentRepositoryAsync(
                It.Is<DTOUpdateStudentRepository>(s =>
                    s.Id == updateStudentDto.Id &&
                    s.Name == updateStudentDto.Name &&
                    s.FirstName == updateStudentDto.FirstName &&
                    s.LastName == updateStudentDto.LastName &&
                    s.Email == updateStudentDto.Email &&
                    s.Phone == updateStudentDto.Phone),
                It.IsAny<CancellationToken>()),
                Times.Once);
        }

        [Fact]
        public async Task TestDeleteStudentRepositoryIsSuccess()
        {
            var mockRepo = _fixture.Freeze<Mock<IStudentRepository>>();
            var newStudent = _fixture.Create<DTOCreateStudentRepository>();

            mockRepo.Setup(o => o.DeleteStudentRepositoryAsync(newStudent.Id, It.IsAny<CancellationToken>()));

            var repository = new TestStudentRepository(mockRepo.Object);

            await repository._studentRepository.DeleteStudentRepositoryAsync(newStudent.Id, CancellationToken.None);

            mockRepo.Verify(o => o.DeleteStudentRepositoryAsync(
                newStudent.Id,
                It.IsAny<CancellationToken>()),
                Times.Once
                );
        }
    }
}

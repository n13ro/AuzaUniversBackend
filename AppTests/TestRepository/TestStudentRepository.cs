using AutoFixture.AutoMoq;
using AutoFixture;
using AutoFixture.Xunit2;
using DataAccess;
using DataAccess.DTOs.Stud;
using DataAccess.Entites;
using DataAccess.Repository.Stud;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Concurrent;
using static System.Collections.Specialized.BitVector32;

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

            var allStud = _fixture.Build<Student>().Without(s => s.MyPair).CreateMany(3).ToList();
            var mockRepo = _fixture.Freeze<Mock<IStudentRepository>>();

            mockRepo.Setup(o =>
                o.GetAllStudentRepositoryAsync(It.IsAny<CancellationToken>())).ReturnsAsync(allStud);
                

            
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
    }
}

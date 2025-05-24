using AutoFixture;
using AutoFixture.AutoMoq;
using DataAccess.DTOs.Ment;
using DataAccess.DTOs.Stud;
using DataAccess.Entites;
using DataAccess.Repository.Ment;
using Moq;


namespace AppTests.TestRepository
{
    public class TestMentorRepository
    {
        private readonly IMentorRepository _repositoryMentor;

        public static Fixture _fixture = (Fixture)new Fixture().Customize(new AutoMoqCustomization());

        public TestMentorRepository(IMentorRepository? repositoryMentor = null)
        {
            _repositoryMentor = repositoryMentor;
        }

        [Fact]
        public async Task TestMentorGetAllIsNotNull()
        {
            var allMent = _fixture.Build<DTOMentorRepository>().CreateMany(5).ToList();
            var mockRepo = _fixture.Freeze<Mock<IMentorRepository>>();

            mockRepo.Setup(o => o.GetAllMentorRepositoryAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(allMent);

            var repository = new TestMentorRepository(mockRepo.Object);

            var res = await repository._repositoryMentor.GetAllMentorRepositoryAsync();

            Assert.Multiple(() =>
            {
                Assert.NotNull(res);
                Assert.NotEmpty(res);
                Assert.Equal(5, res.Count());
            });
            mockRepo.Verify(o =>
                o.GetAllMentorRepositoryAsync(It.IsAny<CancellationToken>()), Times.Once);

        }
    }
}

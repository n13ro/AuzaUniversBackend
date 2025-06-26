
using Castle.Core.Logging;
using Moq.AutoMock;


namespace AppTests.TestService
{
    public interface ITokenProvider
    {
        string GetToken();
    } 

    class TestService
    {
        private readonly ITokenProvider _tokenProvider;
        public TestService(ITokenProvider tokenProvide)
        {
            _tokenProvider = tokenProvide;
        }

        public string GetToken()
        {
            return _tokenProvider.GetToken();

        }

    }
    public class Test
    {

        [Fact]
        public void DoSomethingWithToken_ReturnsExpectedToken()
        {
            // Arrange
            var personalToken = "my-personal-token";
            var mocker = new AutoMocker();


            // Настраиваем мок для ITokenProvider
            mocker.GetMock<ITokenProvider>()
                  .Setup(x => x.GetToken())
                  .Returns(personalToken);

            // Автоматически создаем сервис с внедренным мок-объектом
            var mockServ = mocker.CreateInstance<TestService>();


            // Act
            var result = mockServ.GetToken();


            // Assert
            Assert.Equal(personalToken, result);
        }
    }
}

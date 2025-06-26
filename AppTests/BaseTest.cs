
using AppTests.Inteface;
using Moq.AutoMock;
using Newtonsoft.Json.Linq;

namespace AppTests
{

    public abstract class BaseTest
    {
        protected readonly AutoMocker Mocker;
        protected readonly string Token;
        protected string CustomToken {  get; private set; }
        protected BaseTest()
        {
            Mocker = new AutoMocker();
            Token = "user-token-456";
            SetupDefaultMocks();
        }

        protected virtual void SetupDefaultMocks()
        {
            SetupToken();
        }

        protected void SetupToken()
        {
            Mocker.GetMock<ITokenProvider>()
                  .Setup(x => x.GetToken())
                  .Returns(Token);
        }

        protected void SetupCustomToken(string customToken)
        {
            CustomToken = customToken;
            Mocker.GetMock<ITokenProvider>()
                  .Setup(x => x.GetToken())
                  .Returns(customToken);
        }

        protected T CreateService<T>() where T : class
        {
            return Mocker.CreateInstance<T>();
        }

        protected void VerifyAll()
        {
            Mocker.VerifyAll();
        }
    }
}

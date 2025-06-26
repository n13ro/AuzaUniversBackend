
using AppTests.Inteface;
using Moq.AutoMock;
using Newtonsoft.Json.Linq;

namespace AppTests
{

    public abstract class BaseTest
    {
        protected readonly AutoMocker Mocker;
        protected readonly string Token;
        protected BaseTest()
        {
            Mocker = new AutoMocker();
            Token = "user-token-456";
            SetupDefaultMocks();
        }

        protected virtual void SetupDefaultMocks()
        {
            SetupTokenProvider();
        }

        protected void SetupToken()
        {
            Mocker.GetMock<ITokenProvider>()
                  .Setup(x => x.GetToken())
                  .Returns(Token);
        }
        protected virtual void SetupTokenProvider()
        {
            Mocker.GetMock<ITokenProvider>()
                .Setup(s => s.GetToken())
                .Returns(Token);
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



using AppTests.Inteface;

namespace AppTests.TestService
{
    public class TestMyService
    {
        private readonly ITokenProvider _tokenProvider;

        public TestMyService(ITokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        public string GetToken()
        {
            return _tokenProvider.GetToken();
        }
    }
    public class TestService : BaseTest
    {

        [Fact]
        public void TestOne()
        {
            SetupTokenProvider();
            var sut = CreateService<TestMyService>();

            var res = sut.GetToken();

            Assert.NotNull(res);
            Assert.Equal("user-token-456", res);
            VerifyAll();
        }
    }
}

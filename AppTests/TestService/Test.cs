

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
            SetupToken();
            var sut = CreateService<TestMyService>();
            var res = sut.GetToken();

            Assert.NotNull(res);
            Assert.Equal("user-token-456", res);
            VerifyAll();
        }

        [Fact]
        public void TestTwo()
        {
            SetupCustomToken("tok");
            var sut = CreateService<TestMyService>();
            var res = sut.GetToken();

            Assert.NotNull(res);
            Assert.Equal("tok", res);
            VerifyAll();
        }
    }
}

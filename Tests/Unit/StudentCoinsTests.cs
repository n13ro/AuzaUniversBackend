using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Unit
{
    public class StudentCoinsTests
    {
        [Fact]
        public void AddCoin_EqualCoin()
        {
            var student = new Student("Test", "T", "S", "test@mail.com", "123");
            student.AddCoin(10);
            Assert.Equal(10, student.CoinBalnce);
        }

    }
}

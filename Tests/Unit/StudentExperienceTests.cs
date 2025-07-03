using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Unit
{
    public class StudentExperienceTests
    {
        [Fact]
        public void AddXP_IncrXP()
        {
            var student = new Student("Test", "T", "S", "test@mail.com", "123", 1);
            student.AddXP(100);
            Assert.Equal(100, student.XP);
        }

        [Fact]
        public void AddXP_LevelUp1()
        {
            var student = new Student("Test", "T", "S", "test@mail.com", "123", 1);
            student.AddXP(1200);
            Assert.Equal(200, student.XP);
            Assert.Equal(2, student.Level);
            student.AddXP(800);
            Assert.Equal(3, student.Level);
        }

        [Fact]
        public void AddXP_LevelUP2()
        {
            var student = new Student("Test", "T", "S", "test@mail.com", "123", 1);
            student.AddXP(999);
            Assert.Equal(1, student.Level);
            student.AddXP(1);
            Assert.Equal(2, student.Level);

        }

    }
}

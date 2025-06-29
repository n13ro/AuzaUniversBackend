using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Coin : BaseEntity
    {
        public decimal Amount { get; private set; }

        private readonly List<Student> _students = new();

        public IReadOnlyCollection<Student> Students => _students.AsReadOnly();

        private Coin() { }

        public Coin(decimal amount)
        {
            Amount = amount;
        }

        public void AssignToStudent(Student student)
        {

            _students.Add(student);
            SetUpdate();
        }

        public void RemoveFromStudent(Student student)
        {

            if (_students.Remove(student))
            {
                SetUpdate();
            }
        }

        public void UpdateAmount(decimal newAmount)
        {
            Amount = newAmount;
            SetUpdate();

        }
    }
}

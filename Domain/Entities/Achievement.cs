using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Achievement : BaseEntity
    {
        public string Name {  get; private set; }
        public string Description { get; private set; }
        [Range(1, 1000)]
        public int XPAchiev { get; private set; }

        private readonly List<Student> _students = new();

        public ICollection<Student> Students => _students;

        private Achievement() { }

        public Achievement(string name, string description, int xPAchiev)
        {
            Name = name;
            Description = description;
            XPAchiev = xPAchiev;
            SetUpdate();
        }

        public void AssignToStudent(Student student)
        {
            _students.Add(student);
            student.AddXP(XPAchiev);
            SetUpdate();
        }

    }
}

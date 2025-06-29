using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class    Group : BaseEntity
    {
        public string Name { get; private set; }
        private List<Student> _students { get; set; } = new();
        private List<Mentor> _mentors { get; set; } = new();

        public IReadOnlyCollection<Student> Students => _students.AsReadOnly();
        public IReadOnlyCollection<Mentor> Mentors => _mentors.AsReadOnly();

        private Group() { }

        public Group(string name)
        {
            if(string.IsNullOrEmpty(name)) throw new ArgumentNullException("name null");

            Name = name;
        }

        public void AddStudent(Student student)
        {
            if (student == null) throw new ArgumentNullException("student null");

            _students.Add(student);
            student.EnrollInGroup(this);
            SetUpdate();
        }

        public void RemoveStudent(Student student)
        {
            if (student == null) throw new ArgumentNullException("student null");

            if (_students.Remove(student))
            {
                SetUpdate();
            }
        }

        public void AddMentor(Mentor mentor)
        {
            _mentors.Add(mentor);
            SetUpdate();

        }

        public void RemoveMentor(Mentor mentor)
        {
            if (_mentors.Remove(mentor))
            {
                mentor.RemoveFromGroup(this);
                SetUpdate();
            }
        }

        public void UpdateName(string name)
        {
            Name = name;
            SetUpdate();
        }

    }
}

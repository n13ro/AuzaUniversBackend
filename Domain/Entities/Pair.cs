using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Pair : BaseEntity
    {
        public string Name { get; private set; }
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public int Auditorium { get; private set; }

        public int GroupId { get; set; }
        public Group? Group { get; set; }

        private readonly List<Mentor> _mentors = new();

        public IReadOnlyCollection<Mentor> Mentors => _mentors.AsReadOnly();

        private Pair() { }

        public Pair(string name, DateTime startTime, DateTime endTime, int auditorium)
        {
            Name = name;
            StartTime = startTime;
            EndTime = endTime;
            Auditorium = auditorium;
        }

        public void Start()
        {

        }

        public void Cancel()
        {

        }
        public void Complete()
        {

        }
        
        //public void AddStudent(Student student)
        //{
        //    _students.Add(student);
        //    SetUpdate();
        //}
        //public void RemoveStudent(Student student)
        //{
        //    if (_students.Remove(student))
        //    {
        //        SetUpdate();
        //    }
        //}
        public void EnrollGroup(Group group)
        {
            GroupId = group.Id;
            Group = group;
            SetUpdate();
        }

        public void AddMentor(Mentor mentor)
        {
            _mentors.Add(mentor);
            mentor.AssignToPair(this);
            SetUpdate();
        }
        public void RemoveMentor(Mentor mentor)
        {
            if (_mentors.Remove(mentor))
            {
                mentor.RemoveFromPair(this);
                SetUpdate();
            }
        }

        public void Reschedule(DateTime newStartTime, DateTime newEndTime)
        {
            StartTime = newStartTime;
            EndTime = newEndTime;
            SetUpdate();
        }
        public void ChangeAuditorium(int newAuditorium)
        {
            Auditorium = newAuditorium;
            SetUpdate();
        }
    }
}

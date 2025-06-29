using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Mentor : BaseEntity
    {
        public string Name { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }

        private readonly List<Group> _groups = new();
        private readonly List<Pair> _myPairs  = new();

        public IReadOnlyCollection<Group> Groups => _groups.AsReadOnly();
        public IReadOnlyCollection<Pair> MyPairs => _myPairs.AsReadOnly();

        private Mentor() { }

        public Mentor(string name, string firstName, string lastName, string email, string phone)
        {
            Name = name;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
        }

        public void AssignToGroup(Group group)
        {
            if (!_groups.Contains(group))
            {
                _groups.Add(group);
                SetUpdate();
            }
        }

        public void RemoveFromGroup(Group group)
        {
            if (_groups.Remove(group))
            {
                SetUpdate();
            }
        }

        public void AssignToPair(Pair pair)
        {
            _myPairs.Add(pair);
            SetUpdate();
        }

        public void RemoveFromPair(Pair pair)
        {
            if(_myPairs.Remove(pair))
            {
                pair.RemoveMentor(this);
                SetUpdate();
            }
        }
    }
}

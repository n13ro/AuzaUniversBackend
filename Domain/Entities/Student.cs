using Domain.Common;
using System.ComponentModel.DataAnnotations;


namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        public string Name { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        [Range(1, 100)]
        public int Level { get; set; } = 1;

        //private readonly List<Pair> _myPairs = new();
        private readonly List<Coin> _coins = new();

        //public IReadOnlyCollection<Pair>? MyPairs => _myPairs.AsReadOnly();
        public IReadOnlyCollection<Coin>? Coins => _coins.AsReadOnly();

        public int MyGroupId { get; set; }
        public Group? MyGroup { get; set; }

        private Student() { }

        public Student(string name, string firstName, string lastName, string email, string phone, int level)
        {
            Name = name;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Level = level;
        }
        public void EnrollInGroup(Group group)
        {
            //if(group == null) throw new ArgumentNullException("group null");

            MyGroup = group;
            MyGroupId = group.Id;
            SetUpdate();
        }

        public void AddCoin(Coin coin)
        {
            //if (coin == null) throw new ArgumentNullException("coin null");

            _coins.Add(coin);
            SetUpdate();
        }

        public void LevelUp()
        {
            //
            SetUpdate();
        }
    }
}

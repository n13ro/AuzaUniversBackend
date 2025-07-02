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
        public int Level { get; private set; }
        [Range(1, 1000)]
        public int XP { get; private set; }

        private readonly List<Coin> _coins = new();
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
            if(group == null) throw new ArgumentNullException("group null");

            MyGroup = group;
            MyGroupId = group.Id;
            SetUpdate();
        }

        public void AddCoin(Coin coin)
        {
            if (coin == null) throw new ArgumentNullException("coin null");

            _coins.Add(coin);
            SetUpdate();
        }
        
        public void AddXP(int amount)
        {
            XP += amount;
            while (XP >= 1000)
            {
                XP -= 1000;
                LevelUp();
            }
            SetUpdate();
        }

        public void LevelUp()
        {
            Level += 1;
            SetUpdate();
        }
    }
}

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
            ValidateStudentData(name, firstName, lastName, email, phone, level);
            Name = name;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Level = level;
            XP = 0;
            SetUpdate();
        }

        private void ValidateStudentData(string name, string firstName, string lastName, string email, string phone, int level)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ValidationException("Name cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ValidationException("FirstName cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ValidationException("LastName cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
            {
                throw new ValidationException("Email cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ValidationException("Phone cannot be empty");
            }
            if (level < 1 || level > 100 )
            {
                throw new ValidationException("Level between 1 and 100");
            }
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

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
        [Range(1, int.MaxValue)]
        public int CoinBalnce { get; private set; }

        //private readonly List<Coin> _coins = new();
        private readonly List<Achievement> _achievements = new();
        //public ICollection<Coin>? Coins => _coins;
        public ICollection<Achievement>? Achievement => _achievements;

        public int MyGroupId { get; set; }
        public Group? MyGroup { get; set; }
        
        private Student() { }

        public Student(string name, string firstName, string lastName, string email, string phone)
        {
            ValidateStudentData(name, firstName, lastName, email, phone);
            Name = name;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            SetUpdate();
        }

        private void ValidateStudentData(string name, string firstName, string lastName, string email, string phone)
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
            if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
            {
                throw new ValidationException("Email cannot be empty");
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ValidationException("Phone cannot be empty");
            }
        }

        public void EnrollInGroup(Group group)
        {
            if(group == null) throw new ArgumentNullException("group null");

            MyGroup = group;
            MyGroupId = group.Id;
            SetUpdate();
        }

        public void AddCoin(int amount)
        {
            if (amount == null) throw new ArgumentNullException("amount null");

            CoinBalnce += amount;
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

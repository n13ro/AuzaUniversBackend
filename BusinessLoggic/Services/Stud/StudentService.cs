using DataAccess.Entites;
using DataAccess.Repository.Stud;


namespace BusinessLogic.Services.Stud
{
    internal class StudentService(IStudentRepository studentRepository) : IStudentService
    {
        public async Task AddAsync(string Name, string FirstName, string LastName, string Email, string Phone, CancellationToken cancellationToken = default)
        {
            var newStudent = new Student
            {
                Name = Name,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Phone = Phone,
            };

            await studentRepository.AddAsync(newStudent, cancellationToken);
        }
    }
}

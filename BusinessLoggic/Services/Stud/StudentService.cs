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

        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            await studentRepository.DeleteAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var students = await studentRepository.GetAllAsync(cancellationToken);
            return students;
        }

        public async Task GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            await studentRepository.GetByIdAsync(id, cancellationToken);
        }

        public Task UpdateAsync(Student student, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

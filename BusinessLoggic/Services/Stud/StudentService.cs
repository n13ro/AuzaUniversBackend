using DataAccess.Entites;
using DataAccess.Repository.Stud;

namespace BusinessLogic.Services.Stud
{
    public class StudentService(IStudentRepository studentRepository) : IStudentService
    {
        public async Task<Student> AddStudentServiceAsync(string Name, string FirstName, string LastName, string Email, string Phone, CancellationToken cancellationToken = default)
        {
            var newStudent = new Student
            {
                Name = Name,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Phone = Phone,
            };

            await studentRepository.AddStudentRepositoryAsync(newStudent, cancellationToken);
            return newStudent;
        }

        public async Task DeleteStudentServiceAsync(int id, CancellationToken cancellationToken = default)
        {
            await studentRepository.DeleteStudentRepositoryAsync(id, cancellationToken);
        }

        public async Task<IEnumerable<Student>> GetAllStudentServiceAsync(CancellationToken cancellationToken = default)
        {
            var students = await studentRepository.GetAllStudentRepositoryAsync(cancellationToken);
            return students;
        }

        public async Task GetByIdStudentServiceAsync(int id, CancellationToken cancellationToken = default)
        {
            await studentRepository.GetByIdStudentRepositoryAsync(id, cancellationToken);
        }

        public Task UpdateStudentServiceAsync(Student student, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}

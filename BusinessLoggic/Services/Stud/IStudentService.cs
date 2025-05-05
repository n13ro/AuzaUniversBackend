using DataAccess.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Stud
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentServiceAsync(CancellationToken cancellationToken = default);
        Task GetByIdStudentServiceAsync(int id,CancellationToken cancellationToken = default);

        //Task AddStudentServiceAsync(string Name, string FirstName, string LastName, string Email, string Phone, CancellationToken cancellationToken = default);
        Task<Student> AddStudentServiceAsync(string Name,string FirstName, string LastName, string Email,string Phone, CancellationToken cancellationToken = default);

        Task UpdateStudentServiceAsync(Student student, CancellationToken cancellationToken = default);

        Task DeleteStudentServiceAsync(int id, CancellationToken cancellationToken = default);
    }
}

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
        Task<IEnumerable<Student>> GetAllAsync(CancellationToken cancellationToken = default);
        Task GetByIdAsync(int id,CancellationToken cancellationToken = default);
        Task AddAsync(string Name,string FirstName, string LastName, string Email,string Phone, CancellationToken cancellationToken = default);

        Task UpdateAsync(Student student, CancellationToken cancellationToken = default);

        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Stud
{
    public interface IStudentService
    {
        Task AddAsync(string Name,string FirstName, string LastName, string Email,string Phone, CancellationToken cancellationToken = default);
    }
}

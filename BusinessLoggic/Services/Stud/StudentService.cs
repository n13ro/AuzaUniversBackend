using BusinessLogic.DTOs.Stud;
using DataAccess.DTOs.Stud;
using DataAccess.Entites;
using DataAccess.Repository.Stud;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic;

namespace BusinessLogic.Services.Stud
{
    public class StudentService(IStudentRepository studentRepository) : IStudentService
    {
        public async Task AddStudentServiceAsync(DTOCreateStudentService newStudentDto, CancellationToken cancellationToken = default)
        {
            try 
            {
                if (newStudentDto == null)
                {
                    throw new Exception("Error args student");
                }
                var newStudent = new DTOCreateStudentRepository
                {
                    Name = newStudentDto.Name,
                    FirstName = newStudentDto.FirstName,
                    LastName = newStudentDto.LastName,
                    Email = newStudentDto.Email,
                    Phone = newStudentDto.Phone,
                };

                await studentRepository.AddStudentRepositoryAsync(newStudent, cancellationToken);

            }
            catch(Exception ex) 
            {
                throw new Exception($"Error add stud service {ex.Message}");
            }
            
        }

        public async Task DeleteStudentServiceAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                await studentRepository.DeleteStudentRepositoryAsync(id, cancellationToken);
            }
            catch (Exception ex) 
            {
                throw new Exception($"Err del stud service {ex.Message}");
            }

        }

        public async Task<IEnumerable<DTOStudentRepository>> GetAllStudentServiceAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var allStud = await studentRepository.GetAllStudentRepositoryAsync(cancellationToken);
                return allStud;
            }
            catch (Exception ex) 
            {
                throw new Exception($"Err getAll stud service {ex.Message}");
            }
            
        }

        public async Task<Student> GetByIdStudentServiceAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await studentRepository.GetByIdStudentRepositoryAsync(id, cancellationToken); ;
            } 
            catch (Exception ex)
            {
                throw new Exception($"Err getById stud service {ex.Message}");
            }
        }

        public async Task<IEnumerable<Student>> GetByPagePaginationServiceAsync(int page, int size, CancellationToken cancellationToken = default)
        {
            try
            {
                return await studentRepository.GetByPagePaginationRepositoryAsync(page, size, cancellationToken);
            }
            catch(Exception ex)
            {
                throw new Exception($"Err getByIdPagination stud service {ex.Message}");
            }
        }

        public async Task UpdateStudentServiceAsync(DTOUpdateStudentService newUpdatetDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var newUpdate = new DTOUpdateStudentRepository
                {
                    Id = newUpdatetDto.Id,
                    Name = newUpdatetDto.Name,
                    FirstName = newUpdatetDto.FirstName,
                    LastName = newUpdatetDto.LastName,
                    Email = newUpdatetDto.Email,
                    Phone = newUpdatetDto.Phone,
                };

                await studentRepository.UpdateStudentRepositoryAsync(newUpdate, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Err update stud service {ex.Message}");
            }
        }
    }
}

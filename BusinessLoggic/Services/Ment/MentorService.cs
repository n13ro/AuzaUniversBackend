using BusinessLogic.DTOs.Ment;
using DataAccess.DTOs.Ment;
using DataAccess.Entites;
using DataAccess.Repository.Ment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Ment
{
    internal class MentorService(IMentorRepository mentorRepository) : IMentorService
    {
        public async Task AddMentorServiceAsync(DTOCreateMentorService newMentorDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var newMentor = new DTOCreateMentorRepository 
                {
                    Name = newMentorDto.Name,
                    FirstName = newMentorDto.FirstName,
                    LastName = newMentorDto.LastName,
                    Email = newMentorDto.Email,
                    Phone = newMentorDto.Phone,
                };
                await mentorRepository.AddMentorRepositoryAsync(newMentor, cancellationToken);

            }
            catch (Exception ex)
            {
                throw new Exception($"Error add ment service {ex.Message}");
            }
        }

        public async Task DeleteMentorServiceAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                await mentorRepository.DeleteMentorRepositoryAsync(id, cancellationToken);

            }
            catch (Exception ex)
            {
                throw new Exception($"Error del ment service {ex.Message}");
            }
        }

        public async Task<IEnumerable<Mentor>> GetAllMentorServiceAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await mentorRepository.GetAllMentorRepositoryAsync(cancellationToken);

            }
            catch (Exception ex)
            {
                throw new Exception($"Error getAll ment service {ex.Message}");
            }
        }

        public async Task<Mentor> GetByIdMentorServiceAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await mentorRepository.GetByIdMentorRepositoryAsync(id, cancellationToken);
            }
            catch(Exception ex)
            {
                throw new Exception($"Error getById ment service {ex.Message}");
            }
        }

        public async Task<IEnumerable<Mentor>> GetByPagePaginationServiceAsync(int page, int size, CancellationToken cancellationToken = default)
        {
            try
            {
                return await mentorRepository.GetByPagePaginationRepositoryAsync(page, size, cancellationToken);

            }
            catch(Exception ex)
            {
                throw new Exception($"Err getByIdPagination ment service {ex.Message}");

            }
        }

        public async Task UpdateMentorServiceAsync(DTOUpdateMentorService newMentorDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var newMentor = new DTOUpdateMentorRepository
                {
                    Name = newMentorDto.Name,
                    FirstName = newMentorDto.FirstName,
                    LastName = newMentorDto.LastName,
                    Email = newMentorDto.Email,
                    Phone = newMentorDto.Phone,
                };
                await mentorRepository.UpdateMentorRepositoryAsync(newMentor, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error update ment service {ex.Message}");
            }

        }

    }
}

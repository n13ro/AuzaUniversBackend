using BusinessLogic.DTOs.DTOPair;
using DataAccess.DTOs.DTOPair;
using DataAccess.Entites;
using DataAccess.Repository.PairRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BusinessLogic.Services.PairService
{
    internal class PairService(IPairRepository pairRepository) : IPairService
    {
        public async Task AddPairServiceAsync(DTOCreatePairService newPairDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var newPair = new DTOCreatePairRepository 
                {
                    Name = newPairDto.Name,
                    DateTime = newPairDto.DateTime,
                    Auditorium = newPairDto.Auditorium,
                };
                await pairRepository.AddPairRepositoryAsync(newPair, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Err add pair service {ex.Message}");
            }
            
        }

        public async Task AssignPairToStudentServiceAsync(int studentId, int pairId, CancellationToken cancellationToken = default)
        {
            try
            {
                await pairRepository.AssignPairToStudentRepositoryAsync(studentId, pairId, cancellationToken);
            }
            catch(Exception ex)
            {
                throw new Exception($"Err add pair service {ex.Message}");
            }
        }

        public async Task DeletePairServiceAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                await pairRepository.DeletePairRepositoryAsync(id, cancellationToken);

            }
            catch (Exception ex)
            {
                throw new Exception($"Err del pair service {ex.Message}");
            }
        }

        public async Task<IEnumerable<Pair>> GetAllPairServiceAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return await pairRepository.GetAllPairRepositoryAsync(cancellationToken);

            }
            catch(Exception ex)
            {
                throw new Exception($"Err getAll pair service {ex.Message}");
            }
        }

        public async Task<Pair> GetByIdPairServiceAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                return await pairRepository.GetByIdPairRepositoryAsync(id, cancellationToken);

            }
            catch(Exception ex)
            {
                throw new Exception($"Err getById pair service {ex.Message}");
            }
        }

        public async Task<IEnumerable<Pair>> GetByPagePaginationServiceAsync(int page, int size, CancellationToken cancellationToken = default)
        {
            return await pairRepository.GetByPagePaginationRepositoryAsync(page, size, cancellationToken);
        }

        public async Task UpdatePairServiceAsync(DTOUpdatePairService newUpdateDto, CancellationToken cancellationToken = default)
        {
            try
            {
                var newPair = new DTOUpdatePairRepository
                {
                    Name = newUpdateDto.Name,
                    DateTime = newUpdateDto.DateTime,
                    Auditorium = newUpdateDto.Auditorium,
                };
                await pairRepository.UpdatePairRepositoryAsync(newPair, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Err update pair service {ex.Message}");
            }
        }
    }
}

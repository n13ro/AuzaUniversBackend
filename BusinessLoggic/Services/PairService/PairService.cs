using BusinessLogic.DTOs.DTOPair;
using BusinessLogic.Services.Stud;
using DataAccess.DTOs.DTOPair;
using DataAccess.Entites;
using DataAccess.Repository.PairRepo;
using DataAccess.Repository.Stud;

using System.Text.Json;


namespace BusinessLogic.Services.PairService
{
    public class PairService : IPairService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IPairRepository _pairRepository;


        public PairService(IStudentRepository studentRepository, IPairRepository pairRepository)
        {
            _studentRepository = studentRepository;
            _pairRepository = pairRepository;
        }

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
                await _pairRepository.AddPairRepositoryAsync(newPair, cancellationToken);
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
                await _pairRepository.AssignPairToStudentRepositoryAsync(studentId, pairId, cancellationToken);

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
                await _pairRepository.DeletePairRepositoryAsync(id, cancellationToken);

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
                return await _pairRepository.GetAllPairRepositoryAsync(cancellationToken);

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
                return await _pairRepository.GetByIdPairRepositoryAsync(id, cancellationToken);

            }
            catch(Exception ex)
            {
                throw new Exception($"Err getById pair service {ex.Message}");
            }
        }

        public async Task<IEnumerable<Pair>> GetByPagePaginationServiceAsync(int page, int size, CancellationToken cancellationToken = default)
        {
            return await _pairRepository.GetByPagePaginationRepositoryAsync(page, size, cancellationToken);
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
                await _pairRepository.UpdatePairRepositoryAsync(newPair, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Err update pair service {ex.Message}");
            }
        }
    }
}

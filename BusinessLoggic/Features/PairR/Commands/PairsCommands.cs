using BusinessLogic.DTOs.DTOPair;
using DataAccess.DTOs.DTOPair;
using DataAccess.Repository.PairRepo;
using MediatR;

namespace BusinessLogic.Features.PairR.Commands
{
    public record AddPairCommand(DTOCreatePairService Pair) : IRequest;
    public class AddPairHandler : IRequestHandler<AddPairCommand>
    {   
        private readonly IPairRepository _pairRepository;

        public AddPairHandler(IPairRepository pairRepository)
        {
            _pairRepository = pairRepository;
        }

        public async Task Handle(AddPairCommand request, CancellationToken cancellationToken)
        {
            var newPair = new DTOCreatePairRepository
            {
                Name = request.Pair.Name,
                DateTime = request.Pair.DateTime,
                Auditorium = request.Pair.Auditorium,
            };
            await _pairRepository.AddPairRepositoryAsync(newPair, cancellationToken);
        }
    }
}
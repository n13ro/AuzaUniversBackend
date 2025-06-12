using DataAccess.DTOs.Ment;
using DataAccess.Entites;
using DataAccess.Repository.Ment;
using MediatR;

public record GetAllMentorsQuery : IRequest<IEnumerable<DTOMentorRepository>>;

public class GetAllMentorsQueryHandler : IRequestHandler<GetAllMentorsQuery, IEnumerable<DTOMentorRepository>>
{
    private readonly IMentorRepository _mentorRepository;

    public GetAllMentorsQueryHandler(IMentorRepository mentorRepository)
    {
        _mentorRepository = mentorRepository;
    }

    public async Task<IEnumerable<DTOMentorRepository>> Handle(GetAllMentorsQuery request, CancellationToken cancellationToken)
    {
        return await _mentorRepository.GetAllMentorRepositoryAsync(cancellationToken);
    }
}

public record GetByIdMentorQuery(int Id) : IRequest<Mentor>;

public class GetByIdMentorHandler : IRequestHandler<GetByIdMentorQuery, Mentor>
{
    private readonly IMentorRepository _mentorRepository;

    public GetByIdMentorHandler(IMentorRepository mentorRepository)
    {
        _mentorRepository = mentorRepository;
    }

    public async Task<Mentor> Handle(GetByIdMentorQuery request, CancellationToken cancellationToken)
    {
        return await _mentorRepository.GetByIdMentorRepositoryAsync(request.Id, cancellationToken);
    }
}

public record GetByPagePaginationMentorQuery(int page, int size) : IRequest<IEnumerable<Mentor>>;

public class GetByPagePaginationMentorHandler : IRequestHandler<GetByPagePaginationMentorQuery,IEnumerable<Mentor>>
{
    private readonly IMentorRepository _mentorRepository;

    public GetByPagePaginationMentorHandler(IMentorRepository mentorRepository)
    {
        _mentorRepository = mentorRepository;
    }

    public async Task<IEnumerable<Mentor>> Handle(GetByPagePaginationMentorQuery request, CancellationToken cancellationToken)
    {
        return await _mentorRepository.GetByPagePaginationRepositoryAsync(request.page, request.size, cancellationToken);
    }
}


using BusinessLogic.DTOs.Ment;
using DataAccess.DTOs.Ment;
using DataAccess.Repository.Ment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record AddMentorCommand(DTOCreateMentorService Mentor) : IRequest;

public class AddMentorCommandHandler : IRequestHandler<AddMentorCommand>
{
    private readonly IMentorRepository _mentorRepository;

    public AddMentorCommandHandler(IMentorRepository mentorRepository)
    {
        _mentorRepository = mentorRepository;
    }

    public async Task Handle(AddMentorCommand request, CancellationToken cancellationToken)
    {
        var newMentor = new DTOCreateMentorRepository
        {
            Name = request.Mentor.Name,
            FirstName = request.Mentor.FirstName,
            LastName = request.Mentor.LastName,
            Email = request.Mentor.Email,
            Phone = request.Mentor.Phone,
        };
        await _mentorRepository.AddMentorRepositoryAsync(newMentor, cancellationToken);
    }
}

public record UpdateMentorCommand(DTOUpdateMentorService Mentor) : IRequest;

public class UpdateMentorHendler : IRequestHandler<UpdateMentorCommand>
{
    private readonly IMentorRepository _mentorRepository;

    public UpdateMentorHendler(IMentorRepository mentorRepository)
    {
        _mentorRepository = mentorRepository;
    }

    public async Task Handle(UpdateMentorCommand request, CancellationToken cancellationToken)
    {
        var updateMentor = new DTOUpdateMentorRepository
        {
            Name = request.Mentor.Name,
            FirstName = request.Mentor.FirstName,
            LastName = request.Mentor.LastName,
            Email = request.Mentor.Email,
            Phone = request.Mentor.Phone,
        };
        await _mentorRepository.UpdateMentorRepositoryAsync(updateMentor,cancellationToken);
    }
}

public record DeleteMentorCommand(int Id) : IRequest;

public class DeleteMentorCommandHandler : IRequestHandler<DeleteMentorCommand>
{

    private readonly IMentorRepository _mentorRepository;

    public DeleteMentorCommandHandler(IMentorRepository mentorRepository)
    {
        _mentorRepository = mentorRepository;
    }

    public async Task Handle(DeleteMentorCommand request, CancellationToken cancellationToken)
    {
        await _mentorRepository.DeleteMentorRepositoryAsync(request.Id, cancellationToken);
    }
}
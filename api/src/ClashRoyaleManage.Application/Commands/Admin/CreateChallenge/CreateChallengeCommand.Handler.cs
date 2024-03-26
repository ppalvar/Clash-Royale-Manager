using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateChallenge;

public class CreateChallengeCommandHandler : CommandHandler<CreateChallengeCommand, CreateChallengeCommandResponse>
{
    private readonly IChallengeRepository _repository;
    private readonly CreateChallengeCommandMapper _mapper;

    public CreateChallengeCommandHandler(IChallengeRepository repository)
    {
        _repository = repository;
        _mapper = new CreateChallengeCommandMapper();
    }
    
    public override async Task<CreateChallengeCommandResponse> ExecuteAsync(CreateChallengeCommand command, CancellationToken ct = default)
    {
        Challenge challenge = _mapper.ToEntity(command);
        await _repository.Create(challenge);
        CreateChallengeCommandResponse dev = _mapper.ToResponse(challenge);
        return dev;
    }
}
using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateChallenge;

public class UpdateChallengeCommandHandler : CommandHandler<UpdateChallengeCommand, UpdateChallengeCommandResponse>
{
    private readonly IChallengeRepository _repository;
    private readonly UpdateChallengeCommandMapper _mapper;

    public UpdateChallengeCommandHandler(IChallengeRepository repository)
    {
        _repository = repository;
        _mapper = new UpdateChallengeCommandMapper();
    }
    
    public override async Task<UpdateChallengeCommandResponse> ExecuteAsync(UpdateChallengeCommand command, CancellationToken ct = default)
    {
        Challenge? challenge = await _repository.Get(command.Id)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(Challenge)}> and Id <{command.Id}> not exists");
        
        if (NotChanges(challenge, command))
        {
            throw new EntityAlreadyExistException("The current challenge can't be modified!");
        }
        
        challenge.Name = command.Name;
        challenge.Description = command.Description;
        challenge.Cost = command.Cost;
        challenge.NumberOfPrizes = command.NumberOfPrizes;
        challenge.NumberOfAdmissibleDefeats = command.NumberOfAdmissibleDefeats;
        challenge.Duration = command.Duration;
        challenge.MaximumLevel = command.MaximumLevel;
        challenge.Date = command.Date;
        
        await _repository.Update(challenge);
        UpdateChallengeCommandResponse dev = _mapper.ToResponse(challenge);
        return dev;
    }

    private bool NotChanges(Challenge challenge, UpdateChallengeCommand command) => challenge.Name == command.Name && challenge.Description == command.Description
            && challenge.Cost == command.Cost && challenge.NumberOfPrizes == command.NumberOfPrizes
            && challenge.NumberOfAdmissibleDefeats == command.NumberOfAdmissibleDefeats && challenge.Duration == command.Duration && challenge.MaximumLevel ==command.MaximumLevel && challenge.Date == command.Date;
}

using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.UpdateWar;

public class UpdateWarCommandHandler : CommandHandler<UpdateWarCommand, UpdateWarCommandResponse>
{
    private readonly IWarRepository _repository;
    private readonly UpdateWarCommandMapper _mapper;

    public UpdateWarCommandHandler(IWarRepository repository)
    {
        _repository = repository;
        _mapper = new UpdateWarCommandMapper();
    }
    
    public override async Task<UpdateWarCommandResponse> ExecuteAsync(UpdateWarCommand command, CancellationToken ct = default)
    {
        War? war = await _repository.Get(command.Id)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(War)}> and Id <{command.Id}> not exists");
        
        if (NotChanges(war, command))
        {
            throw new EntityAlreadyExistException("The current war can't be modified!");
        }
        
        war.Date = command.Date;

        await _repository.Update(war);
        UpdateWarCommandResponse dev = _mapper.ToResponse(war);
        return dev;
    }

    private bool NotChanges(War war, UpdateWarCommand command) => war.Date == command.Date;
}

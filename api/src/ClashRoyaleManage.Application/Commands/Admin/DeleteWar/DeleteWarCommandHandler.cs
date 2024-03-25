using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteWar;

public class DeleteWarCommandHandler : CommandHandler<DeleteWarCommand, DeleteWarCommandResponse>
{
    private readonly IWarRepository _repository;
    private readonly DeleteWarCommandMapper _mapper;

    public DeleteWarCommandHandler(IWarRepository repository)
    {
        _repository = repository;
        _mapper = new DeleteWarCommandMapper();
    }
    
    public override async Task<DeleteWarCommandResponse> ExecuteAsync(DeleteWarCommand command, CancellationToken ct = default)
    {
        War? war = await _repository.Get(command.Id)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(War)}> and Id <{command.Id}> not exists");

        await _repository.Remove(war.Id);
        
        return _mapper.ToResponse(war);
    }
}

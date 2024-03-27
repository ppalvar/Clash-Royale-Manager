using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.DeleteClan;

public class DeleteClanCommandHandler : CommandHandler<DeleteClanCommand, DeleteClanCommandResponse>
{
    private readonly IClanRepository _repository;
    private readonly DeleteClanCommandMapper _mapper;

    public DeleteClanCommandHandler(IClanRepository repository)
    {
        _repository = repository;
        _mapper = new DeleteClanCommandMapper();
    }
    
    public override async Task<DeleteClanCommandResponse> ExecuteAsync(DeleteClanCommand command, CancellationToken ct = default)
    {
        Clan? clan = await _repository.Get1(command.Id)  
            ?? throw new EntityDoesNotExistException($"The entity of type <{nameof(Clan)}> and Id <{command.Id}> not exists");

        await _repository.Remove(clan.Id);
        
        return _mapper.ToResponse(clan);
    }
}

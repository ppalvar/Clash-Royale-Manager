using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateClan;

public class CreateClanCommandHandler : CommandHandler<CreateClanCommand, CreateClanCommandResponse>
{
    private readonly IClanRepository _repository;
    private readonly CreateClanCommandMapper _mapper;

    public CreateClanCommandHandler(IClanRepository repository)
    {
        _repository = repository;
        _mapper = new CreateClanCommandMapper();
    }
    
    public override async Task<CreateClanCommandResponse> ExecuteAsync(CreateClanCommand command, CancellationToken ct = default)
    {
        //TODO: crear lider de clan
        
        Clan clan = _mapper.ToEntity(command);
        await _repository.Create(clan);
        CreateClanCommandResponse dev = _mapper.ToResponse(clan);
        return dev;
    }
}
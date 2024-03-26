using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateWar;

public class CreateWarCommandHandler : CommandHandler<CreateWarCommand, CreateWarCommandResponse>
{
    private readonly IWarRepository _repository;
    private readonly CreateWarCommandMapper _mapper;

    public CreateWarCommandHandler(IWarRepository repository)
    {
        _repository = repository;
        _mapper = new CreateWarCommandMapper();
    }
    
    public override async Task<CreateWarCommandResponse> ExecuteAsync(CreateWarCommand command, CancellationToken ct = default)
    {
        War war = _mapper.ToEntity(command);
        await _repository.Create(war);
        CreateWarCommandResponse dev = _mapper.ToResponse(war);
        return dev;
    }
}
using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Admin.CreateCard;

public class CreateCardCommandHandler : CommandHandler<CreateCardCommand, CreateCardCommandResponse>
{
    private readonly ICardRepository _repository;
    private readonly CreateCardCommandMapper _mapper;

    public CreateCardCommandHandler(ICardRepository repository)
    {
        _repository = repository;
        _mapper = new CreateCardCommandMapper();
    }

    public override async Task<CreateCardCommandResponse> ExecuteAsync(CreateCardCommand command, CancellationToken ct = default)
    {
        Card card = _mapper.ToEntity(command);
        await _repository.Create(card);
        CreateCardCommandResponse dev = _mapper.ToResponse(card);
        return dev;
    }
}
using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Application.Services;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Auth;

public class RegisterCommandHandler : CommandHandler<RegisterCommand>
{
    private readonly IUserRepository _repository;
    private readonly RegisterCommandMapper _mapper;

    public RegisterCommandHandler(IUserRepository repository, IEncryptService encryptService)
    {
        _repository = repository;
        _mapper = new RegisterCommandMapper(encryptService);
    }
    
    public async override Task ExecuteAsync(RegisterCommand command, CancellationToken ct = default)
    {
        User user = _mapper.ToEntity(command);
        await _repository.Create(user);
    }
}
using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Application.Services;
using ClashRoyaleManager.Application.Services.Auth;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Auth;

public class RegisterCommandHandler : ICommandHandler<RegisterCommand, RegisterCommandResponse>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _repository;
    private readonly RegisterCommandMapper _mapper;

    public RegisterCommandHandler(
        IUserRepository repository, 
        IEncryptService encryptService, 
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _repository = repository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _mapper = new RegisterCommandMapper(encryptService);
    }

    public async Task<RegisterCommandResponse> ExecuteAsync(RegisterCommand command, CancellationToken ct = default)
    {
        User user = _mapper.ToEntity(command);
        user.Id = Guid.NewGuid();

        await _repository.Create(user);
        string token = _jwtTokenGenerator.GenerateToken(user);
        
        return new RegisterCommandResponse(
            user,
            token
        );
    }
}
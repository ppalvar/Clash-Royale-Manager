using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Application.Services;
using ClashRoyaleManager.Application.Services.Auth;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Commands.Auth;

public class RegisterCommandHandler : CommandHandler<RegisterCommand, RegisterCommandResponse>
{
    private readonly IUserRepository _repository;
    private readonly IEncryptService _encryptService;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public RegisterCommandHandler(IUserRepository repository, IEncryptService encryptService, IJwtTokenGenerator jwtTokenGenerator)
    {
        this._repository = repository;
        this._encryptService = encryptService;
        this._jwtTokenGenerator = jwtTokenGenerator;
    }

    public override async Task<RegisterCommandResponse> ExecuteAsync(RegisterCommand command, CancellationToken ct = default)
    {
        var _mapper = new RegisterCommandMapper(_encryptService);

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
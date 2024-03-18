using ClashRoyaleManager.Application.Repositories;
using ClashRoyaleManager.Application.Services;
using ClashRoyaleManager.Application.Services.Auth;
using ClashRoyaleManager.Domain.Entities;
using ClashRoyaleManager.Domain.Exceptions;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Auth;

public class LoginCommandHandler : CommandHandler<LoginCommand, LoginCommandResponse>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _repository;
    private readonly IEncryptService _encryptService;

    public LoginCommandHandler(
        IUserRepository repository,
        IJwtTokenGenerator jwtTokenGenerator,
        IEncryptService encryptService)
    {
        _repository = repository;
        _jwtTokenGenerator = jwtTokenGenerator;
        _encryptService = encryptService;
    }

    public override async Task<LoginCommandResponse> ExecuteAsync(LoginCommand command, CancellationToken ct = default)
    {
        var user = await _repository.GetByEmail(command.Email) ?? throw new EntityDoesNotExistException("User Not Found!");

        Console.WriteLine($"{user.Password} =?= {command.Password}");

        if (!_encryptService.Decrypt(command.Password, user.Password))
        {
            throw new InvalidCredentialsException("Password Incorrect!");
        }

        string token = _jwtTokenGenerator.GenerateToken(user);

        return new LoginCommandResponse(
            user,
            token
        );
    }
}
using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Auth;

public record RegisterCommandResponse(User User, string Token);
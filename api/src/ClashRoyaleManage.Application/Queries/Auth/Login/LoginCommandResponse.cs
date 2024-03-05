using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Query.Auth;

public record LoginCommandResponse(User User, string Token);
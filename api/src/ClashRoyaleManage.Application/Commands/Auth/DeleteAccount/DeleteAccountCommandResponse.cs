using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Commands.Auth;

public record DeleteAccountCommandResponse(string Username, string Email);
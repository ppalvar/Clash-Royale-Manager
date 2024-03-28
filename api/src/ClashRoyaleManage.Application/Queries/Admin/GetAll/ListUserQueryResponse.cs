using System.Collections.Generic;
using ClashRoyaleManager.Domain.Entities;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Users;

public record ListUserQueryResponse
{ 
    public IEnumerable<User> Users { get; set; } = null!;
}
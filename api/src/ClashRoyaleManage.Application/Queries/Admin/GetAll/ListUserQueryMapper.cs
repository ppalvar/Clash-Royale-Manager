using System.Linq;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ClashRoyaleManager.Application.Query.Users;

public class ListUserQueryMapper : AbstractMapper<IQueryable<User>, ListUserQuery, ListUserQueryResponse>
{
    public override ListUserQueryResponse ToResponse(IQueryable<User> entities)
    {
        return new ListUserQueryResponse {
            Users = entities
        };
    }
}
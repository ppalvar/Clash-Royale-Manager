using System.Linq;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ClashRoyaleManager.Application.Query.Battles;

public class ListBattleQueryMapper : AbstractMapper<IQueryable<Battle>, ListBattleQuery, ListBattleQueryResponse>
{
}
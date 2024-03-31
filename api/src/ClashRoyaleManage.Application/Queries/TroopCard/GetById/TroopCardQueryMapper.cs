using System.Linq;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ClashRoyaleManager.Application.Query.TroopCards;

public class TroopCardQueryMapper : AbstractMapper<TroopCard, TroopCardQuery, TroopCardQueryResponse>
{
}
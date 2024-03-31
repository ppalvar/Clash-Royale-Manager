using System.Linq;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ClashRoyaleManager.Application.Query.SpellCards;

public class SpellCardQueryMapper : AbstractMapper<SpellCard, SpellCardQuery, SpellCardQueryResponse>
{
}
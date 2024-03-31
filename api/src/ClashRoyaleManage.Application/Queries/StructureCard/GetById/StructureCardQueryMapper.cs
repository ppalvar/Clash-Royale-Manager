using System.Linq;
using ClashRoyaleManager.Application.Common;
using ClashRoyaleManager.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ClashRoyaleManager.Application.Query.StructureCards;

public class StructureCardQueryMapper : AbstractMapper<StructureCard, StructureCardQuery, StructureCardQueryResponse>
{
}
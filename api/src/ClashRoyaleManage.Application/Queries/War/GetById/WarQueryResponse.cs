using ClashRoyaleManager.Domain.Entities;

namespace ClashRoyaleManager.Application.Query.Wars;

public record WarQueryResponse
{
    public DateTime Date { get; set; }
}
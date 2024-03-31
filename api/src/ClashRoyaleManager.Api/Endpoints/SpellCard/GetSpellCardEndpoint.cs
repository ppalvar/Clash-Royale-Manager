using ClashRoyaleManager.Application.Query.SpellCards;
using FastEndpoints;
using Microsoft.EntityFrameworkCore.Query;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetSpellCardEndpoint : Endpoint<SpellCardQuery, SpellCardQueryResponse>
{
    public override void Configure()
    {
        Get("/spellcards/{Id}");
        AllowAnonymous();
    }

    public async override Task HandleAsync(SpellCardQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}
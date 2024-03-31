using ClashRoyaleManager.Application.Query.SpellCards;
using FastEndpoints;

namespace ClashRoyaleManager.Presentation.Endpoints;

public class GetAllSpellCardEndpoint : Endpoint<ListSpellCardQuery, ListSpellCardQueryResponse>
{
    public override void Configure()
    {
        Get("/spellcards");
        AllowAnonymous();
    }

    public async override Task HandleAsync(ListSpellCardQuery req, CancellationToken ct)
    {
        var response = await req.ExecuteAsync(ct);
        await SendAsync(response);
    }
}
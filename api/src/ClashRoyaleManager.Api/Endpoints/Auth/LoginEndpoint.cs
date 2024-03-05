// using ClashRoyaleManager.Application.Commands.Auth;
// using FastEndpoints;

// namespace ClashRoyaleManager.Presentation.Endpoints;

// public class LoginEndpoint : Endpoint<LoginCommand>
// {
//     public override void Configure()
//     {
//         Post("/api/auth/login");
//         AllowAnonymous();
//     }

//     public override async Task HandleAsync(LoginCommand req, CancellationToken ct)
//     {
//         await req.ExecuteAsync(ct);
//         await SendOkAsync();
//     }
// }
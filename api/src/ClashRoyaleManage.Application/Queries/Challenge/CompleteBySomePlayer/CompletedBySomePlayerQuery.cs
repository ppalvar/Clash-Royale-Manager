using System.Windows.Input;
using FastEndpoints;

namespace ClashRoyaleManager.Application.Query.Challenges;

public record CompletedBySomePlayerQuery(int Page, int PageSize) : ICommand<ListChallengeQueryResponse>;
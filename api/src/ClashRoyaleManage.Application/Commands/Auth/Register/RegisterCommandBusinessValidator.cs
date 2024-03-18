using ClashRoyaleManager.Application.Repositories;
using FastEndpoints;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ClashRoyaleManager.Application.Commands.Auth;

public static class RegisterCommandBusinessValidator
{
    public static IRuleBuilderOptions<RegisterCommand, string> CheckUniqueEmail(this IRuleBuilder<RegisterCommand, string> ruleBuilder, Func<IServiceScope> serviceScope)
    {
        return ruleBuilder.MustAsync(async (email, ct) =>
        {
            var scope = serviceScope();
            var userRepository = scope.Resolve<IUserRepository>();
            return await userRepository.GetByEmail(email) is null;
        });
    }
}
using MediatR;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC;
public static class DependencyContainer
{
    public static IServiceCollection AddInfraestructureServices
        (this IServiceCollection services, IConfiguration configuration)
    {
        #region Data
        var connectionString = configuration.GetConnectionString("Database");

        services.AddDbContext<BankingDbContext>(options => options.UseSqlServer(connectionString));
        #endregion

        #region Bus
        services.AddScoped<IEventBus, RabbitMQBus>();
        #endregion

        #region Commands
        services.AddScoped<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();
        #endregion

        #region Services
        services.AddScoped<IAccountService, AccountService>();
        #endregion

        #region Repository
        services.AddScoped<IAccountRepository, AccountRepository>();
        #endregion

        return services;
    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeekWriterService.Service;
using PeekWriterService.Service.Interfaces;
using PeekWriterService.Models.Common;
using PeekWriterService.Repository.Repositories;

namespace UserService.API.Config
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services,
                                                                                  IConfiguration configuration)
        {

            services.AddScoped<ICommandHandler, CommandHandler>();

            services.AddScoped<ICommentsRepository, CommentsRepository>();
            services.AddScoped<ILikesRepository, LikesRepository>();
            services.AddScoped<IPeekRepository, PeekRepository>();

            return services;
        }
    }
}

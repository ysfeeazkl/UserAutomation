using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAutomation.Business.Abstract;
using UserAutomation.Business.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using UserAutomation.Data.Concrete.Context;
using UserAutomation.Dapper.Repository;
using UserOtomation.Shared.Entities.Abstrack;

namespace UserAutomation.Business.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection services)//, WebApplicationBuilder builder
        {
            services.AddDbContext<UserAutomationContext>(contextLifetime: ServiceLifetime.Transient, optionsLifetime: ServiceLifetime.Transient);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IDapperRepository<IEntity>, DapperRepository<IEntity>>();
            services.AddScoped<ICompanyService, CompanyManager>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<ILocationService, LocationManager>();
            services.AddScoped<IWorkerService, WorkerManager>();


            return services;

        }
    }
}

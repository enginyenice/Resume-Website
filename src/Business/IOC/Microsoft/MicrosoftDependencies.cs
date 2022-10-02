using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Business.Concreate;
using Business.Interfaces;
using Business.ValidationRules;
using DataAccess.Concrete.Dapper;
using DataAccess.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Business.IOC.Microsoft
{
    public static class MicrosoftDependencies
    {
        public static void AddCustomDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDbConnection>
                (con => new SqlConnection(configuration.GetConnectionString("SqlServer")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(DpGenericRepository<>));
            
            services.AddScoped<IAppUserRepository, DpAppUserRepository>();
            services.AddScoped<IAppUserService, AppUserManager>();

            services.AddScoped<ISocialMediaIconRepository, DpSocialMediaIconRepository>();
            services.AddScoped<ISocialMediaIconService, SocialMediaIconManager>();


            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddValidatorsFromAssemblyContaining<AppUserUpdateDtoValidator>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using tg.domain.Entities;
using tg.infrastructure.Data;

namespace tg.api.Extensions
{
    public static class ConfigureIdentityExtensions
    {
        public static void ConfigureIdentityPolicy(this IServiceCollection services)
        {
            services.AddIdentity<UserModel, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequiredLength = 12;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>();
        }
    }
}
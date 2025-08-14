using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using tg.application.Common;
using tg.application.Features.Follower.Follow;
using tg.application.Features.Follower.GetFollower;
using tg.application.Features.Following.GetFollower;
using tg.application.Repository;
using tg.application.Repository.IFollowerRepository;
using tg.application.Repository.IHobbyRepository;
using tg.application.Repository.ISkillRepository;
using tg.application.Repository.ITokenRepository;
using tg.application.Repository.IUserRepository;
using tg.domain.Entities;
using tg.infrastructure.Data;
using tg.infrastructure.Repository;
using tg.infrastructure.Repository.FollowerRepository;
using tg.infrastructure.Repository.HobbyRepository;
using tg.infrastructure.Repository.SkillRepository;
using tg.infrastructure.Repository.TokenRepository;
using tg.infrastructure.Repository.UserRepository;

namespace tg.infrastructure
{
    public static class ServiceExtensions
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));
            services.AddHttpContextAccessor();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISkillRepository, SkillRepository>();
            services.AddScoped<IHobbyRepository, HobbyRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IUserService, UserService>();
            // Custom mediator
            services.AddScoped<IFollowerRepository, FollowerRepository>();
            services.AddScoped<ICommandHandler<CreateFollowRequest, Result<CreateFollowResponse>>, CreateFollowHandler>();
            services.AddScoped<ICommandHandler<GetFollowerRequest, GetFollowerResponse>, GetFollowerHandler>();
        }
    }
}
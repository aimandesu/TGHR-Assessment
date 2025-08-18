using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using tg.application.Common;
using tg.application.Dtos;
using tg.application.Features.ExternalAPI.Product;
using tg.application.Features.Follower.Follow;
using tg.application.Features.Follower.GetFollower;
using tg.application.Features.Following.GetFollower;
using tg.application.Features.Package.Create;
using tg.application.Features.Service.Create;
using tg.application.Features.Service.Delete;
using tg.application.Features.Service.GetAll;
using tg.application.Repository;
using tg.application.Repository.IExternalApiClientRepository;
using tg.application.Repository.IFollowerRepository;
using tg.application.Repository.IHobbyRepository;
using tg.application.Repository.IPackageRepository;
using tg.application.Repository.IServiceRepository;
using tg.application.Repository.ISkillRepository;
using tg.application.Repository.ITokenRepository;
using tg.application.Repository.IUserRepository;
using tg.domain.Entities;
using tg.infrastructure.Data;
using tg.infrastructure.Repository;
using tg.infrastructure.Repository.ExternalApiClient;
using tg.infrastructure.Repository.FollowerRepository;
using tg.infrastructure.Repository.HobbyRepository;
using tg.infrastructure.Repository.PackageRepository;
using tg.infrastructure.Repository.ServiceRepository;
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
            //IFollowRepository
            services.AddScoped<IFollowerRepository, FollowerRepository>();
            services.AddScoped<ICommandHandler<CreateFollowRequest, Result<CreateFollowResponse>>, CreateFollowHandler>();
            services.AddScoped<ICommandHandler<GetFollowerRequest, GetFollowerResponse>, GetFollowerHandler>();
            //IServiceRepository
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services
                .AddScoped<ICommandHandler<CreateServiceRequest, Result<CreateServiceResponse>>,
                    CreateServiceHandler>();
            services
                .AddScoped<ICommandHandler<DeleteServiceRequest, Result<DeleteServiceResponse>>,
                    DeleteServiceHandler>();
            services
                .AddScoped<ICommandHandler<GetAllServiceRequest, Pagination<ServiceModelDto>>, GetAllServiceHandler>();
            //IPackageRepository
            services.AddScoped<IPackageRepository, PackageRepository>();
            services.AddScoped<ICommandHandler<CreatePackageRequest, CreatePackageResponse>, CreatePackageHandler>();
            //IExternalApiClient
            services.AddScoped<IExternalApiClientRepository, ExternalApiClient>();
            services.AddScoped<ICommandHandler<GetProductRequest, GetProductResponse>, GetProductHandler>();
        }

        public static void ConfigureHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("ExternalApi", client =>
            {
                client.BaseAddress = new Uri(configuration["ExternalApi:FakeStoreUrl"] ?? "");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                //here we can do like attached headers etc
            });
            
            services.AddTransient<IExternalApiClientRepository>(sp =>
            {
                var httpFactory = sp.GetRequiredService<IHttpClientFactory>();
                var http = httpFactory.CreateClient("ExternalApi");
                return new ExternalApiClient(http);
            });
            
        }
        
    }
}
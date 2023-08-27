using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Pukimoni.Api.Core;
using Pukimoni.Application.BusinessLogic.Commands;
using Pukimoni.Application.BusinessLogic.Queries;
using Pukimoni.DataAccess;
using Pukimoni.Domain.Interfaces;
using Pukimoni.Implementation.BusinessLogic;
using Pukimoni.Implementation.BusinessLogic.Commands;
using Pukimoni.Implementation.BusinessLogic.Queries;
using Pukimoni.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pukimoni.Api.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddAllAppServices(this IServiceCollection services, AppSettings settings)
        {
            services.AddAppUser();
            services.AddJwt(settings);
            services.AddAppUseCases();
            services.AddAppFluentValidation();

            return services;
        }

        public static IServiceCollection AddAppFluentValidation(this IServiceCollection services)
        {
            services.AddTransient<CreateUserValidator>();
            services.AddTransient<UpdateUserValidator>();
            services.AddTransient<CreateRegionValidator>();
            services.AddTransient<CreatePokemonValidator>();
            services.AddTransient<UpdatePokemonValidator>();
            services.AddTransient<CreateElementTypeValidator>();
            services.AddTransient<CatchPokemonValidator>();
            services.AddTransient<UpdateDetailsValidator>();
            return services;
        }

        public static IServiceCollection AddAppUseCases(this IServiceCollection services)
        {
            //GET
            services.AddTransient<IGetLogQuery, EfGetLogQuery>();
            services.AddTransient<IGetUserQuery, EfGetUserQuery>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IGetRegionQuery, EfGetRegionQuery>();
            services.AddTransient<IGetRegionsQuery, EfGetRegionsQuery>();
            services.AddTransient<IGetPokemonQuery, EfGetPokemonQuery>();
            services.AddTransient<IGetPokedexQuery, EfGetPokedexQuery>();
            services.AddTransient<IGetPokemonsQuery, EfGetPokemonsQuery>();
            services.AddTransient<IGetElementTypeQuery, EfGetElementTypeQuery>();
            services.AddTransient<IGetElementTypesQuery, EfGetElementTypesQuery>();
            services.AddTransient<IGetTrainerPokemonQuery, EfGetTrainerPokemonQuery>();

            //INSERT
            services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
            services.AddTransient<ICreateRegionCommand, EfCreateRegionCommand>();
            services.AddTransient<ICreatePokemonCommand, EfCreatePokemonCommand>();
            services.AddTransient<ICreateElementTypeCommand, EfCreateElementTypeCommand>();


            services.AddTransient<ICatchPokemonCommand, EfCatchPokemonCommand>();

            //UPDATE
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<IUpdateRegionCommand, EfUpdateRegionCommand>();
            services.AddTransient<IUpdatePokemonCommand, EfUpdatePokemonCommand>();
            services.AddTransient<IUpdateElementTypeCommand, EfUpdateElementTypeCommand>();
            services.AddTransient<IFavoritePokemonCommand, EfFavoritePokemonCommand>();
            services.AddTransient<IBanUserCommand, EfBanUserCommand>();

            //DELETE
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IDeleteRegionCommand, EfDeleteRegionCommand>();
            services.AddTransient<IDeleteElementTypeCommand, EfDeleteElementTypeCommand>();
            services.AddTransient<IDeletePokemonCommand, EfDeletePokemonCommand>();
            services.AddTransient<ITransferPokemonCommand, EfTransferPokemonCommand>();

            return services;
        }

        public static void AddAppUser(this IServiceCollection services)
        {
            services.AddTransient<IApplicationUser>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();
                var header = accessor.HttpContext.Request.Headers["Authorization"];

                var claims = accessor.HttpContext.User;

                if (claims == null || claims.FindFirst("UserId") == null)
                {
                    return new StarterUser();
                }

                var actor = new JwtUser
                {
                    Email = claims.FindFirst("Email").Value,
                    Id = Int32.Parse(claims.FindFirst("UserId").Value),
                    Identity = claims.FindFirst("Email").Value,
                    PermissionIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("Permissions").Value)
                };

                return actor;
            });
        }

        public static void AddJwt(this IServiceCollection services, AppSettings settings)
        {
            services.AddTransient(x =>
            {
                var context = x.GetService<PukimoniContext>();
                var settings = x.GetService<AppSettings>();

                return new JwtManager(context, settings.JwtSettings);
            });

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = settings.JwtSettings.Issuer,
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JwtSettings.SecretKey)),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pukimoni.Api.Core;
using Pukimoni.Api.Extensions;
using Pukimoni.Application.BusinessLogic;
using Pukimoni.Application.Emails;
using Pukimoni.Application.Logger;
using Pukimoni.DataAccess;
using Pukimoni.Implementation.BusinessLogic;
using Pukimoni.Implementation.BusinessLogic.Queries;
using Pukimoni.Implementation.Emails;
using Pukimoni.Implementation.Extensions;
using Pukimoni.Implementation.Loggers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Pukimoni.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var settings = new AppSettings();

            Configuration.Bind(settings);

            services.AddSingleton(settings);
            services.AddTransient<PukimoniContext>();
            services.AddAllAppServices(settings);
            services.AddControllers();
            services.AddTransient<ILogger, ConsoleLogger>();
            services.AddTransient<IUseCaseLogger, DbLogger>();
            services.AddTransient<BaseHandler>();
            services.AddTransient<IEmailSender>(x =>
             new SmtpEmailSender(settings.EmailOptions.FromEmail,
                                 settings.EmailOptions.Password,
                                 settings.EmailOptions.Port,
                                 settings.EmailOptions.Host));

            services.AddControllers();
            services.AddHttpContextAccessor();

            // AutoMapper
            services.AddAutoMapper(typeof(EfGetUserQuery).Assembly);
            services.AddAutoMapper(typeof(EfGetUsersQuery).Assembly);
            services.AddAutoMapper(typeof(EfGetRegionQuery).Assembly);
            services.AddAutoMapper(typeof(EfGetRegionsQuery).Assembly);
            services.AddAutoMapper(typeof(EfGetPokemonQuery).Assembly);
            services.AddAutoMapper(typeof(EfGetPokemonsQuery).Assembly);
            services.AddAutoMapper(typeof(EfGetElementTypeQuery).Assembly);
            services.AddAutoMapper(typeof(EfGetElementTypesQuery).Assembly);
            services.AddAutoMapper(typeof(EfGetTrainerPokemonQuery).Assembly);
            services.AddAutoMapper(typeof(EfGetPokedexQuery).Assembly);
            services.AddAutoMapper(typeof(EfGetLogQuery).Assembly);


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pukimoni", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                          {
                            Reference = new OpenApiReference
                              {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                              },
                              Scheme = "oauth2",
                              Name = "Bearer",
                              In = ParameterLocation.Header,

                            },
                            new List<string>()
                          }
                    });
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pukimoni.Api v1"));
            }

            app.UseRouting();
            app.ConfigureExceptionMiddleware();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

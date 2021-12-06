using AutoMapper;
using EstudoDDD.CrossCutting.DependencyInjection;
using EstudoDDD.CrossCutting.Mappings;
using EstudoDDD.Domain.Entities.SendGrid;
using EstudoDDD.Domain.Interfaces;
using EstudoDDD.Domain.Security;
using EstudoDDD.Service.SendGrid;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;

namespace EstudoDDD.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            // Set informações do AppSettings
            Environment.SetEnvironmentVariable("SQL", Configuration.GetConnectionString("SQL"));

            // SendGrid
            services.AddTransient<IEmailSender, SendGridEmailSender>();
            services.Configure<SendGridEmailSenderOptions>(options =>
            {
                options.ApiKey = Configuration["ExternalProviders:SendGrid:ApiKey"];
                options.SenderEmail = Configuration["ExternalProviders:SendGrid:SenderEmail"];
                options.SenderName = Configuration["ExternalProviders:SendGrid:SenderName"];
            });

            // Injeção de dependencia
            ConfigureService.ConfigureDependenciesService(services);
            ConfigureRepository.ConfigureDependenciesRepository(services);

            // AutoMapper
            AutoMapper.MapperConfiguration config = new(cfg =>
            {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            // JWT
            SigningConfigurations signingConfigurations = new();
            services.AddSingleton(signingConfigurations);
            TokenConfigurations tokenConfigurations = new();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(Configuration.GetSection("TokenConfigurations"))
                                                                                    .Configure(tokenConfigurations);
            services.AddSingleton(tokenConfigurations);
            services.AddAuthentication(authOptions =>
                                                    {
                                                        authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                                                        authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                                                    })
                    .AddJwtBearer(bearerOptions =>
                                                    {
                                                        var paramsValidation = bearerOptions.TokenValidationParameters;
                                                        paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                                                        paramsValidation.ValidAudience = tokenConfigurations.Audience;
                                                        paramsValidation.ValidIssuer = tokenConfigurations.Issuer;
                                                        paramsValidation.ValidateIssuerSigningKey = true;
                                                        paramsValidation.ValidateLifetime = true;
                                                        paramsValidation.ClockSkew = TimeSpan.Zero;
                                                    });
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder().AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                                                                         .RequireAuthenticatedUser()
                                                                         .Build());
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "EstudoDDD.API",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Vinicius Nascimento",
                        Email = "vini.souza00@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/vinicius-nascimento-3682417b/")
                    }
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Entre com o token JWT",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                   {
                       new OpenApiSecurityScheme{
                             Reference = new OpenApiReference{
                                 Id = "Bearer",
                                 Type = ReferenceType.SecurityScheme
                             }
                   }, new List<string>()
                } });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EstudoDDD.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

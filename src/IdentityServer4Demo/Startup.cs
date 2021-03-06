﻿using IdentityServer4;
using IdentityServer4.Quickstart.UI;
using IdentityServer4.Services;
using IdentityServer4.Validation;
using IdentityServer4Demo.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Linq;

namespace IdentityServer4Demo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // cookie policy to deal with temporary browser incompatibilities
            services.AddSameSiteCookiePolicy();

            var identityServerBuilder = services.AddIdentityServer(options =>
            {
                options.Events.RaiseErrorEvents = true;
                options.Events.RaiseFailureEvents = true;
                options.Events.RaiseInformationEvents = true;
                options.Events.RaiseSuccessEvents = true;
            });

            var seed = Configuration.Get<SeedOptions>();
            identityServerBuilder
                .AddInMemoryApiResources(seed?.ApiResources == null
                    ? Config.GetApis()
                    : seed.ApiResources.Select(ar => ar.ToModel()))
                .AddInMemoryIdentityResources(seed?.IdentityResources == null
                    ? Config.GetIdentityResources()
                    : seed.IdentityResources.Select(ir => ir.ToModel()))
                .AddInMemoryClients(seed?.Clients == null
                    ? Config.GetClients()
                    : seed.Clients.Select(c => c.ToModel()))
                .AddTestUsers(seed?.Users == null
                    ? TestUsers.Users
                    : seed.Users.Select(u => u.ToModel()).ToList())
                .AddDeveloperSigningCredential(persistKey: false);

            services.AddAuthentication();

            // add CORS policy for non-IdentityServer endpoints
            services.AddCors(options =>
            {
                options.AddPolicy("api", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            // demo versions (never use in production)
            services.AddTransient<IRedirectUriValidator, DemoRedirectValidator>();
            services.AddTransient<ICorsPolicyService, DemoCorsPolicy>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseCookiePolicy();
            app.UseSerilogRequestLogging();
            app.UseDeveloperExceptionPage();

            app.UseCors("api");

            app.UseStaticFiles();

            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
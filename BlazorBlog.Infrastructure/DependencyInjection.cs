﻿using BlazorBlog.Application.Authentication;
using BlazorBlog.Domain.Articles;
using BlazorBlog.Domain.Users;
using BlazorBlog.Infrastructure.Authentication;
using BlazorBlog.Infrastructure.Repositories;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorBlog.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        AddAuthentication(services);

        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    private static void AddAuthentication(IServiceCollection services)
    {
        services.AddSingleton<IAuthorizationMiddlewareResultHandler, AuthorizationMiddlewareResultHandler>();

        services.AddScoped<IAuthenticationService, AuthenticationService>();

        services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
        services.AddCascadingAuthenticationState();
        services.AddAuthorization();

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = IdentityConstants.ApplicationScheme;
            options.DefaultChallengeScheme = IdentityConstants.ExternalScheme;
        })
            .AddIdentityCookies();

        services.AddIdentityCore<User>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();
    }
}

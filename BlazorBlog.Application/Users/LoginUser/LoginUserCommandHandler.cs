﻿using BlazorBlog.Application.Authentication;

namespace BlazorBlog.Application.Users.LoginUser;

public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand>
{
    private readonly IAuthenticationService _authenticationService;

    public LoginUserCommandHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<Result> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var success = await _authenticationService.LoginUserAsync(request.UserName, request.Password);

        if (success)
        {
            return Result.Ok();
        }

        return Result.Fail("Invalid username or password.");
    }
}

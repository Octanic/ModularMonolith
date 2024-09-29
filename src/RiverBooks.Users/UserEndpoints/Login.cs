﻿using FastEndpoints;
using FastEndpoints.Security;
using Microsoft.AspNetCore.Identity;

namespace RiverBooks.Users.UserEndpoints;

internal class Login : Endpoint<UserLoginRequest>
{
	private readonly UserManager<ApplicationUser> _userManager;

	public Login(UserManager<ApplicationUser> userManager)
	{
		_userManager = userManager;
	}

	public override void Configure()
	{
		Post("/users/login");
		AllowAnonymous();
	}

	public override async Task HandleAsync(UserLoginRequest req, CancellationToken ct)
	{
		var user = await _userManager.FindByEmailAsync(req.Email);

		if (user == null)
		{
			await SendUnauthorizedAsync(cancellation: ct);
			return;
		}

		var loginSuccessful = await _userManager.CheckPasswordAsync(user, req.Password);

		if (!loginSuccessful)
		{
			await SendUnauthorizedAsync(cancellation: ct);
			return;
		}

		var jwtSecret = Config["Auth:JwtSecret"]!;
		
		var token = JwtBearer.CreateToken(x =>
		{
			x.SigningKey = jwtSecret;
			x.User.Claims.Add(new System.Security.Claims.Claim("EmailAddress", user.Email!));
		});

		await SendAsync(token, cancellation: ct);

	}

}

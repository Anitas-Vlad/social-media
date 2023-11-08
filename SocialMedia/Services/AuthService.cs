﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.IdentityModel.Tokens;
using SocialMedia.Models;
using SocialMedia.Models.Requests;
using SocialMedia.Services.Interfaces;

namespace SocialMedia.Services;

public class AuthService : IAuthService
{
    private readonly IUsersService _usersService;
    private readonly IConfiguration _configuration;

    public AuthService(IConfiguration configuration, IUsersService usersService)
    {
        _configuration = configuration;
        _usersService = usersService;
    }

    public async Task<string> Login(LoginRequest request)
    {
        var userFromDb = await _usersService.QueryUserByEmail(request.Email);
        
        if (userFromDb == null) 
            throw new ArgumentException("User not found.");
        
        if (!BCrypt.Net.BCrypt.Verify(request.Password, userFromDb.PasswordHash))
            throw new ArgumentException("Wrong password.");

        var token = CreateToken(userFromDb);

        return token;
    }

    public string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Email, user.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            _configuration.GetSection("AppSettings:Token").Value!));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }
}
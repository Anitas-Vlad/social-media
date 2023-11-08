using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Context;
using SocialMedia.Models;
using SocialMedia.Models.Requests;
using SocialMedia.Services.Interfaces;

namespace SocialMedia.Services;

public class UsersService : IUsersService
{
    private readonly SocialMediaContext _context;
    private static Regex _mailPattern;

    public UsersService(SocialMediaContext context)
    {
        _context = context;
        _mailPattern = new("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
    }

    public async Task<User> QueryUserById(int userId)
    {
        var user = await _context.Users
            .Where(user => user.Id == userId)
            .FirstOrDefaultAsync();

        if (user == null) throw new ArgumentException("User not found.");

        return user;
    }

    public Task<List<User>> QueryAllUsers() =>
        _context.Users.ToListAsync();

    public async Task<User?> QueryUserByEmail(string userEmail)
     => await _context.Users
            .Where(user => user.Email == userEmail)
            .FirstOrDefaultAsync();

    public async Task<User> CreateUser(RegisterRequest request)
    {
        await IsEmailValid(request.Email);
        IsPasswordValid(request.Password);
        
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new User
        {
            UserName = request.UserName,
            PasswordHash = passwordHash,
            Email = request.Email
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        
        return user;
    }

    private async Task IsEmailValid(string userEmail)
    {
        if (!_mailPattern.IsMatch(userEmail))
            throw new ArgumentException("Please enter a valid email.");

        if (await QueryUserByEmail(userEmail) != null)
            throw new ArgumentException("Email in use.");
    }

    private void IsPasswordValid(string userPassword)
    {
        if (userPassword.Length < 8)
            throw new ArgumentException("Password must be at least 8 characters long");
    }
}
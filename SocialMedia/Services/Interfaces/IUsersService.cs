using SocialMedia.Models;
using SocialMedia.Models.Requests;

namespace SocialMedia.Services.Interfaces;

public interface IUsersService
{
    Task<User> QueryUserById(int userId);
    Task<List<User>> QueryAllUsers();
    Task<User?> QueryUserByEmail(string userEmail);
    Task<User> CreateUser(RegisterRequest request);
}
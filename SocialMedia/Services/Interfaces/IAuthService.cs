using SocialMedia.Models;
using SocialMedia.Models.Requests;

namespace SocialMedia.Services.Interfaces;

public interface IAuthService
{
    Task<string> Login(LoginRequest request);
}
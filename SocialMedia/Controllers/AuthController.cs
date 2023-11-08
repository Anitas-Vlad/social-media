using Microsoft.AspNetCore.Mvc;
using SocialMedia.Models;
using SocialMedia.Models.Requests;
using SocialMedia.Services.Interfaces;

namespace SocialMedia.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUsersService _usersService;
    private readonly IAuthService _authService;

    public AuthController(IUsersService usersService, IAuthService authService)
    {
        _usersService = usersService;
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<User>> Register(RegisterRequest request)
        => await _usersService.CreateUser(request);

    [HttpPost("login")]
    public async Task<ActionResult<User>> Login(LoginRequest request)
        => Ok(await _authService.Login(request));
}
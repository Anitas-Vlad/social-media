using Microsoft.AspNetCore.Mvc;
using SocialMedia.Models;
using SocialMedia.Services.Interfaces;

namespace SocialMedia.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService) => _usersService = usersService;

    [HttpGet]
    [Route("/{userId}")]
    public async Task<ActionResult<User>> GetUserById(int userId) 
        => await _usersService.QueryUserById(userId);

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAllUsers() 
        => await _usersService.QueryAllUsers();
}
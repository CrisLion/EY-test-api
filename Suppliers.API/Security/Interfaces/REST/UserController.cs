using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Suppliers.API.Security.Domain.Models.Commands;
using Suppliers.API.Security.Domain.Services;

namespace Suppliers.API.Security.Interfaces.REST;

[ApiController]
[Route("/api/v1/users")]
[Produces("application/json")]
public class UserController : ControllerBase
{
    private readonly IUserCommandService _userCommandService;

    public UserController(IUserCommandService userCommandService)
    {
        _userCommandService = userCommandService;
    }
    
    [HttpPost]
    [Route("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand command)
    {
        var result = await _userCommandService.Handle(command);
        return StatusCode(StatusCodes.Status201Created, result);
    }
    
    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
    {
        var result = await _userCommandService.Handle(command);
        return Ok(result);
    }
    
}
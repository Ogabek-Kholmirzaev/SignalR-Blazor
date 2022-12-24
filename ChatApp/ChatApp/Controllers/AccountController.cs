using System.Security.Claims;
using ChatAppApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChatAppApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly SignInManager<IdentityUser> _signInManager;

    public AccountController(SignInManager<IdentityUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpPost]
    public async Task<IActionResult> Login(string username)
    {
        var user = new IdentityUser(username);
        await _signInManager.SignInAsync(user, isPersistent: true);

        return Ok();
    }

    [Authorize]
    [HttpGet]
    public IActionResult GetProfile() =>
        Ok($"Profile : {User.FindFirst((ClaimTypes.Name))?.Value}");

    [HttpGet("groups")]
    public IActionResult GetGroups()=>Ok(new List<string>()
    {
        "DotNet",
        "JavaScript",
        "Blazor"
    });

    [HttpGet("groups/{group}")]
    public IActionResult GetGroupMessages(string group, [FromServices] MessagesService messagesService)
        => Ok(messagesService.Messages[group].Select(t => $"{t.Item1}: {t.Item2}").ToList());
}
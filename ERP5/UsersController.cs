using ERP5.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
    {
        var user = new ApplicationUser { Email = dto.Email, UserName = dto.Email, FullName = dto.FullName, Role = dto.Role };
        var result = await _userService.CreateUserAsync(user, dto.Password, dto.Role);
        if (!result.Succeeded) return BadRequest(result.Errors);
        return Ok(user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] UpdateUserDto dto)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) return NotFound();

        user.FullName = dto.FullName;
        user.Role = dto.Role;

        var result = await _userService.UpdateUserAsync(user);
        if (!result.Succeeded) return BadRequest(result.Errors);
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) return NotFound();

        var result = await _userService.DeleteUserAsync(user);
        if (!result.Succeeded) return BadRequest(result.Errors);
        return NoContent();
    }
}

// DTOs
public class CreateUserDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
}
public class UpdateUserDto
{
    public string FullName { get; set; }
    public string Role { get; set; }
}

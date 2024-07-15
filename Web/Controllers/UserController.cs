using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public ActionResult<ICollection<UserResponse>> GetAllUsers()
    {
        try
        {
            var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadToken(token) as JwtSecurityToken;
            var role = jwtToken?.Claims.FirstOrDefault(claim => claim.Type == "role")?.Value;

            if (role != "Admin")
            {
                return Unauthorized("You do not have access to this resource.");
            }

            return Ok(_userService.GetAllUsers());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public ActionResult<UserResponse> GetById([FromRoute] int id)
    {
        try
        {
            return Ok(_userService.GetUserById(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public ActionResult<UserResponse> CreateUser([FromBody] UserCreateRequest user)
    {
        try
        {
            return Ok(_userService.CreateUser(user));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public void UpdateUser([FromRoute] int id, [FromBody] UserCreateRequest user)
    {
        _userService.UpdateUser(id, user);
    }

    [HttpDelete("{id}")]
    public void DeleteUser([FromRoute] int id)
    {
        _userService.DeleteUser(id);
    }
}

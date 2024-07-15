using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;

[Route("api/[controller]")]
[ApiController]
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

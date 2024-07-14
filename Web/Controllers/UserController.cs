using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
    public IActionResult UpdateUser([FromRoute] int id, [FromBody] UserCreateRequest user)
    {
        try
        {
            _userService.UpdateUser(id, user);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteUser([FromRoute] int id)
    {
        try
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

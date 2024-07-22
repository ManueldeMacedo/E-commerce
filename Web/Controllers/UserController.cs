using Application.Interfaces;
using Application.Models.Requests;
using Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using static Infrastructure.Services.AutenticacionService;

[Route("api/[controller]")]
[ApiController]

public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [AuthorizeRoles("Admin")]
    [HttpGet]
    public ActionResult<ICollection<UserResponse>> GetAllUsers()
    {
        try
        {
            return Ok(_userService.GetAllUsers());
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid("Acceso denegado. No tiene los permisos necesarios.");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ha ocurrido un error inesperado. Error: " + ex.Message);
        }
    }

    [AuthorizeRoles("Admin")]
    [HttpGet("{id}")]
    public ActionResult<UserResponse> GetById([FromRoute] int id)
    {
        try
        {
            return Ok(_userService.GetUserById(id));
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid("Acceso denegado. No tiene los permisos necesarios.");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ha ocurrido un error inesperado. Error: " + ex.Message);
        }
    }

    [HttpPost]
    public ActionResult<UserResponse> CreateUser([FromBody] UserCreateRequest user)
    {
        try
        {
            if (!UserCreateRequest.validateDto(user))
                return BadRequest("La solicitud no es válida." +
                    " Verifica que todos los campos requeridos estén presentes y contengan valores adecuados.");

            var existingUser = _userService.GetUserByUserName(user.UserName);

            if (existingUser != null)
                return BadRequest("El usuario ya existe.");

            return Ok(_userService.CreateUser(user));
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ha ocurrido un error inesperado. Error: " + ex.Message);
        }
    }

    [AuthorizeRoles("Admin", "Client")]
    [HttpPut("{id}")]
    public IActionResult UpdateUser([FromRoute] int id, [FromBody] UserCreateRequest user)
    {
        try
        {
            if (!UserCreateRequest.validateDto(user))
                return BadRequest("La solicitud no es válida." +
                    " Verifica que todos los campos requeridos estén presentes y contengan valores adecuados.");

            _userService.UpdateUser(id, user);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ha ocurrido un error inesperado. Error: " + ex.Message);
        }
    }

    [AuthorizeRoles("Admin")]
    [HttpDelete("{id}")]
    public IActionResult DeleteUser([FromRoute] int id)
    {
        try
        {
            _userService.DeleteUser(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (UnauthorizedAccessException)
        {
            return Forbid("Acceso denegado. No tiene los permisos necesarios.");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError,
                "Ha ocurrido un error inesperado. Error: " + ex.Message);
        }
    }
}

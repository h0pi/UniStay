using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniStay.Application.Modules.Catalog.User.Commands.Create;
using UniStay.Application.Modules.Catalog.User.Commands.Delete;
using UniStay.Application.Modules.Catalog.User.Queries.GetById;
using UniStay.Application.Modules.Catalog.User.Queries.List;
using UniStay.Application.Users.Commands.UpdateUser;
using UniStay.Shared.Dtos;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/users
    [HttpGet]
    public async Task<ActionResult<List<UserDTO>>> GetAll()
    {
        var result = await _mediator.Send(new GetAllUsersQuery());
        return Ok(result);
    }

    // GET: api/users/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserDTO>> GetById(int id)
    {
        var result = await _mediator.Send(new GetUserByIdQuery(id));
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    // POST: api/users
    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] CreateUserCommand command)
    {
        var newId = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = newId }, newId);
    }

    //PUT: api/users/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateUserCommand command)
    {
        if (id != command.Id)
            return BadRequest("Id mismatch");

        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE: api/users/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteUserCommand(id));
        return NoContent();
    }
}


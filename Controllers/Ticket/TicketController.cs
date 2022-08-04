using Microsoft.AspNetCore.Mvc;

namespace TicketSystem.Controllers.Ticket;

[Route("[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly ILogger<TicketController> _logger;

    public TicketController(ILogger<TicketController> logger)
    {
        _logger = logger;
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Consumes("application/json")]
    [Route("")]
    [HttpPost]
    public Object Create(Object data)
    {
        return new { };
    }


    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("/{ticketId}")]
    [HttpGet]
    public Object GetOneById(int ticketId)
    {
        return new { };
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("")]
    [HttpGet]
    public Object GetAll()
    {
        return new { };
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Consumes("application/json")]
    [Route("/{ticketId}")]
    [HttpPut]
    public Object UpdateOneById(int ticketId, Object data)
    {
        return new { };
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("/{ticketId}")]
    [HttpDelete]
    public Object DeleteOneById(int ticketId)
    {
        return new { };
    }
}

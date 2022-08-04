using Microsoft.AspNetCore.Mvc;
using TicketSystem.Models.Ticket;
using TicketSystem.Services.Ticket;

namespace TicketSystem.Controllers.Ticket;

[Route("[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly ILogger<TicketController> _logger;
    private readonly TicketService _ticketService = new TicketService();

    public TicketController(ILogger<TicketController> logger)
    {
        _logger = logger;
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Consumes("application/json")]
    [Route("")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTicketModel data)
    {
        if (ModelState.IsValid)
        {
            await _ticketService.Create(data);
            return Created("title", data);
        };

        return BadRequest();
    }


    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("{ID}")]
    [HttpGet]
    public ActionResult<TicketModel> GetOneById(string ID)
    {
        return Ok();
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("")]
    [HttpGet]
    public async Task<ActionResult<TicketModel>> GetAll()
    {
        var tickets = await _ticketService.GetAll();

        return Ok(tickets);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Consumes("application/json")]
    [Route("{ID}")]
    [HttpPut]
    public IActionResult UpdateOneById(string ID, Object data)
    {
        return Ok();
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("{ID}")]
    [HttpDelete]
    public IActionResult DeleteOneById(string ID)
    {
        return Ok();
    }
}

using Microsoft.AspNetCore.Mvc;

namespace TicketSystem.Ticket;

[Route("[controller]")]
[ApiController]
public class TicketController : ControllerBase
{
    private readonly ILogger<TicketController> _logger;
    private readonly TicketService _ticketService;

    public TicketController(ILogger<TicketController> logger)
    {
        _logger = logger;
        _ticketService = new TicketService();
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
            var id = await _ticketService.Create(data);
            return Created("id", new { id = id });
        };

        return BadRequest();
    }


    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("{ID}")]
    [HttpGet]
    async public Task<ActionResult<TicketModel>> GetOneById(string ID)
    {
        var ticket = await _ticketService.GetOneById(ID);
        if (ticket != null)
        {
            return Ok(ticket);
        }

        return NotFound();
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("")]
    [HttpGet]
    public async Task<ActionResult<List<TicketModel>>> GetAll()
    {
        var tickets = await _ticketService.GetAll();
        if (tickets != null)
        {
            return Ok(tickets);
        }

        return NotFound();
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Consumes("application/json")]
    [Route("{ID}")]
    [HttpPut]
    async public Task<IActionResult> UpdateOneById(string ID, [FromBody] UpdateTicketModel data)
    {

        if (ModelState.IsValid)
        {
            var id = await _ticketService.UpdateOneById(ID, data);
            return Created("title", data);
        };

        return BadRequest();
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("{ID}")]
    [HttpDelete]
    async public Task<IActionResult> DeleteOneById(string ID)
    {
        var id = await _ticketService.DeleteOneById(ID);

        if (id != null)
        {
            return Ok();
        }

        return NotFound();
    }
}

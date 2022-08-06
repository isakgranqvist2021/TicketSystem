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
    public IActionResult Create([FromBody] CreateTicketModel data)
    {
        if (ModelState.IsValid)
        {
            var id = _ticketService.Create(data);
            return Created("id", new { id = id });
        };

        return BadRequest(ModelState);
    }


    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("{ID}")]
    [HttpGet]
    public ActionResult<TicketModel> GetOneById(int ID)
    {
        var ticket = _ticketService.GetOneById(ID);
        if (ticket != null)
        {
            return Ok(ticket);
        }

        return NotFound(ModelState);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("")]
    [HttpGet]
    public ActionResult<IEnumerable<TicketModel>> GetAll()
    {
        var tickets = _ticketService.GetAll();
        if (tickets != null)
        {
            return Ok(tickets);
        }

        return NotFound(ModelState);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Consumes("application/json")]
    [Route("{ID}")]
    [HttpPut]
    public IActionResult UpdateOneById(int ID, [FromBody] UpdateTicketModel data)
    {

        if (ModelState.IsValid)
        {
            if (_ticketService.UpdateOneById(ID, data) != null)
            {
                return Ok();
            }

            return NotFound(ModelState);
        };

        return BadRequest(ModelState);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [Route("{ID}")]
    [HttpDelete]
    public IActionResult DeleteOneById(int ID)
    {
        if (_ticketService.DeleteOneById(ID) != null)
        {
            return Ok();
        }

        return NotFound(ModelState);
    }
}

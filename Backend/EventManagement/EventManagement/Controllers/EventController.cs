using EventManagement.Api.Event.Dtos;
using EventManagement.Api.Mappers;
using EventManagement.Models;
using EventManagerProvider;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EventManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly ILogger<EventController> logger;
    private readonly IEventProvider eventProvider;

    public EventController(IEventProvider eventProvider, ILogger<EventController> logger)
    {
        this.eventProvider = eventProvider;
        this.logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<List<EventDTO>>> Get()
    {
        var eventList = await eventProvider.Get();
        logger.Log(LogLevel.Information, "");

        return Ok(eventList.Select(e => e.AsDTO()).ToList());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EventDTO>> GetEventById(int id)
    {
        var Event = await eventProvider.GetEventById(id);
        if (Event == null)
        {
            return NotFound();
        }
        return Event.AsDTO();
    }

    [HttpPost]
    public async Task<HttpStatusCode> Insert(EventDTO EventDTO)
    {
        await eventProvider.Insert(EventDTO.AsModel());
        return HttpStatusCode.Created;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update( int id,EventModel Event)
    {
        await eventProvider.Update(id,Event);
        return Ok(id);
        
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> Delete(int Id)
    {
        await eventProvider.Delete(Id);
        return NoContent();
    }

    [HttpGet("page")]
    public async Task<List<EventModel>> GetPagination([ FromQuery] Paging paginator)
    {
        return await  eventProvider.GetPagination(paginator);
    }

    [HttpGet("searchByName")]
    public async Task<List<EventModel>> SearchByName(string name)
    {
        return await eventProvider.SearchByName(name);
    }
}


using Dadabase.Services;
using Microsoft.AspNetCore.Mvc;
using Dadabase.data;

namespace Dadabase.Controllers;


[ApiController]
[Route("[controller]")]
public class AudienceController(IAudienceService audienceService) : ControllerBase
{
    [HttpGet]
    [EndpointName("GetAudienceList")]
    [EndpointSummary("Retrieves all of the audiences currently in the database")]
    [Route("all")]
    public async Task<IEnumerable<Audience>> GetAudienceList()
    {
        return await audienceService.GetAllAudiencesAsync();
    }


    [HttpPost]
    [EndpointName("AddAudience")]
    [EndpointSummary("Adds an audience to the dadabase")]
    [Route("add")]
    public async Task<IActionResult> AddAudience([FromBody] AudienceDto audienceDto)
    {
        var audience = new Audience
        {
            Audiencename = audienceDto.AudienceName,
            Description = audienceDto.Description
        };

        var result = await audienceService.AddAudienceAsync(audience);
        return Created();
    }

}

public class AudienceDto
{
    public int Id { get; set; }
    public string AudienceName { get; set; }
    public string? Description { get; set; }
}


using Dadabase.Services;
using Microsoft.AspNetCore.Mvc;
using Dadabase.data;

namespace Dadabase.Controllers;


[ApiController]
[Route("[controller]")]
public class AudienceController(IAudienceService audienceService)
{
    [HttpGet]
    [EndpointName("GetAudienceList")]
    [EndpointSummary("Retrieves all of the audiences currently in the database")]
    [Route("/audience/all")]
    public async Task<IEnumerable<Audience>> GetAudienceList()
    {
        return await audienceService.GetAllAudiencesAsync();
    }


    [HttpPost]
    [EndpointName("AddAudience")]
    [EndpointSummary("Adds an audience to the dadabase")]
    [Route("/audience/add")]
    public async Task<IActionResult> AddAudience()
    {
        throw new NotImplementedException();
    }
}

public class AudienceDto
{
    public int Id { get; set; }
    public string AudienceName { get; set; }
    public string? Description { get; set; }
}


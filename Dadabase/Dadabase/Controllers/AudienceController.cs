using Dadabase.Services;
using Microsoft.AspNetCore.Mvc;
using Dadabase.data;

namespace Dadabase.Controllers;


[ApiController]
[Route("[controller]")]
public class AudienceController(AudienceService audienceService)
{
    [HttpGet]
    [EndpointName("GetAudienceList")]
    [EndpointSummary("Retrieves all of the audiences currently in the database")]
    public async Task<ICollection<Audience>> GetAudienceList()
    {
        throw new NotImplementedException();
    }


    [HttpPost]
    [EndpointName("AddAudience")]
    [EndpointSummary("Adds an audience to the dadabase")]
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


using Dadabase.Services;
using Microsoft.AspNetCore.Mvc;

namespace Dadabase.Controllers;


[ApiController]
[Route("[controller]")]
public class AudienceController(IAudienceService audienceService)
{
    [HttpGet]
    [EndpointName("GetAudienceList")]
    [EndpointSummary("Retrieves all of the audiences currently in the database")]
    public string GetAudienceList()
    {
        var list = audienceService.;
    }


    [HttpPost]
    [EndpointName("AddAudience")]
    [EndpointSummary("Adds an audience to the dadabase")]
    public string AddAudience()
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


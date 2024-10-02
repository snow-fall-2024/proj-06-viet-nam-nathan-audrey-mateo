using Microsoft.AspNetCore.Mvc;

namespace Dadabase.Controllers;


[ApiController]
[Route("[controller]")]
public class AudienceController
{
    [HttpGet]
    [EndpointName("GetAudienceList")]
    [EndpointSummary("Retrieves all of the audiences currently in the database")]
    public string GetAudienceList()
    {
        throw new NotImplementedException();
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


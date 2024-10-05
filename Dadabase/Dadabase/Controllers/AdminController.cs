using Microsoft.AspNetCore.Mvc;
using Dadabase.Services;

namespace Dadabase.Controllers;

[ApiController]
[Route("admin")]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpPost("reset")]
    public IActionResult ResetDatabase()
    {
        _adminService.ResetData();
        return Ok();
    }
}

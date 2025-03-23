using Microsoft.AspNetCore.Mvc;
using ScaleAPI.Models;
using ScaleAPI.Services;

namespace ScaleAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ScaleController(ScaleService service) : ControllerBase
{

    private readonly ScaleService _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var scale = await _service.GetAllAsync();
        return Ok(scale);
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var scale = await _service.GetByNameAsync(name);

        if (scale == null)
        {
            return NotFound("Scale not found.");
        }

        return Ok(scale);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Scale scale)
    {
        if (scale == null)
        {
            return BadRequest("Invalid Scale data.");
        }

        await _service.CreateAsync(scale);

        return CreatedAtAction(nameof(GetByName), new { name = scale.Name }, scale);

    }
}


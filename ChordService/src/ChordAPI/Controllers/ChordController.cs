using ChordAPI.Models;
using ChordAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChordAPI.Controllers;

[ApiController]
[Route("api/chords")]
public class ChordController(ChordService service) : ControllerBase
{

    private readonly ChordService _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var chords = await _service.GetAllAsync();
        return Ok(chords);
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetByName(string name)
    {
        var chord = await _service.GetByNameAsync(name);

        if (chord == null)
        {
            return NotFound("Chord not found.");
        }

        return Ok(chord);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Chord chord)
    {
        if (chord == null)
        {
            return BadRequest("Invalid chord data.");
        }

        await _service.CreateAsync(chord);

        return CreatedAtAction(nameof(GetByName), new { name = chord.Name }, chord);

    }
}

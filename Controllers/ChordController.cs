using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuitarAPI.Models;
using GuitarAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GuitarAPI.Controllers
{
    [ApiController]
    [Route("api/chords")]
    public class ChordController : ControllerBase
    {
        private readonly ChordService _service;
        public ChordController(ChordService service)
        {
            _service = service;
        }

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
}
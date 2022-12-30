using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers;

[ApiController]
[Route("api/VillaApi")]
public class VillaApiController : ControllerBase
{
    [HttpGet]
    public IEnumerable<VillaDto> GetVillas()
    {
        return VillaStore.VillaList;
    }

    [HttpGet("{id:int}", Name = "GetCreatedVilla")] // This Name is the name for route
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<VillaDto> GetVilla(int id)
    {
        if (id == 0)
        {
            return BadRequest();
        }

        var villa = VillaStore.VillaList.FirstOrDefault(u => u.Id == id);
        if (villa == null)
        {
            return NotFound();
        }

        return Ok(villa);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<VillaDto> CreateVilla([FromBody] VillaDto villaDto)
    {
        var villaDtoId = VillaStore
            .VillaList.OrderByDescending(u => u.Id).FirstOrDefault()!.Id;
        if (villaDto == null)
        {
            return BadRequest(villaDto);
        }

        if (villaDto.Id < 0 || villaDto.Id <= villaDtoId)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        villaDto.Id = villaDtoId + 1;
        VillaStore.VillaList.Add(villaDto);
        return CreatedAtRoute("GetCreatedVilla", new { id = villaDto.Id }, villaDto);
    }
}
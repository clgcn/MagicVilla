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
        return VillaStore.VillaList();
    }
    
    [HttpGet("{id:int}")]
    public VillaDto GetVilla(int id)
    {
        return VillaStore.VillaList().FirstOrDefault(u => u.Id == id)!;
    }
}
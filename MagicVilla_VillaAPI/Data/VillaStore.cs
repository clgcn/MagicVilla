using System.Collections.Generic;
using MagicVilla_VillaAPI.Models.Dto;

namespace MagicVilla_VillaAPI.Data;

public class VillaStore
{
    public static readonly List<VillaDto> VillaList = new()
    {
        new VillaDto { Id = 1, Name = "Pool View" },
        new VillaDto { Id = 2, Name = "Beach View" }
    };
}
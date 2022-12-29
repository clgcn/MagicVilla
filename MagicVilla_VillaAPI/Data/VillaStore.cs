using MagicVilla_VillaAPI.Models.Dto;

namespace MagicVilla_VillaAPI.Data;

public class VillaStore
{
   public static List<VillaDto> VillaList()
   {
      return new List<VillaDto>
      {
         new() { Id = 1, Name = "Pool View" },
         new() { Id = 2, Name = "Beach View" }
      };
   }
}
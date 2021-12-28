using Lab2.Models;

namespace Lab2.DTOs
{
    public class BasicAnimalTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int NumberOfLegs { get; set; }
    }
    public static class BasicArtistDTOs
    {
        public static BasicAnimalTypeDTO MapToBasicAnimalTypeDTO(this AnimalType animalType)
        {
            return new BasicAnimalTypeDTO
            {
                Id = animalType.Id,
                Name = animalType.Name,
                NumberOfLegs=animalType.NumberOfLegs,
            };
        }
        public static List<BasicAnimalTypeDTO> MapToBasicAnimalTypeDTOs(this List<AnimalType> animalType)
        {
            return animalType.Select(at => at.MapToBasicAnimalTypeDTO()).ToList();
        }
    }
}

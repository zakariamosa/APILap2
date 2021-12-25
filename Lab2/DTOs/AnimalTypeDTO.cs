using Lab2.Models;

namespace Lab2.DTOs
{
    public class AnimalTypeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int NumberOfLegs { get; set; }
        public DateTime Created { get; set; }

        public ICollection<AnimalDTO> Animals { get; set; }
    }
    public static class AnimalTypeDTOExtensions
    {
        public static AnimalTypeDTO MapToAnimalTypeDTO(this AnimalType animalType)
        {
            return new AnimalTypeDTO
            {
                Id= animalType.Id,
                Animals = animalType.Animals.MapToAnimalDTOs(),
                Name = animalType.Name, 
                NumberOfLegs = animalType.NumberOfLegs,
            };
        }
        public static List<AnimalTypeDTO> MapToAnimalTypeDTOs(this List<AnimalType> animalTypes)
        {
            return animalTypes.Select(a => a.MapToAnimalTypeDTO()).ToList();
        }
    }
}

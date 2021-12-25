using Lab2.Models;

namespace Lab2.DTOs
{
    public class AnimalDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }


        public BasicAnimalTypeDTO AnimalType { get; set; }
    }
    public static class AnimalDTOExtensions
    {
        public static AnimalDTO MapToAnimalDTO(this Animal animal)
        {
            return new AnimalDTO
            {
                Id = animal.Id,
                Name = animal.Name,
                DateOfBirth = animal.DateOfBirth,
                AnimalType = animal.AnimalType.MapToBasicAnimalTypeDTO()
            };
        }
        public static List<AnimalDTO> MapToAnimalDTOs(this ICollection<Animal> animals)
        {
             return animals.Select(a=>a.MapToAnimalDTO()).ToList();
        }
    }
}

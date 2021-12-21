using Animal.DTOs;
using Animal.Entities;

namespace Animal.Repo
{
    public interface IAnimal
    {
        List<Entities.Animal> GetAllAnimals();

        Entities.Animal GetAnimalById(int id);
        Entities.Animal CreateEAnimal(CreateAnimalDTO createAnimallDTO);
        Entities.Animal UpdateEAnimal(Entities.Animal entityanimal, int id);
        void DeleteAnimalById(int id);
    }
}

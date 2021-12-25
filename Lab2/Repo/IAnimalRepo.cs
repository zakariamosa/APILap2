using Lab2.Models;

namespace Lab2.Repo
{
    public interface IAnimalRepo
    {
        List<Animal> GetAll();
        Animal GetByID(int id);

        Animal CreateAnimal(CreateAnimalDTO Animal);

        Animal UpdateAnimal(Animal Animal, int id);

        void DeleteAnimal(int id);
    }
}

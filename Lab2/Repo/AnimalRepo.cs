using Animal.DTOs;
using Animal.Entities;

namespace Animal.Repo
{
    public class AnimalRepo : IAnimal
    {
        private List<Entities.Animal> _animals;
        public AnimalRepo()
        {
            _animals = populatedummydata();
        }
        public Entities.Animal CreateEAnimal(CreateAnimalDTO createAnimallDTO)
        {
            Entities.Animal animal = new Entities.Animal();

            
            animal.AnimalType = createAnimallDTO.AnimalType;
            animal.Name = createAnimallDTO.Name;
            animal.Id = _animals.Max(x => x.Id) + 1;
            _animals.Add(animal);

            return animal;
        }


        public void DeleteAnimalById(int id)
        {
            var deleteAnimal =_animals.Find(x => x.Id == id);
            _animals.Remove(deleteAnimal);
        }

        public List<Entities.Animal> GetAllAnimals()
        {
            return _animals;
        }

        public Entities.Animal GetAnimalById(int id)
        {
            return _animals.Find(a => a.Id == id);
        }

        public Entities.Animal UpdateEAnimal(Entities.Animal entityanimal, int id)
        {
            Entities.Animal existingAnimal = _animals.FirstOrDefault(x => x.Id == id);
            if (existingAnimal is not null)
            {
                existingAnimal.AnimalType = entityanimal.AnimalType;
                existingAnimal.Name = entityanimal.Name;
            }
           
            return existingAnimal;
        }

        private List<Entities.Animal> populatedummydata()
        {
            return _animals = new List<Entities.Animal>()
            {
                new Entities.Animal(){
                Id = 1,
                AnimalType = "vildadjur",
                Name = "Lion",
                },
                new Entities.Animal(){
                Id = 2,
                AnimalType = "husdjur",
                Name = "Cat",
                },
                new Entities.Animal(){
                Id = 3,
                AnimalType = "vildadjur",
                Name = "Tiger",
                },
                new Entities.Animal(){
                Id = 4,
                AnimalType = "vildadjur",
                Name = "elefant",
                },
                new Entities.Animal(){
                Id = 5,
                AnimalType = "husdjur",
                Name = "dog",}
            };
        }
    }
}

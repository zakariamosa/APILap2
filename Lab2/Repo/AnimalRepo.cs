using Lab2.DTOs;
using Lab2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Repo
{
    public class AnimalRepo : IAnimalRepo
    {
        private AnimalsContext _context;
        public AnimalRepo(AnimalsContext context)
        {
            _context = context;
        }
        public Animal CreateAnimal(CreateAnimalDTO createdanimaldto)
        {
            Animal animal = new Animal
            {
                Name = createdanimaldto.AnimalName,
                AnimalTypeId = createdanimaldto.AnimalTypeId,
                DateOfBirth = createdanimaldto.DateOfBirthDay
            };
            _context.Animals.Add(animal);
            _context.SaveChanges();
            return animal;
        }

        public void DeleteAnimal(int id)
        {
            _context.Animals.Remove(GetByID(id));
            _context.SaveChanges();
        }

        public ICollection<Animal> GetAll()
        {
            return _context.Animals.Include(a=>a.AnimalType).ToList();
        }

        public Animal GetByID(int id)
        {
            return _context.Animals.Include(a=>a.AnimalType).FirstOrDefault(x => x.Id == id);
        }

        public Animal UpdateAnimal(Animal Animal, int id)
        {
            Animal existingAnimal=_context.Animals.FirstOrDefault(app=> app.Id == id);
            if (existingAnimal != null)
            {
                existingAnimal.Name = Animal.Name;
                existingAnimal.AnimalTypeId= Animal.AnimalTypeId;
                existingAnimal.DateOfBirth = Animal.DateOfBirth;
            }
            _context.SaveChanges();
            return existingAnimal;
        }
    }
}

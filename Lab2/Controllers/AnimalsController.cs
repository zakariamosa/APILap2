#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab2.Models;
using Lab2.Repo;
using Lab2.DTOs;

namespace Lab2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IAnimalRepo _repo;

        public AnimalsController(IAnimalRepo repo)
        {
            _repo = repo;
        }

        // GET: api/Animals
        [HttpGet]
        public  IActionResult GetAnimals()
        {
            //return await _context.Animals.ToListAsync();
            var animals=   _repo.GetAll().ToList().MapToAnimalDTOs();
            return Ok(animals);
        }

        // GET: api/Animals/5
        [HttpGet("{id}")]
        public IActionResult GetAnimal(int id)
        {
            var animal = _repo.GetByID(id);

            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }

        // PUT: api/Animals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutAnimal(int id, [FromBody] Animal animal)
        {
            var updatedanimal=_repo.UpdateAnimal(animal,id);
            var animaldto = updatedanimal.MapToAnimalDTO();
            return Ok(animaldto);
        }

        // POST: api/Animals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public IActionResult PostAnimal([FromBody] CreateAnimalDTO createAnimalDTO)
        {
            Animal createdAnimal = _repo.CreateAnimal(createAnimalDTO);
            //AnimalDTO AnimalDTO= MapAnimalToAnimalDTO(createdAnimal);
            AnimalDTO AnimalSavedDTO = _repo.GetByID(createdAnimal.Id).MapToAnimalDTO();
            return CreatedAtAction(nameof(GetAnimal), new { id = AnimalSavedDTO.Id }, AnimalSavedDTO);
        }

        // DELETE: api/Animals/5
        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            _repo.DeleteAnimal(id);
            return NoContent();
        }

        private bool AnimalExists(int id)
        {
            return _repo.GetAll().ToList().Any(e => e.Id == id);
        }
    }
}

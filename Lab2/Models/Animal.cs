using System;
using System.Collections.Generic;

namespace Lab2.Models
{
    public partial class Animal
    {
        public int Id { get; set; }
        public int AnimalTypeId { get; set; }
        public string Name { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }

        public virtual AnimalType AnimalType { get; set; } = null!;
    }
}

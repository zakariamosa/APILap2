using System;
using System.Collections.Generic;

namespace Lab2.Models
{
    public partial class AnimalType
    {
        public AnimalType()
        {
            Animals = new HashSet<Animal>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int NumberOfLegs { get; set; }
        public DateTime Created { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}

﻿namespace AnimalHealthBookApi.Models
{
    public class AnimalType
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Breed> Breeds { get; set; }
    }
}

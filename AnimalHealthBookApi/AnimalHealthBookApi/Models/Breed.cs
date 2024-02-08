﻿namespace AnimalHealthBookApi.Models
{
    public class Breed
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public AnimalType AnimalType { get; set; }
    }
}

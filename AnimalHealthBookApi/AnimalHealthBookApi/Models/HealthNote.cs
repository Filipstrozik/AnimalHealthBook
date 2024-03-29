﻿namespace AnimalHealthBookApi.Models
{
    public class HealthNote
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid AnimalId { get; set; }
        public Animal Animal { get; set; }

        public Mood Mood { get; set; }
    }

    public enum Mood
    {
        Happy,
        Sad,
        Angry,
        Anxious,
        Excited,
        Scared,
        Bored,
        Tired,
        Sick
    }
}

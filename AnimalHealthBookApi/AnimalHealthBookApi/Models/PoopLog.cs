namespace AnimalHealthBookApi.Models
{
    public class PoopLog
    {
        public Guid Id { get; set; }
        public Guid AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }

        // Additional properties for poop details
        public PoopColor Color { get; set; }
        public PoopSize Size { get; set; }
        public PoopSmell Smell { get; set; }
        public PoopForm Form { get; set; }

    }


    public enum PoopColor
    {
        Yellow,
        Black,
        Brown,
        Green,
        Red
    }

    public enum PoopSize
    {
        Little,
        Small,
        Medium,
        Large,
        Huge
    }

    public enum PoopSmell
    {
        Mild,
        Strong,
        Foul
    }

    public enum PoopForm
    {
        Hard,
        Solid,
        Soft,
        Runny,
        Diarrhea
    }
}

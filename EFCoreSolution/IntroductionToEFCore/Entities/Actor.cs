namespace IntroductionToEFCore.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Furtune { get; set; }
        public DateTime Birthday { get; set; }
    }
}

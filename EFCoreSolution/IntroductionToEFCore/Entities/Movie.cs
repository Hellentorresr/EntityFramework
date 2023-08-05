namespace IntroductionToEFCore.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool OnListing { get; set; }
        public DateTime MovieReleaseDate { get; set; }
    }
}

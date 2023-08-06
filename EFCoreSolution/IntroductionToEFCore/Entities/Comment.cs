namespace IntroductionToEFCore.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string? Content { get; set; }  //optional
        public bool Recommend { get; set; }

        //Adding the relationship with movie, one to many 1 movie many comments
        //By convention i need to have a navigation property
        public int MovieId { get; set; }  // Foreign key property
        public Movie Movie { get; set; } = null!; // Reference navigation to principal
    }
}

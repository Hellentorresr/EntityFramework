namespace IntroductionToEFCore.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool OnListing { get; set; }
        public DateTime MovieReleaseDate { get; set; }

       // Adding the relationship with movie, one to many 1 movie many comments
       //adding the navigation property 
       public HashSet<Comment> Comments { get; set; } = new HashSet<Comment>(); //I'm using this collection cause is faster when it comes to get a hash value

        //setting a navigation property, many to many relationship with Genre
        public HashSet<FilmGenre> FilmGenres { get; set;} = new HashSet<FilmGenre>();

        //setting the relationship many to many with MovieActor table
        public List<MovieActor> MovieActors { get; set;} = new List<MovieActor>(); //List, because I need to order movieActor
    }
}

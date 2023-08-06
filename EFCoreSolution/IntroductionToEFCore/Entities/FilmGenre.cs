using System.ComponentModel.DataAnnotations;

namespace IntroductionToEFCore.Entities
{
    public class FilmGenre
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!; //wont be null, just to avoid getting the alert

      //setting a navigation property, many to many relationship with Movie
     public HashSet<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}

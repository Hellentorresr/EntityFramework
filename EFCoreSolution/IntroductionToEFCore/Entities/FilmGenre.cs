using System.ComponentModel.DataAnnotations;

namespace IntroductionToEFCore.Entities
{
    public class FilmGenre
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!; //wont be null, just to avoid getting the alert
    }  
}

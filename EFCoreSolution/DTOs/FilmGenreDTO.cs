
using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class FilmGenreDTO
    {
        //ASP Net Core will validate this maximumLength att
        [StringLength(maximumLength: 150)]
        public string Name { get; set; } = null!;
    }
}

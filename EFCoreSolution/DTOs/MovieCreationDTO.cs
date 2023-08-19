using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class MovieCreationDTO
    {
        public string Name { get; set; } = null!;
        public bool OnListing { get; set; }
        public DateTime MovieReleaseDate { get; set; }

        //to relate a movie to a genre, only the Id type int is need it
        public List<int> Genres { get; set; }  = new List<int>();

        //I added a DTO to collect this data
        public List<MovieActorCreationDTO> MovieActorCreationDTOs { get; set; } = new List<MovieActorCreationDTO>();
    }
}

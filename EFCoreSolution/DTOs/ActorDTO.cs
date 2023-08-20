using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ActorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Furtune { get; set; }
        public DateTime Birthday { get; set; }
    }
}

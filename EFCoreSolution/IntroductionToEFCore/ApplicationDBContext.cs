using Microsoft.EntityFrameworkCore;

namespace IntroductionToEFCore
{
    public class ApplicationDBContext : DbContext 
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) { 
            
        }
    }
}

using Microsoft.EntityFrameworkCore;
using taskman_backend.Models;

namespace taskman_backend.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Board> Boards { get; set; }

        public DbSet<CardList> CardLists { get; set; }

        public DbSet<Card> Cards { get; set; }
    }
}

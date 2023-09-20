using LibraryProject.Models;
using System.Data.Entity;

namespace LibraryProject.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext()
            : base("name=LibraryDbContext") { }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Item> Items { get; set; }
    }
}
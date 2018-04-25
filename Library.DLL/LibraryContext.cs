using Library.DLL.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;


namespace Library.DLL
{
    public class LibraryContext : DbContext
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Magazine> Magazines { get; set; }
        public virtual DbSet<Brochure> Brochures { get; set; }
        public virtual DbSet<PublicHouse> PublicHouses { get; set; }

        public LibraryContext(string connectionString)
                    : base("LibraryContext")
        {

        }
        public LibraryContext()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(b => b.PublicHouses)
                .WithMany(p => p.Books);     
        }
    }
}

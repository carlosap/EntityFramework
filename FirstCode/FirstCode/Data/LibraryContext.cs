using FirstCode.Models;
using Microsoft.EntityFrameworkCore;
namespace FirstCode.Data
{
    public class LibraryContext: DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            :base (options)
        {
        }
        public DbSet<Author> Author { get; set; }
        public DbSet<Book> Book { get; set; }

    }
}

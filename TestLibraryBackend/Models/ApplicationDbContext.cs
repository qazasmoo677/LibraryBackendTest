using Microsoft.EntityFrameworkCore;

namespace TestLibraryBackend.Models {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "1984", Author = "George Orwell", PublicationYear = 1949 },
                new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", PublicationYear = 1960 }
            );
        }
    }
}
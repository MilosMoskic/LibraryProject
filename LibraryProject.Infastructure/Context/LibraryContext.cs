using LibraryProject.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Infastructure.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookRent> BookRents { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>()
            .HasMany(s => s.Books)
            .WithMany(c => c.Authors)
            .UsingEntity<Dictionary<string, object>>(
                "AuthorBook",
                e => e
                    .HasOne<Book>()
                    .WithMany()
                    .HasForeignKey("BookId"),
                e => e
                    .HasOne<Author>()
                    .WithMany()
                    .HasForeignKey("AuthorId"));

            modelBuilder.Entity<BookRent>()
                .HasKey(up => new { up.ID });

            modelBuilder.Entity<BookRent>()
                .HasOne(r => r.User)
                .WithMany(u => u.BookRents)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<BookRent>()
                .HasOne(r => r.Book)
                .WithMany(b => b.BookRents)
                .HasForeignKey(r => r.BookId);

            modelBuilder.Entity<BookReview>()
                .HasKey(br => new { br.UserId, br.BookId });

            modelBuilder.Entity<BookReview>()
                .HasOne(b => b.Book)
                .WithMany(br => br.BookReviews)
                .HasForeignKey(b => b.BookId);

            modelBuilder.Entity<BookReview>()
                .HasOne(u => u.User)
                .WithMany(r => r.BookReviews)
                .HasForeignKey(u => u.UserId);

            base.OnModelCreating(modelBuilder);
            var user = new User
            {
                ID = 5,
                Username = "Admin",
                Password = "Adminpass1!",
                Email = "admin@example.com",
                Role = "Admin"
            };
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);
            user.Password = passwordHash;
            modelBuilder.Entity<User>().HasData(user);
        }
    }
}

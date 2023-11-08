using System.Reflection.Metadata;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using ProjektBibliotekaMVC.Models;

namespace ProjektBibliotekaMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCopy> BooksCopies { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<BorrowHistory> BorrowsHistory { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Limit> Limits { get; set; }
        public DbSet<News> Newses { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<SearchHistory> SearchesHistory { get; set; }
        public DbSet<Tag> Tags { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //BookCopy
            modelBuilder.Entity<Book>()
                .HasMany(e => e.BookCopies)
                .WithOne(e => e.Book)
                .HasForeignKey(e => e.Id)
                .IsRequired();
            //Borrow
            modelBuilder.Entity<BookCopy>()
                .HasOne(e => e.Borrow)
                .WithOne(e => e.BookCopy)
                .HasForeignKey<Borrow>(e => e.Id)
                .IsRequired();
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Borrows)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.Id)
                .IsRequired();
            //BorrowHistory
            modelBuilder.Entity<Book>()
                .HasMany(e => e.BorrowsHistory)
                .WithOne(e => e.Book)
                .HasForeignKey(e => e.Id)
                .IsRequired();
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.BorrowsHistory)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.Id)
                .IsRequired();
            //Carts
            modelBuilder.Entity<Book>()
                .HasMany(e => e.Carts)
                .WithOne(e => e.Book)
                .HasForeignKey(e => e.Id)
                .IsRequired();
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Carts)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.Id)
                .IsRequired();
            //Category
            modelBuilder.Entity<Category>()
                .HasMany(e => e.ChildCategories)
                .WithOne(e => e.ParentCategory)
                .HasForeignKey(e => e.Id);
            //Queue
            modelBuilder.Entity<Book>()
                .HasMany(e => e.Queues)
                .WithOne(e => e.Book)
                .HasForeignKey(e => e.Id)
                .IsRequired();
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Queues)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.Id)
                .IsRequired();
            //BorrowHistory
            modelBuilder.Entity<Book>()
                .HasMany(e => e.SearchesHistory)
                .WithOne(e => e.Book)
                .HasForeignKey(e => e.Id)
                .IsRequired();
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.SearchesHistory)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.Id)
                .IsRequired();
            //BookTag
            modelBuilder.Entity<Book>()
            .HasMany(e => e.Tags)
            .WithMany(e => e.Books)
            .UsingEntity(
                "BookTag",
                l => l.HasOne(typeof(Tag)).WithMany().HasForeignKey("IdTag").HasPrincipalKey(nameof(Tag.Id)),
                r => r.HasOne(typeof(Book)).WithMany().HasForeignKey("IdPost").HasPrincipalKey(nameof(Book.Id)),
                j => j.HasKey("IdTag", "IdPost"));
        }
    }
}
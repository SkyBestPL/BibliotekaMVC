using ProjektBibliotekaMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ProjektBibliotekaMVC.Utility;

namespace ProjektBibliotekaMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, Role, string,
        IdentityUserClaim<string>, UserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    //public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Book>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Books)
                .UsingEntity(
                    "BookTag",
                    l => l.HasOne(typeof(Tag)).WithMany().HasForeignKey("IdTag").HasPrincipalKey(nameof(Tag.Id)),
                    r => r.HasOne(typeof(Book)).WithMany().HasForeignKey("IdBook").HasPrincipalKey(nameof(Book.Id)),
                    j => j.HasKey("IdBook", "IdTag"));
            modelBuilder.Entity<Book>()
                .HasMany(e => e.BorrowsHistory)
                .WithOne(e => e.Book)
                .HasForeignKey(e => e.IdBook)
                .IsRequired();
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.BorrowsHistory)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .HasMany(e => e.BookCopies)
                .WithOne(e => e.Book)
                .HasForeignKey(e => e.IdBook)
                .IsRequired();
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.BorrowsHistory)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .IsRequired();
            modelBuilder.Entity<BookCopy>()
                .HasOne(e => e.Borrow)
                .WithOne(e => e.BookCopy)
                .HasForeignKey<Borrow>(e => e.IdBookCopy)
                .IsRequired();
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Borrows)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .HasMany(e => e.Carts)
                .WithOne(e => e.Book)
                .HasForeignKey(e => e.IdBook)
                .IsRequired();
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Carts)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .IsRequired();
            modelBuilder.Entity<Book>()
                .HasMany(e => e.SearchesHistory)
                .WithOne(e => e.Book)
                .HasForeignKey(e => e.IdBook)
                .IsRequired();
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.SearchesHistory)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .IsRequired();
            //modelBuilder.Entity<Category>()
            //    .HasMany(e => e.ChildCategories)
            //    .WithOne(e => e.ParentCategory)
            //    .HasForeignKey(e => e.IdParentCategory)
            //    .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<BookCopy>()
                .HasOne(e => e.WaitingBook)
                .WithOne(e => e.BookCopy)
                .HasForeignKey<WaitingBook>(e => e.IdBookCopy)
                .IsRequired();
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(e => e.WaitingBooks)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .IsRequired();
            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            });

            modelBuilder.Entity<Role>(b =>
            {
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();
            });

            Seed(modelBuilder);
        }
        private void Seed(ModelBuilder builder)
        {
            var adminUser = new ApplicationUser()
            {
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                PasswordHash = "AQAAAAIAAYagAAAAEPUNEAqcNcxGGHdqJaBhLcNgI80cGZXZUhMi7wKsptS9IJTF6BzFh8AlQAaDSqeA5g==",
                EmailConfirmed = true
            };
            var rolAdmin = new Role()
            {
                Name = SD.RoleUserAdmin,
                NormalizedName = SD.RoleUserAdmin
            };

            var employeeRole = new Role()
            {
                Name = SD.RoleUserEmployee,
                NormalizedName = SD.RoleUserEmployee
            };

            var customerRole = new Role()
            {
                Name = SD.RoleUserCustomer,
                NormalizedName = SD.RoleUserCustomer
            };
            builder.Entity<Role>().HasData(rolAdmin, employeeRole, customerRole);
            builder.Entity<ApplicationUser>().HasData(adminUser);

            var userRoleAdmin = new UserRole()
            {
                RoleId = rolAdmin.Id,
                UserId = adminUser.Id
            };

            builder.Entity<UserRole>().HasData(userRoleAdmin);

            var limit = new Limit();
            limit.Id= 1;
            limit.WaitingLimit = 100;
            limit.InMagazineLimit = 100;
            builder.Entity<Limit>().HasData(limit);
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<BorrowHistory> BorrowsHistory { get; set; }
        public DbSet<BookCopy> BooksCopies { get; set; }
        public DbSet<Queue> Queues { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<SearchHistory> SearchesHistory { get; set; }
        public DbSet<News> Newses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Limit> Limits { get; set; }
        public DbSet<WaitingBook> WaitingBook { get; set; } = default!;
    }
}
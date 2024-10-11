using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DemostrateFACTS.Data
{
    public class User
    {
        public int UserID { get; set; }
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        [EmailAddress]
        public string UserEmail { get; set; }
        [MinLength(6)]
        public string Password { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime DateLastUpdated { get; set; }
    }

    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

        public DbSet<User> UserMaster { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserID);

            modelBuilder.Entity<User>()
                .Property(u => u.UserID)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    UserID = 1,
                    UserType = "Admin",
                    FirstName = "Enzo",
                    FamilyName = "He",
                    UserEmail = "admin@gmail.com",
                    Password = "admin123",
                    DateJoined = new DateTime(2023, 01, 01),
                    DateLastUpdated = new DateTime(2023, 01, 01)
                },
                new User
                {
                    UserID = 2,
                    UserType = "User",
                    FirstName = "John",
                    FamilyName = "Doe",
                    UserEmail = "user1@gmail.com",
                    Password = "user123",
                    DateJoined = new DateTime(2023, 01, 01),
                    DateLastUpdated = new DateTime(2023, 01, 01)
                },
                new User
                {
                    UserID = 3,
                    UserType = "User",
                    FirstName = "Frank",
                    FamilyName = "Smith",
                    UserEmail = "user2@gmail.com",
                    Password = "user2password",
                    DateJoined = new DateTime(2023, 01, 01),
                    DateLastUpdated = new DateTime(2023, 01, 01)
                },
                new User
                {
                    UserID = 4,
                    UserType = "User",
                    FirstName = "Alice",
                    FamilyName = "Yang",
                    UserEmail = "user3@gmail.com",
                    Password = "user3password",
                    DateJoined = new DateTime(2023, 01, 01),
                    DateLastUpdated = new DateTime(2023, 01, 01)
                }
            );
        }

    }



}

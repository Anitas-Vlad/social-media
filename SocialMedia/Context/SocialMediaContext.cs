using Microsoft.EntityFrameworkCore;
using SocialMedia.Models;

namespace SocialMedia.Context;

public class SocialMediaContext :DbContext
{
    public SocialMediaContext(DbContextOptions<SocialMediaContext> options) : base(options)
    { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ModelBuilderExtensions.Seed(modelBuilder);
    }
    
    public DbSet<User> Users { get; set; } = default!;
    
    private static class ModelBuilderExtensions
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1000,
                    UserName = "AAAAA",
                    Email = "a@a.a",
                    PasswordHash = "AAAAAA"
                },
                new User
                {
                    Id = 1001,
                    UserName = "BBBBB",
                    Email = "b@b.b",
                    PasswordHash = "BBBBB"
                },
                new User
                {
                    Id = 1002,
                    UserName = "CCCCC",
                    Email = "c@c.c",
                    PasswordHash = "CCCCC"
                }
            );
        }
    }
}
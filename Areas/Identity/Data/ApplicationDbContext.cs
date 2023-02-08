using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Areas.Identity.Data;
using SocialMedia.Models;
using System.Reflection.Emit;

namespace SocialMedia.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Reaction> Reactions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Maping Enum to String
        base.OnModelCreating(builder);
        builder.Entity<Reaction>()
            .Property(r => r.reactionType)
            .HasConversion<string>();

        //Seed Data

        //Seed Roles
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Id = "2c5e174e-3b0e-446f-86af-483d56fd7211",
                Name = "User",
                NormalizedName = "USER"
            }
        );
        //Seed Admin and User
        var hasher = new PasswordHasher<ApplicationUser>();
        builder.Entity<ApplicationUser>().HasData(
            new ApplicationUser
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                UserName = "admin@admin.admin",
                NormalizedUserName = "ADMIN@ADMIN.ADMIN",
                PasswordHash = hasher.HashPassword(null, "admin"),
                Email = "admin@admin.admin",
                NormalizedEmail = "ADMIN@ADMIN.ADMIN",
                PhoneNumber = "123456789",
                FirstName = "Admin",
                LastName = "Admin"
            },
            new ApplicationUser
            {
                Id = "8e445865-a24d-4543-a6c6-9443d048cdb8",
                UserName = "user@user.user",
                NormalizedUserName = "USER@USER.USER",
                PasswordHash = hasher.HashPassword(null, "user"),
                Email = "user@user.user",
                NormalizedEmail = "USER@USER.USER",
                PhoneNumber = "987654321",
                FirstName = "User",
                LastName = "User"
            }
         );
        //Add roles for Admin and User
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
            },
            new IdentityUserRole<string>
            {
                RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7211",
                UserId = "8e445865-a24d-4543-a6c6-9443d048cdb8"
            }
        );
    }
}

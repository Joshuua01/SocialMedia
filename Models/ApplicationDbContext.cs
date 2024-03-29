﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Models;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //Post Comment on delete cascade
        builder.Entity<Post>()
            .HasMany(p => p.Comments)
            .WithOne(c => c.post)
            .OnDelete(DeleteBehavior.Cascade);
        //Category Post on delete cascade
        builder.Entity<Category>()
            .HasMany(c => c.Posts)
            .WithOne(c => c.category)
            .OnDelete(DeleteBehavior.Cascade);

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

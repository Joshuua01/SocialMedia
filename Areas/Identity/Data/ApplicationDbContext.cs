using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Areas.Identity.Data;
using SocialMedia.Models;

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
        base.OnModelCreating(builder);
        builder.Entity<Reaction>()
            .Property(r => r.reactionType)
            .HasConversion<string>();

        /* builder.Entity<IdentityRole>().HasData(
             new IdentityRole
             {
                 Id = "1",
                 Name = "Admin",
                 NormalizedName = "ADMIN"
             },
             new IdentityRole
             {
                 Id = "2",
                 Name = "User",
                 NormalizedName = "USER"
             }
         );*/


    }
}

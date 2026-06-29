using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Holix.Models;

namespace Holix.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public new DbSet<User> Users { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<FaqItem> FaqItems { get; set; }
    public DbSet<ContactMessage> ContactMessages { get; set; }
    public DbSet<BlogPost> BlogPosts { get; set; }
}

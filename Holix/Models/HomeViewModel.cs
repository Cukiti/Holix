namespace Holix.Models;

public class HomeViewModel
{
    public List<Service> Services { get; set; } = new();
    public List<Project> Projects { get; set; } = new();
    public List<Testimonial> Testimonials { get; set; } = new();
    public List<FaqItem> Faqs { get; set; } = new();
    public List<BlogPost> BlogPosts { get; set; } = new();

    // For the contact form
    public ContactMessage Contact { get; set; } = new();
}

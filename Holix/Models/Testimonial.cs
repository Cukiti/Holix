namespace Holix.Models;

public class Testimonial
{
    public int Id { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string AvatarUrl { get; set; } = string.Empty;
    public int Rating { get; set; } = 5;
}

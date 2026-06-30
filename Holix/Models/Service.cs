namespace Holix.Models;

public class Service
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty; 
    public string Description { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string FullDescription { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}

namespace Holix.Models;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string ClientName { get; set; } = string.Empty;
    public string Client { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Excerpt { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Technologies { get; set; } = string.Empty;
    public DateTime CompletedAt { get; set; } = DateTime.UtcNow;
    public bool IsPublished { get; set; } = true;
    public int Views { get; set; } = 0;
}

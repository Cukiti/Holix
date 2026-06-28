namespace Holix.Models;

public class FaqItem
{
    public int Id { get; set; }
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public int Order { get; set; } = 0;
    public bool IsActive { get; set; } = true;
}

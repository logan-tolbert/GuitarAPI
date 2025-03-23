namespace ScaleAPI.Models;

public class Scale
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // e.g., "Major", "Pentatonic"
    public string ScaleKey { get; set; } = string.Empty;  // e.g., "C", "A", "G#"
    public string Tuning { get; set; } = "EADGBE";  // Default standard tuning
    public string Notes { get; set; } = string.Empty; // e.g., "C,D,E,F,G,A,B"
}


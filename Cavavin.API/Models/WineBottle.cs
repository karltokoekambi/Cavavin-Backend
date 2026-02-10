namespace Cavavin.API.Models;

public class WineBottle
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string Castle { get; set; } = string.Empty;
    public int Year { get; set; }
    public string Color { get; set; } = string.Empty; // Rouge, Blanc, Rosé
    public int Quantity { get; set; }
}
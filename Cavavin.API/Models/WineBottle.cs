using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cavavin.API.Models;

[Table("wine_bottles")]
public class WineBottle
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [Column("domain")]
    [Required, MaxLength(100)]
    public string Domain { get; set; } = string.Empty;

    [Column("vintage")]
    public int Vintage { get; set; }

    [Column("start_maturity")]
    public int StartMaturity { get; set; }
    [Column("end_maturity")]
    public int EndMaturity { get; set; }
    
    [Column("region")]
    [Required]
    public WineRegion Region { get; set; }
    
    [Column("type")]
    [Required]
    public WineType Type { get; set; }
    
    [Column("food_pairing_keywords")]
    [MaxLength(500)]
    public string FoodPairingKeywords { get; set; } = string.Empty; // ex: "viande rouge, agneau, fromage"
    
    [Column("is_favorite")]
    public bool IsFavorite { get; set; }
    
    [Column("quantity")]
    public int Quantity { get; set; }
}

public enum WineType
{
    Red,
    White,
    Rosé,
    Sparkling,
    Sweet
}

public enum WineRegion
{
    Alsace,
    Bordeaux,
    Bourgogne,
    Champagne,
    LanguedocRoussillon,
    Loire,
    Provence,
    Rhone,
    SudOuest,
    SavoieJura,
    Autre
}
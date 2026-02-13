using System.ComponentModel.DataAnnotations;

namespace OptionsDemo.Configuration;

public class ValidatedConfig
{
    public const string SectionName = "SmallShipment";
    
    [Required]
    [Range(0, 25)]
    public int Weight { get; set; }
    
    [Required]
    public bool IsFull { get; set; }
    
    public string ShipmentCode { get; set; }
    
    public string TrackingUrl { get; set; }
    
    public static readonly Func<ValidatedConfig, bool> ValidateIsFull = config =>
    {
        if (config.IsFull) return config.Weight == 25;
        return config.Weight < 25;
    };

    public static readonly Func<ValidatedConfig, bool> ValidateShipmentCode = config =>
        long.TryParse(config.ShipmentCode, out _);
    
    public static readonly Func<ValidatedConfig, bool> ValidateTrackingUrl = config =>
        Uri.TryCreate(config.TrackingUrl, UriKind.Absolute, out _);
}
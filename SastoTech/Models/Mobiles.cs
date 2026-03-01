namespace SastoTech.Models;

public class Mobiles
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double DiscountedPrice { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Processor { get; set; }
    public string Ram { get; set; }
    public string Storage { get; set; }
    public string ScreenSize { get; set; }
    public string Battery { get; set; }
    public string Camera { get; set; }
    public string AffilitedUrl { get; set; }
    public double DiscountPercentage { get; set; }
    public double ActualPrice { get; set; }
    public bool IsAvailable { get; set; }
    public bool IsRecordLow { get; set; }
    public float LowestPriceEver { get; set; }
}
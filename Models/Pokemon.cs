namespace Proyecto_final_entorns.Models;

public class Pokemon
{
    public int    Id       { get; set; }
    public string Name     { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;

    public decimal HeightM  { get; set; } 
    public decimal WeightKg { get; set; } 

    public List<string> Types     { get; set; } = new();
    public List<string> Abilities { get; set; } = new();

    public Dictionary<string, int> BaseStats { get; set; } = new();

    public string Flavor { get; set; } = string.Empty;
}

namespace Proyecto_final_entorns.Models;

public class Pokemon
{
    public int    Id       { get; set; }
    public string Name     { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;

    // Datos físicos
    public decimal HeightM  { get; set; }          // metros
    public decimal WeightKg { get; set; }          // kilogramos

    // Listas
    public List<string> Types     { get; set; } = new();
    public List<string> Abilities { get; set; } = new();

    // Estadísticas base (HP, Attack, Defense…)
    public Dictionary<string, int> BaseStats { get; set; } = new();

    // Texto de la Pokédex
    public string Flavor { get; set; } = string.Empty;
}

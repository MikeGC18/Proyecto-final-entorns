namespace Proyecto_final_entorns.Models;

public class Digimon
{
    public int    Index   { get; set; }               // Nº en la lista
    public string Name    { get; set; } = string.Empty;
    public string Level   { get; set; } = string.Empty; // Inglés
    public string LevelEs { get; set; } = string.Empty; // Español
    public string Img     { get; set; } = string.Empty;
}

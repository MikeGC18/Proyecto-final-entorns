using Proyecto_final_entorns.Models;
using Newtonsoft.Json.Linq;

namespace Proyecto_final_entorns.Services;

public class DigimonApiService : IDigimonApiService
{
    private readonly HttpClient _http;
    public DigimonApiService(HttpClient http) => _http = http;

    // Traducción de niveles (EN → ES)
    private static readonly Dictionary<string, string> _nivelesEs = new()
    {
        ["Fresh"]       = "Bebé",
        ["In Training"] = "Entrenamiento",
        ["Training"]    = "Entrenamiento II",
        ["Rookie"]      = "Novel",
        ["Champion"]    = "Campeón",
        ["Ultimate"]    = "Definitivo",
        ["Mega"]        = "Mega"
    };

    // ─────────────────────────────────────────────────────────────
    // Obtener un Digimon por nombre
    // ─────────────────────────────────────────────────────────────
    public async Task<Digimon?> GetAsync(string name)
    {
        var list = JArray.Parse(await _http.GetStringAsync(string.Empty));
        var tok  = list.FirstOrDefault(d =>
                     string.Equals((string)d["name"]!, name,
                                   StringComparison.OrdinalIgnoreCase));

        return tok is null ? null : Map(tok, list.IndexOf(tok) + 1);
    }

    // ─────────────────────────────────────────────────────────────
    // Obtener un Digimon aleatorio
    // ─────────────────────────────────────────────────────────────
    public async Task<Digimon> GetRandomAsync()
    {
        var list = JArray.Parse(await _http.GetStringAsync(string.Empty));
        int pos  = Random.Shared.Next(list.Count);
        return Map(list[pos]!, pos + 1);
    }

    // ─────────────────────────────────────────────────────────────
    // Mapear JToken → Digimon
    // ─────────────────────────────────────────────────────────────
    private Digimon Map(JToken t, int idx)
    {
        string levelEn = (string)t["level"]!;
        _nivelesEs.TryGetValue(levelEn, out var levelEs);

        return new Digimon
        {
            Index   = idx,
            Name    = (string)t["name"]!,
            Level   = levelEn,
            LevelEs = levelEs ?? levelEn,
            Img     = (string)t["img"]!
        };
    }
}

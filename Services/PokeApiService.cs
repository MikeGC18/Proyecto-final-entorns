using Proyecto_final_entorns.Models;
using Newtonsoft.Json.Linq;
using System.Net.Http.Json;

namespace Proyecto_final_entorns.Services;

public class PokeApiService : IPokeApiService
{
    private readonly HttpClient _http;
    public PokeApiService(HttpClient http) => _http = http;

    public async Task<IEnumerable<PokemonListItem>> GetListAsync(int limit = 20)
    {
        var data = await _http.GetFromJsonAsync<PokeListResponse>(
                       $"pokemon?limit={limit}");

        return data!.Results.Select(r =>
        {
            var idStr = r.Url.TrimEnd('/').Split('/').Last();
            return new PokemonListItem
            {
                Id   = int.Parse(idStr),
                Name = r.Name
            };
        });
    }

    public async Task<Pokemon> GetAsync(string idOrName)
    {

        var pokeJson = JObject.Parse(
            await _http.GetStringAsync($"pokemon/{idOrName}"));

        var speciesJson = JObject.Parse(
            await _http.GetStringAsync($"pokemon-species/{idOrName}"));

        string flavor =
            speciesJson["flavor_text_entries"]!
                .FirstOrDefault(f => (string)f["language"]!["name"]! == "es")?["flavor_text"]?
            .ToString()
            ?? speciesJson["flavor_text_entries"]!
                    .First(f => (string)f["language"]!["name"]! == "en")["flavor_text"]!
                    .ToString();

        flavor = flavor.Replace("\n", " ").Replace("\f", " ");

        return new Pokemon
        {
            Id       = (int)pokeJson["id"]!,
            Name     = (string)pokeJson["name"]!,
            ImageUrl = (string?)pokeJson["sprites"]?["front_default"] ?? string.Empty,

            HeightM  = (decimal)pokeJson["height"]! / 10,
            WeightKg = (decimal)pokeJson["weight"]! / 10,

            Types     = pokeJson["types"]!
                           .Select(t => (string)t["type"]!["name"]!)
                           .ToList(),

            Abilities = pokeJson["abilities"]!
                           .Select(a => (string)a["ability"]!["name"]!)
                           .ToList(),

            BaseStats = pokeJson["stats"]!
                           .ToDictionary(
                               s => ((string)s["stat"]!["name"]!).Replace('-', ' '),
                               s => (int)s["base_stat"]!),

            Flavor = flavor
        };
    }

    private record PokeListResponse(IEnumerable<PokeResult> Results);
    private record PokeResult(string Name, string Url);
}

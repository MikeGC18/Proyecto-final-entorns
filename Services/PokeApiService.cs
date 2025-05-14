namespace MVC.Services;

using System.Net.Http.Json;
using MVC.Models;
using Newtonsoft.Json;

public class PokeApiService : IPokeApiService
{
    private readonly HttpClient _http;
    private const string Base = "https://pokeapi.co/api/v2/";   // :contentReference[oaicite:0]{index=0}

    public PokeApiService(HttpClient http) => _http = http;

    public async Task<List<PokemonListItem>> GetFirstGenerationAsync()
    {
        var page = await _http
            .GetFromJsonAsync<PokemonPageResult>($"{Base}pokemon?limit=151&offset=0");
        return page?.Results ?? new();
    }

    public async Task<Pokemon?> GetPokemonAsync(string idOrName)
    {
        var res = await _http.GetAsync($"{Base}pokemon/{idOrName.ToLower()}");
        if (!res.IsSuccessStatusCode) return null;

        var json = await res.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<Pokemon>(json);
    }
}

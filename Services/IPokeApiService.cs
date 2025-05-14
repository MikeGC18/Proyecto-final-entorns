namespace MVC.Services;

using MVC.Models;
public interface IPokeApiService
{
    Task<List<PokemonListItem>> GetFirstGenerationAsync();
    Task<Pokemon?> GetPokemonAsync(string idOrName);
}

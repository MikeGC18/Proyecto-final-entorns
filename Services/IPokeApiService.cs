using Proyecto_final_entorns.Models;

namespace Proyecto_final_entorns.Services;

public interface IPokeApiService
{
    Task<IEnumerable<PokemonListItem>> GetListAsync(int limit = 20);
    Task<Pokemon>                      GetAsync   (string idOrName);
}

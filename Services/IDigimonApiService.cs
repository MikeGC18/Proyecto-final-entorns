using Proyecto_final_entorns.Models;

namespace Proyecto_final_entorns.Services;

public interface IDigimonApiService
{
    Task<Digimon?> GetAsync(string name);
    Task<Digimon>  GetRandomAsync();
}

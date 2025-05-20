using Microsoft.AspNetCore.Mvc;
using Proyecto_final_entorns.Services;

namespace Proyecto_final_entorns.Controllers;

public class PokemonController : Controller
{
    private readonly IPokeApiService _poke;

    public PokemonController(IPokeApiService poke) => _poke = poke;

    // /Pokemon?name=pikachu
    public async Task<IActionResult> Index(string name = "pikachu")
    {
        var model = await _poke.GetAsync(name.ToLower());
        return View(model);
    }

    // /Pokemon/Random
    public async Task<IActionResult> Random()
    {
        // 👇  usa la clase System.Random, NO el método del controlador
        int randomId = System.Random.Shared.Next(1, 899);

        var model = await _poke.GetAsync(randomId.ToString());
        return View("Index", model);
    }
}

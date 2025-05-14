using Microsoft.AspNetCore.Mvc;
using MVC.Services;   // ← donde vive IPokeApiService
using MVC.Models;

namespace MVC.Controllers;

public class PokedexController : Controller
{
    private readonly IPokeApiService _service;

    public PokedexController(IPokeApiService service)
        => _service = service;

    // GET /Pokedex
    public async Task<IActionResult> Index()
    {
        List<PokemonListItem> pokes = await _service.GetFirstGenerationAsync();
        return View(pokes);                 // pasamos la lista (151) a la vista
    }

    // GET /Pokedex/Details/25   (petición fetch desde JS)
    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        var pokemon = await _service.GetPokemonAsync(id);
        return pokemon is null
            ? NotFound()
            : PartialView("_PokemonCard", pokemon);  // devolverá sólo el fragmento HTML
    }
}

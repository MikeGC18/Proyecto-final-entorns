using Microsoft.AspNetCore.Mvc;
using Proyecto_final_entorns.Services;

namespace Proyecto_final_entorns.Controllers;

[Route("Digimon")]
public class DigimonController : Controller
{
    private readonly IDigimonApiService _digimon;
    public DigimonController(IDigimonApiService digimon) => _digimon = digimon;

    // /Digimon?name=Agumon
    [HttpGet("")]
    public async Task<IActionResult> Index(string name = "Agumon")
    {
        var model = await _digimon.GetAsync(name) ?? await _digimon.GetAsync("Agumon");
        return View(model);
    }

    // /Digimon/Random
    [HttpGet("Random")]
    public async Task<IActionResult> Random()
    {
        var model = await _digimon.GetRandomAsync();
        return View("Index", model);
    }
}

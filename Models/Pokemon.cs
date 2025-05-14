using Newtonsoft.Json;

namespace MVC.Models;

public class Pokemon
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public Sprites Sprites { get; set; } = default!;
    public List<Stat> Stats { get; set; } = new();
}

public class Sprites
{
    [JsonProperty("front_default")]
    public string FrontDefault { get; set; } = default!;
}

public class Stat
{
    [JsonProperty("base_stat")]
    public int BaseStat { get; set; }

    [JsonProperty("stat")]
    public NamedApiResource StatInfo { get; set; } = default!;
}

public class NamedApiResource
{
    public string Name { get; set; } = default!;
}

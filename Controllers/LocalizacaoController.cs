using Microsoft.AspNetCore.Mvc;
using Atividade04.Services;

[ApiController]
[Route("api/[controller]")]
public class LocalizacaoController : ControllerBase
{
    private readonly LocalizacaoService _localizacaoService;

    public LocalizacaoController(LocalizacaoService localizacaoService)
    {
        _localizacaoService = localizacaoService;
    }

    [HttpGet("cidades")]
    public IActionResult GetCidades([FromQuery] string stateCode, [FromQuery] string countryCode)
    {
        var cidades = _localizacaoService.GetCidades(stateCode, countryCode);
        if (cidades == null || !cidades.Any())
            return NotFound("Nenhuma cidade encontrada.");

        return Ok(cidades);
    }

    [HttpGet("estados")]
    public IActionResult GetEstados([FromQuery] string countryCode)
    {
        var estados = _localizacaoService.GetEstados(countryCode);
        if (estados == null || !estados.Any())
            return NotFound("Nenhum estado encontrado.");

        return Ok(estados);
    }

    [HttpGet("paises")]
    public IActionResult GetPaises()
    {
        var paises = _localizacaoService.GetPaises();
        if (paises == null || !paises.Any())
            return NotFound("Nenhum país encontrado.");

        return Ok(paises);
    }

    [HttpGet("cidade")]
    public IActionResult GetCidadePorNome([FromQuery] string citieName)
    {
        var cidades = _localizacaoService.GetCidadesPorNome(citieName);
        if (cidades == null || !cidades.Any())
            return NotFound($"Nenhuma cidade encontrada com o nome '{citieName}'.");

        return Ok(cidades);
    }
}

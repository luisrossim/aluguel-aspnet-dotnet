using Microsoft.AspNetCore.Mvc;

namespace aluguel_webapi.Controllers;

[Controller]
[Route("/aluguel")]
public class AluguelController : ControllerBase
{
    private readonly IAluguelService _service;

    public AluguelController(IAluguelService service) => _service = service;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var alugueis = await _service.getAllAlugueis();
        
        if (alugueis == null || alugueis.Count == 0)
        {
            return NoContent();
        }

        return Ok(alugueis);
    }

  [HttpPost]
    public async Task<IActionResult> Create([FromBody] AluguelDTO aluguelDto)
    {
        var (sucesso, mensagem) = await _service.createAluguel(aluguelDto);

        if (!sucesso)
        {
            return BadRequest(mensagem);
        }

        return Ok(mensagem);
    }
}
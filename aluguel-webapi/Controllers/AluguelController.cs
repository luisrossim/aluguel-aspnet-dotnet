using Microsoft.AspNetCore.Mvc;
using aluguel_webapi.Entities;
using aluguel_webapi.Services;

namespace aluguel_webapi.Controllers;

[ApiController]
[Route("/aluguel")]
public class AluguelController : ControllerBase
{
    private readonly IAluguelService _service;
    public AluguelController(IAluguelService service) => _service = service;

    [HttpGet]
    public async Task<ActionResult<List<Aluguel>>> GetAll()
    {
        var alugueis = await _service.GetAllAlugueis();
        
        if (!alugueis.Any()) 
            return NoContent();

        return Ok(alugueis);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AluguelDTO aluguelDto)
    {
        await _service.CreateAluguel(aluguelDto);
        
        return StatusCode(201, new { mensagem = "Criado com sucesso" });
    }
}
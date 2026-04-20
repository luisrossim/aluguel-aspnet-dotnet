using aluguel_webapi.Entities;
using aluguel_webapi.Data;
using Microsoft.EntityFrameworkCore;

public class AluguelRepository : IAluguelRepository
{
    private readonly AppDbContext _context;

    public AluguelRepository(AppDbContext context) => _context = context;

    public async Task<bool> checkIfAlreadyExists(string codigo)
    {
        return await _context.Alugueis.AnyAsync(aluguel => aluguel.Codigo == codigo);
    }

    public async Task create(Aluguel aluguel)
    {
        _context.Alugueis.Add(aluguel);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Aluguel>> getAll()
    {
        return await _context.Alugueis.ToListAsync();
    }
}
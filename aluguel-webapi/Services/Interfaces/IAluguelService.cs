using aluguel_webapi.Entities;

namespace aluguel_webapi.Services;

public interface IAluguelService
{
    Task<List<Aluguel>> GetAllAlugueis();

    Task CreateAluguel(AluguelDTO dto);
}
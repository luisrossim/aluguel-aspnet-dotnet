namespace aluguel_webapi.Services;

using aluguel_webapi.Entities;

public class AluguelService : IAluguelService
{
    private readonly IAluguelRepository _repository;
    public AluguelService(IAluguelRepository repository) => _repository = repository;

    public async Task<List<Aluguel>> GetAllAlugueis()
    {
        return await _repository.getAll();
    }

    public async Task CreateAluguel(AluguelDTO dto)
    {
        if (await _repository.checkIfAlreadyExists(dto.Codigo))
        {
            throw new BusinessException("Este aluguel já existe.");
        }

        var novoAluguel = new Aluguel { Codigo = dto.Codigo };

        await _repository.create(novoAluguel);
    }
}
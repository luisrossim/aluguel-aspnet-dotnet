namespace aluguel_webapi.Services;

using aluguel_webapi.Entities;

public class AluguelService : IAluguelService
{
    private readonly IAluguelRepository _repository;

    public AluguelService(IAluguelRepository repository) => _repository = repository;

    public async Task<List<Aluguel>> getAllAlugueis()
{
    return await _repository.getAll();
}

    public async Task<(bool Sucesso, string Mensagem)> createAluguel(AluguelDTO dto)
    {
        if (await _repository.checkIfAlreadyExists(dto.Codigo))
        {
            return (false, "Este aluguel já existe no sistema.");
        }

        var novoAluguel = new Aluguel { Codigo = dto.Codigo };
        await _repository.create(novoAluguel);

        return (true, "Aluguel criado com sucesso!");
    }
}
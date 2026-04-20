using aluguel_webapi.Entities;

public interface IAluguelRepository
{
    Task<bool> checkIfAlreadyExists(string codigo);
    Task create(Aluguel aluguel);
    Task<List<Aluguel>> getAll();
}
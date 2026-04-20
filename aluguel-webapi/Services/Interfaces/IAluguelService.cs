using aluguel_webapi.Entities;

public interface IAluguelService
{
    Task<List<Aluguel>> getAllAlugueis();

    Task<(bool Sucesso, string Mensagem)> createAluguel(AluguelDTO dto);
}
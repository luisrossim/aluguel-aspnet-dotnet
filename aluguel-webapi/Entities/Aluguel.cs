namespace aluguel_webapi.Entities;

public class Aluguel
{
    public Guid Id { get; set; }
    public string Codigo { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
}
namespace FullstackAfiliados.Business.Models;

public class TransactionType : Entity
{
    public string Description { get; set; }

    public string Nature { get; set; }

    public string Sinal { get; set; }

    public IEnumerable<Transaction> Transactions { get; set; }
}
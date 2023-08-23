namespace FullstackAfiliados.Business.Models;

public class Transaction : Entity
{
    public int TransactionTypeId { get; set; }

    public DateTime ProcessedAt { get; set; }

    public string Product { get; set; }

    public decimal Value { get; set; }

    public string Seller { get; set; }

    public TransactionType TransactionType { get; set; }
}
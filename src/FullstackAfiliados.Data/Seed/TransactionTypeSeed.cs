using FullstackAfiliados.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace FullstackAfiliados.Data.Seed;

public static class TransactionTypeSeed
{
    public static void RegisterTransactionType(ModelBuilder modelBuilder)
    {
        var transactionTypes = new List<TransactionType>
        {
            new()
            {
                Id = 1,
                Description = "Venda produtor",
                Nature = "Entrada",
                Sinal = "+",
                CreatedAt = DateTime.Now
            },
            new()
            {
                Id = 2,
                Description = "Venda afiliado",
                Nature = "Entrada",
                Sinal = "+",
                CreatedAt = DateTime.Now
            },
            new()
            {
                Id = 3,
                Description = "Comissão paga",
                Nature = "Saída",
                Sinal = "-",
                CreatedAt = DateTime.Now
            },
            new()
            {
                Id = 4,
                Description = "Comissão recebida",
                Nature = "Entrada",
                Sinal = "+",
                CreatedAt = DateTime.Now
            }
        };

        modelBuilder.Entity<TransactionType>().HasData(transactionTypes);
    }
}
using FullstackAfiliados.Business.Models;

namespace FullstackAfiliados.Business.Interfaces;

public interface ITransactionRepository : IRepository<Transaction>
{
    Task<List<Transaction>> GetTransactionsWithTypes();
}
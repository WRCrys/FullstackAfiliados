using FullstackAfiliados.Business.Interfaces;
using FullstackAfiliados.Business.Models;
using FullstackAfiliados.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace FullstackAfiliados.Data.Repositories;

public class TransactionRepository : Repository<Transaction>, ITransactionRepository
{
    public TransactionRepository(FullstackAfiliadosDbContext db) : base(db)
    {
    }

    public async Task<List<Transaction>> GetTransactionsWithTypes() => await Db.Transactions.AsNoTracking().Include(t => t.TransactionType).ToListAsync();
}
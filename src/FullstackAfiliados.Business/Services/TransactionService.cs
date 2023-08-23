using FullstackAfiliados.Business.Interfaces;
using FullstackAfiliados.Business.Models;
using Microsoft.AspNetCore.Http;

namespace FullstackAfiliados.Business.Services;

public class TransactionService : ITransactionService
{
    private readonly ITransactionRepository _transactionRepository;

    public TransactionService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public async Task ProcessFile(IFormFile file)
    {
        using var reader = new StreamReader(file.OpenReadStream());
        
        var lines = (await reader.ReadToEndAsync()).Split(new[] { "\n" }, StringSplitOptions.None).Where(x => x != "").ToList();

        foreach (var transaction in lines.Select(CreateTransactionObject))
            await _transactionRepository.Create(transaction);
    }

    private static Transaction CreateTransactionObject(string line)
    {
        return new Transaction
        {
            TransactionTypeId = int.Parse(line[..1]),
            ProcessedAt = DateTime.Parse(line[1..26]),
            Product = line[26..55].TrimEnd(),
            Value = Convert.ToDecimal(float.Parse(line[57..66]) / 100),
            Seller = line[66..]
        };
    }
}
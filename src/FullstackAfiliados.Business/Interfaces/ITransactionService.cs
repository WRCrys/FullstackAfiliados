using Microsoft.AspNetCore.Http;

namespace FullstackAfiliados.Business.Interfaces;

public interface ITransactionService
{
    Task ProcessFile(IFormFile file);
}
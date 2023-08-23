using FullstackAfiliados.Api.Requests;
using FullstackAfiliados.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FullstackAfiliados.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionRepository transactionRepository, ITransactionService transactionService)
        {
            _transactionRepository = transactionRepository;
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var transactions = await _transactionRepository.GetTransactionsWithTypes();

            return Ok(new
            {
                success = true,
                data = transactions
            });
        }

        [RequestSizeLimit(50000000)]
        [HttpPost]
        public async Task<IActionResult> CreateTransactionByFile([FromForm] TransactionRequest request)
        {
            if (request.File.ContentType != "text/plain")
                throw new ArgumentException("Ops! Só aceitamos o envio de um arquivo TXT.");
            
            await _transactionService.ProcessFile(request.File);
            
            return Ok();
        }
    }
}

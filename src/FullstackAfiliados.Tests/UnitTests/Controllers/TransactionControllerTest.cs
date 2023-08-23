using System.Text;
using FullstackAfiliados.Api.Controllers;
using FullstackAfiliados.Api.Requests;
using FullstackAfiliados.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullstackAfiliados.Tests.UnitTests.Controllers;

public class TransactionControllerTest
{
    private readonly TransactionController _controller;
    private readonly Mock<ITransactionRepository> _transactionRepository;
    private readonly Mock<ITransactionService> _transactionService;

    public TransactionControllerTest()
    {
        _transactionRepository = new Mock<ITransactionRepository>();
        _transactionService = new Mock<ITransactionService>();
        _controller = new TransactionController(_transactionRepository.Object, _transactionService.Object);
    }

    [Fact]
    public async Task GetAllReturningOk()
    {
        var result = await _controller.GetAll();
        var actionResult = result as OkObjectResult;
        
        Assert.Equal(200, actionResult?.StatusCode);
    }

    [Fact]
    public async Task CreateTransactionByFileReturningOk()
    {
        var bytes = "content"u8.ToArray();
        var request = new TransactionRequest
        {
            File = new FormFile(
                baseStream: new MemoryStream(bytes),
                baseStreamOffset: 0,
                length: bytes.Length,
                name: "Data",
                fileName: "Test.txt"
            )
            {
                Headers = new HeaderDictionary(),
                ContentType = "text/plain"
            }
        };
        
        var result = await _controller.CreateTransactionByFile(request);
        var actionResult = result as OkResult;
        
        Assert.Equal(200, actionResult?.StatusCode);
    }
    
    [Fact]
    public async Task CreateTransactionByFileReturningBadRequest()
    {
        var bytes = "content"u8.ToArray();
        var request = new TransactionRequest
        {
            File = new FormFile(
                baseStream: new MemoryStream(bytes),
                baseStreamOffset: 0,
                length: bytes.Length,
                name: "Data",
                fileName: "Test.pdf"
            )
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/pdf"
            }
        };
        
        await Assert.ThrowsAsync<ArgumentException>(() => _controller.CreateTransactionByFile(request));
    }
}
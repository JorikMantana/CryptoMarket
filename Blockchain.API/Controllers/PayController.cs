using System.Numerics;
using BlockchainManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Blockchain.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PayController : Controller
{
    private readonly IBlockchainPayement _blockchainPayement;

    public PayController(IBlockchainPayement blockchainPayement)
    {
        _blockchainPayement = blockchainPayement;
    }

    [HttpPost]
    public async Task<ActionResult> Pay(string contractAddress, BigInteger amount, BigInteger amountToSend, string privateKey)
    {
        await _blockchainPayement.Pay(contractAddress, amount, amountToSend, privateKey);
        return Ok();
    }
}
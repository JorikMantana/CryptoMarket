using System.Numerics;
using Blockchain.API.Entities;
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
    public async Task<ActionResult> Pay(PayRequest request)
    {
        {
            await _blockchainPayement.Pay(request.ContractAddress, request.Amount, request.AmountToSend, request.PrivateKey);
            return Ok();
        }
    }
}
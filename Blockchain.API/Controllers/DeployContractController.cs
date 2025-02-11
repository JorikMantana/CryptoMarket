using BlockchainManager.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Blockchain.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeployContractController : Controller
{
    private readonly IDeployContract _deployContract;
    
    public DeployContractController(IDeployContract deployContract)
    {
        _deployContract = deployContract;
    }

    [HttpPost]
    public async Task<ActionResult> Deploy(string address)
    {
        var result = await _deployContract.Deploy(address);
        return Ok(result);
    }
}
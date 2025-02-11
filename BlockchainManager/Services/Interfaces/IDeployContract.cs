using Nethereum.Web3;

namespace BlockchainManager.Services.Interfaces;

public interface IDeployContract
{
    public Task<string> Deploy(string privateKey);
}
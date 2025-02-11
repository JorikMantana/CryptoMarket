using BlockchainManager.Entities;
using BlockchainManager.Services.Interfaces;
using Nethereum.Web3;
using Account = Nethereum.Web3.Accounts.Account;

namespace BlockchainManager.Services;

public class DeployContract : IDeployContract
{
    public static Web3 Web3;
    public async Task<string> Deploy(string privateKey)
    {
        var url = "HTTP://127.0.0.1:7545"; //На этапе разработки используется Ganache
        var account = new Account(privateKey);
        Web3 = new Web3(account, url);
        
        var deploymentMessage = new MarketContract()
        {
            Seller = "0x0c60F68f6Fa0606398A275230E04C3584E607B02" //Адрес аккаунта продавца, на этапе разработки используется рандомный из Ganache
        };
        
        var deploymentHandler = Web3.Eth.GetContractDeploymentHandler<MarketContract>();
        var transactionReceipt = await deploymentHandler.SendRequestAndWaitForReceiptAsync(deploymentMessage);
        var contractAddress = transactionReceipt.ContractAddress;
        
        return (contractAddress);
    }
}
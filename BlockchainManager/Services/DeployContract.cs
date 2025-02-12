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
        var url = "http://ganache:8545"; //На этапе разработки используется Ganache
        var account = new Account(privateKey);
        Web3 = new Web3(account, url);
        
        var deploymentMessage = new MarketContract()
        {
            Seller = "0x12f67240Be536601172434db161FA5a6e43D70B0" //Адрес аккаунта продавца, на этапе разработки используется рандомный из Ganache
        };
        
        var deploymentHandler = Web3.Eth.GetContractDeploymentHandler<MarketContract>();
        var transactionReceipt = await deploymentHandler.SendRequestAndWaitForReceiptAsync(deploymentMessage);
        var contractAddress = transactionReceipt.ContractAddress;
        
        return (contractAddress);
    }
}
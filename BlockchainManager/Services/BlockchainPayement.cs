using System.Numerics;
using BlockchainManager.Entities;
using BlockchainManager.Services.Interfaces;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;

namespace BlockchainManager.Services;

public class BlockchainPayement : IBlockchainPayement
{
    public async Task Pay(string contractAddress, BigInteger amount, BigInteger amountToSend, string privateKey)
    {
        var account = new Account(privateKey);
        var web3 = new Web3(account, DeployContract.Web3.Client);
        
        var payHandler = web3.Eth.GetContractTransactionHandler<PayFunction>();
        var pay = new PayFunction()
        {
            FromAddress = account.Address,
            Amount = amount,
            AmountToSend = amountToSend
        };

        await payHandler.SendRequestAsync(contractAddress, pay);
    }
}
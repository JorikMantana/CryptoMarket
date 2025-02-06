using System.Numerics;
using Nethereum.Web3;

namespace BlockchainManager.Services.Interfaces;

public interface IBlockchainPayement
{
    Task Pay(string contractAddress, BigInteger amount, BigInteger amountToSend, string privateKey);
}
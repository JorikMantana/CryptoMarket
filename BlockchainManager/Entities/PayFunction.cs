using System.Numerics;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;

namespace BlockchainManager.Entities;

[Function("Pay", "address")]
public class PayFunction : FunctionMessage
{
    [Parameter("uint256", "amount", 1)] 
    public BigInteger Amount { get; set; }
}
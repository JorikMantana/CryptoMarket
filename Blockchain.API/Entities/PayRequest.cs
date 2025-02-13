using System.Numerics;
using System.Text.Json.Serialization;

namespace Blockchain.API.Entities;

public class PayRequest
{
    [JsonConverter(typeof(BigIntegerConverter))]
    public BigInteger AmountToSend { get; set; }
    [JsonConverter(typeof(BigIntegerConverter))]
    public BigInteger Amount { get; set; }
    public string ContractAddress { get; set; }
    public string PrivateKey { get; set; }
}
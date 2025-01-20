using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtAuthenticationManager.Data;
using JwtAuthenticationManager.Models;
using JwtAuthenticationManager.Repositories.IRepositories;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace JwtAuthenticationManager;

public class JwtTokenHandler
{
    public const string SecurityKey = "UnsafeSecurityKeyForDevelopingCryptoMarket";
    private const int JWT_TOKEN_VALIDITY_MINS = 20;

    private readonly IUserAccountsRepository _repository;

    private UserAccount _userAccount;

    public JwtTokenHandler(IUserAccountsRepository repository)
    {
        _repository = repository;
    }

    public async Task<AuthenticationResponse?> GenerateJwtToken(AuthenticationRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
            return null;

        var userAccount = await _repository.GetUserByUserNameAndPassword(request.UserName, request.Password);
        if (userAccount == null) return null;

        var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
        var tokenKey = Encoding.ASCII.GetBytes(SecurityKey);
        var claimsIdentity = new ClaimsIdentity(new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Name, request.UserName),
            new Claim(ClaimTypes.Role, userAccount.Role),
        });

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(tokenKey),
            SecurityAlgorithms.HmacSha256Signature);

        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = claimsIdentity,
            Expires = tokenExpiryTimeStamp,
            SigningCredentials = signingCredentials,
        };

        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
        var token = jwtSecurityTokenHandler.WriteToken(securityToken);

        return new AuthenticationResponse()
        {
            UserName = userAccount.UserName,
            ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
            JwtToken = token
        };
    }
}
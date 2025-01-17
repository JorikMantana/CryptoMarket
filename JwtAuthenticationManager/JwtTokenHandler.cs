using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtAuthenticationManager.Models;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace JwtAuthenticationManager;

public class JwtTokenHandler
{
    public const string SecurityKey = "UnsafeSecurityKeyForDevelopingCryptoMarket";
    private const int JWT_TOKEN_VALIDITY_MINS = 20;
    
    private readonly List<UserAccount> _userAccountList;

    public JwtTokenHandler()
    {
        _userAccountList = new List<UserAccount>
        {
            new UserAccount { UserName = "admin", Password = "admin", Role = "Admin" },
            new UserAccount { UserName = "user", Password = "user", Role = "User" },
        };
    }

    public AuthenticationResponse? GenerateJwtToken(AuthenticationRequest request)
    {
        if(string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
            return null;

            var userAccount = _userAccountList.Where(x => x.UserName == request.UserName && x.Password == request.Password).FirstOrDefault();
            if(userAccount == null) return null;
            
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
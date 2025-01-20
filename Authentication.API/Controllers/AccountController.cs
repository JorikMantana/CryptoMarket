using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;
using JwtAuthenticationManager.Repositories.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : Controller
{
    private readonly JwtTokenHandler _jwtTokenHandler;
    private readonly IUserAccountsRepository _repository;

    public AccountController(JwtTokenHandler jwtTokenHandler, IUserAccountsRepository repository)
    {
        _jwtTokenHandler = jwtTokenHandler;
        _repository = repository;
    }

    [HttpPost("Authenticate")]
    public async Task<ActionResult<AuthenticationResponse?>> Authenticate([FromBody] AuthenticationRequest request)
    {
        var response = await _jwtTokenHandler.GenerateJwtToken(request);
        if (response == null) return Unauthorized();
        return response;
    }

    [HttpPost("Register")]
    public async Task<ActionResult> CreateAccount(UserAccount userAccount)
    {
        var user = await _repository.GetUserByUserName(userAccount.UserName);
        if (user != null)
        {
            return BadRequest("Username is already taken");
        }
        
        await _repository.AddUser(userAccount);
        return Ok();
    }
}
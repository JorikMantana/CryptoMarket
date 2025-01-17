﻿using JwtAuthenticationManager;
using JwtAuthenticationManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : Controller
{
    private readonly JwtTokenHandler _jwtTokenHandler;

    public AccountController(JwtTokenHandler jwtTokenHandler)
    {
        _jwtTokenHandler = jwtTokenHandler;
    }

    [HttpPost]
    public ActionResult<AuthenticationResponse?> Authenticate([FromBody] AuthenticationRequest request)
    {
        var response = _jwtTokenHandler.GenerateJwtToken(request);
        if (response == null) return Unauthorized();
        return response;
    }
}
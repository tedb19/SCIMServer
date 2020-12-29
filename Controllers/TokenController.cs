using Microsoft.AspNetCore.Mvc;
using SCIMServer.Domain.Models;
using SCIMServer.Domain.Services;

namespace SCIMServer.Controllers
{
    [ApiVersion("2.0")]
    [Route("/api/v{version:apiVersion}/[controller]")]
    public class TokenController : Controller
    {
        private readonly ITokenService _tokenService;
        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet]
        public BearerToken Index()
        {
            return _tokenService.GenerateToken();
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Parking.Api.Requests;
using Parking.Api.Services;

namespace Parking.Api.Controllers.Auth
{
    [Route("api/auth/login")]
    public class LoginController : BaseController
    {
        private readonly IAuthService authService;
        private readonly IMapper mapper;

        public LoginController(
            IAuthService authService,
            IMapper mapper
        ) {
            this.mapper = mapper;
            this.authService = authService;
        }

        [HttpPost]
        public ActionResult<string> Login(LoginRequest request)
        {
            var token = this.authService.Login(request.Email, request.Password);
            return token;
        }
    }
}
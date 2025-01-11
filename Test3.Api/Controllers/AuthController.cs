using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Test3.Application.Contracts.Identity;
using Test3.Application.DTOs.Identity;
using Test3.Infrastructure.Identity.Services;
namespace Test3.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _iAuthService;

        public AuthController(IAuthService iAuthService)
        {
            _iAuthService = iAuthService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequest loginRequest)
        {
            try
            {
                var token = await _iAuthService.Login(loginRequest);
                return Ok(new { Token = token });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { Message = ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromForm] Application.DTOs.Identity.RegisterRequest registerRequest)
        {
            try
            {
                // استدعاء خدمة التسجيل وإرجاع استجابة
                var registrationResponse = await _iAuthService.RegisterUser(registerRequest);

                // إعادة استجابة منظمة
                return Ok(registrationResponse);
            }
            catch (Exception ex)
            {
                // إعادة الخطأ إذا حدث استثناء
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}

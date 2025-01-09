using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Test3.Application.Contracts.Identity;
using Test3.Application.DTOs.Identity;
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
        public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
        {
            return Ok(await _iAuthService.Login(request));
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

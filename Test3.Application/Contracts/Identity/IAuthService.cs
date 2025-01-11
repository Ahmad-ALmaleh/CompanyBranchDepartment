using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test3.Application.DTOs.Identity;

namespace Test3.Application.Contracts.Identity;

public interface IAuthService
{
    Task<string> Login(AuthRequest request);
    Task<RegistrationResponse> RegisterUser(RegisterRequest request);

}
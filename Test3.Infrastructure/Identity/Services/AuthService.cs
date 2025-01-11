using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Test3.Application.Contracts.Identity;
using Test3.Application.Contracts.Persistence;
using Test3.Application.DTOs.Employee;
using Test3.Application.DTOs.Identity;
using Test3.Domin.Entities;
using Test3.Infrastructure.Identity.Models;
using Test3.Infrastructure.Persistence;
using Test3.Infrastructure.Persistence.Services;

namespace Test3.Infrastructure.Identity.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly JwtSettings _jwtSettings;
    private readonly IWebHostEnvironment _env;
    private readonly IMapper _mapper;
    private readonly AppDbContext _dbContext;
    private readonly IEmployeeRepository _employeeRepository;


    public AuthService(UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IOptions<JwtSettings> jwtSettings,
        SignInManager<AppUser> signInManager,
        IWebHostEnvironment env,
        IMapper mapper,
        AppDbContext dbContext,
        IEmployeeRepository employeeRepository

        )
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _jwtSettings = jwtSettings.Value;
        _signInManager = signInManager;
        _env = env;
        _mapper = mapper;
        _dbContext = dbContext;
        _employeeRepository = employeeRepository;
    }

    public async Task<string> Login(AuthRequest loginRequest)
    {
        var user = await _userManager.FindByEmailAsync(loginRequest.Email);

        if (user == null || !await _userManager.CheckPasswordAsync(user, loginRequest.Password))
        {
            throw new Exception("Invalid credentials.");
        }

        // توليد التوكن
        var jwtToken = await GenerateToken(user);

        return new JwtSecurityTokenHandler().WriteToken(jwtToken);
    }

    

    public async Task<RegistrationResponse> RegisterUser(RegisterRequest registerRequest)
    {
        var existingUser = await _userManager.FindByEmailAsync(registerRequest.Email);
        if (existingUser != null)
        {
            throw new Exception($"Username '{registerRequest.Email}' already exists.");
        }
        // إنشاء المستخدم
        var user = _mapper.Map<AppUser>(registerRequest);

        var result = await _userManager.CreateAsync(user, registerRequest.Password );

        if (!result.Succeeded)
        {
            throw new Exception(string.Join("; ", result.Errors.Select(e => e.Description)));
        }
        // معالجة ملف الـ CV
        string? cvPath = null;
        if (registerRequest.CV != null)
        {
            var uploadsFolder = Path.Combine("wwwroot", "uploads", "cvs");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = $"{Guid.NewGuid()}_{registerRequest.CV.FileName}";
            cvPath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var stream = new FileStream(cvPath, FileMode.Create))
            {
                await registerRequest.CV.CopyToAsync(stream);
            }
        }


        // إنشاء الموظف وربطه بالمستخدم
        var createEmployee = new CreateEmployee
        {
            Id = Guid.NewGuid().ToString(),
            FullName = registerRequest.FullName,
            Email = registerRequest.Email,
            AppUserId = user.Id,
            CVPath = cvPath,
            
        };

        var employee = _mapper.Map<Employee>(createEmployee);

        await _employeeRepository.AddAsync(employee);

        var response = _mapper.Map<RegistrationResponse>(user);
        return response; // إعادة معرف المستخدم إذا لزم الأمر
    }


    private async Task<JwtSecurityToken> GenerateToken(AppUser user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);

        var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role)).ToList();

        var claims = new[]
        {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Email, user.Email),
        new Claim("Uid", user.Id)
    }
        .Union(userClaims)
        .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
            signingCredentials: signingCredentials
        );
    }
}
//AddMinutes(_jwtSettings.DurationInMinutes),




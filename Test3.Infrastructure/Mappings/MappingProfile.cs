using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Test3.Application.DTOs.Employee;
using Test3.Application.DTOs.Identity;
using Test3.Domin.Entities;
using Test3.Infrastructure.Identity.Models;

namespace Test3.Infrastructure.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // تعيين RegisterRequest إلى AppUser
        CreateMap<RegisterRequest, AppUser>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

        // تعيين CreateEmployee إلى Employee
        CreateMap<CreateEmployee, Employee>()
            .ForMember(dest => dest.CvFilePath, opt => opt.MapFrom(src => src.CVPath));

        // تعيين AppUser إلى RegistrationResponse
        CreateMap<AppUser, RegistrationResponse>()
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
    }
}

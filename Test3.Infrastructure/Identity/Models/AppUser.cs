using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Test3.Infrastructure.Identity.Models;

public class AppUser : IdentityUser
{
    public string FullName { get; set; }
}

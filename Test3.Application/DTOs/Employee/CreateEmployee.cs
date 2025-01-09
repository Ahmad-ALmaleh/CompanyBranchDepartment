using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test3.Application.DTOs.Employee
{
    public class CreateEmployee
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FullName { get; set; }
        public string Email { get; set; }
        public string AppUserId { get; set; } = string.Empty;
        public string? CVPath { get; set; } = string.Empty;
    }
}

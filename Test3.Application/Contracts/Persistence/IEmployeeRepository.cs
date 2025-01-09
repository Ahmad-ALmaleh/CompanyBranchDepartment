using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test3.Domin.Entities;

namespace Test3.Application.Contracts.Persistence
{
    public interface IEmployeeRepository
    {
        Task AddAsync(Employee employee);
    }
}

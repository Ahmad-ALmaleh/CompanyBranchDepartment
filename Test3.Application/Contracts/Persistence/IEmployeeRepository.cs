using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Test3.Domin.Entities;

namespace Test3.Application.Contracts.Persistence
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetAsync(Expression<Func<Employee, bool>> predicate);
        Task<IEnumerable<Employee>> GetAllAsync();
        Task AddAsync(Employee employee);
        Task UpdateAsync(Employee employee);
    }
}

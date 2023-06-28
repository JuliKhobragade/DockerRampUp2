using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NewRampUpAssign2.Interface;
using NewRampUpAssign2.Models;


namespace NewRampUpAssign2.Repository
{
    public class EmployeeRepository : IEmployee
    {
        readonly DataContext _dbContext = new();


        public EmployeeRepository(DataContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<List<Employee>> GetEmployeeDetails()
        {
            return await _dbContext.Set<Employee>().ToListAsync();
        }

        public async Task<Employee?> GetEmployeeDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            return await _dbContext.Set<Employee>().FindAsync(id);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {

            _dbContext.Set<Employee>().Add(employee);
            await _dbContext.SaveChangesAsync();
            return employee;

        }

        public async Task UpdateEmployee(Employee employee)
        {
            _dbContext.Update(employee);
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteEmployee(int id)
        {
            var employee = await GetEmployeeDetails(id);

            if (employee is null)
            {
                throw new Exception("Id not found.");
            }
            _dbContext.Set<Employee>().Remove(employee);
            await _dbContext.SaveChangesAsync();
        }
    }
}

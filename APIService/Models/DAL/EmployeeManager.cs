using APIService.Models.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIService.Models.DAL
{
    public class EmployeeManager : IDataRepository<Employee>
    {
        readonly DataBaseContext _dataBaseContext;
        public EmployeeManager(DataBaseContext context)
        {
            _dataBaseContext = context;
        }
        public IEnumerable<Employee> GetAll()
        {
            return _dataBaseContext.Employees.ToList();
        }
        public Employee Get(long id)
        {
            return _dataBaseContext.Employees
                  .FirstOrDefault(e => e.EmployeeId == id);
        }
        public void Add(Employee entity)
        {
            _dataBaseContext.Employees.Add(entity);
            _dataBaseContext.SaveChanges();
        }
        public void Update(Employee employee, Employee entity)
        {
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.Email = entity.Email;
            employee.DateOfBirth = entity.DateOfBirth;
            employee.PhoneNumber = entity.PhoneNumber;
            _dataBaseContext.SaveChanges();
        }
        public void Delete(Employee employee)
        {
            _dataBaseContext.Employees.Remove(employee);
            _dataBaseContext.SaveChanges();
        }
    }
}

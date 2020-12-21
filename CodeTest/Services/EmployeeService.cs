using CodeTest.Model;
using System.Collections.Generic;

namespace CodeTest.Services
{
    public class EmployeeService : IEmployeeService
    {
        public List<Employee> GetEmployees()
        {
            var employees = new List<Employee>();

            using (var context = new MyTestDBContext())
            {
                employees.AddRange(context.Employees);
            }

            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            using (var context = new MyTestDBContext())
            {
                context.Add(employee);
                context.SaveChanges();
            }

        }
    }
}

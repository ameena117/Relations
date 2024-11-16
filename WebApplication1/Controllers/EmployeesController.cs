using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            var Employees = _context.Employees.Select(
                emp => new GetEmployeeDto()
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Email = emp.Email,
                });
            return Ok(Employees);
        }
        [HttpGet("Details")]
        public IActionResult GetempById(int id)
        {
            var Employee = _context.Employees
                .Select(emp => new GetEmployeeDto()
                {
                    Id = emp.Id,
                    Name = emp.Name,
                    Email = emp.Email,
                })
                .Where(emp => emp.Id == id)
                .FirstOrDefault();

            if (Employee == null)
            {
                return NotFound();
            }

            return Ok(Employee);
        }


        [HttpPost("CreateEmployee")]
        public IActionResult CreateEmployee(CreateEmployeeDto employee)
        {
            Employee EmployeeDto = new Employee()
            {
                Name = employee.Name,
                Email = employee.Email,
                DepartmentId = employee.DepartmentId,

            };
            _context.Employees.Add(EmployeeDto);
            _context.SaveChanges();
            return Ok(employee);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, CreateEmployeeDto employee)
        {
            var Employee = _context.Employees.Find(id);
            Employee.Name = employee.Name;
            Employee.Email = employee.Email;
            Employee.DepartmentId = employee.DepartmentId;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            var Employee = _context.Employees.Find(id);
            _context.Employees.Remove(Employee);
            _context.SaveChanges();
            return Ok(Employee);
        }



    }
}

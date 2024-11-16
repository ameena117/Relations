using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Dto;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public DepartmentsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("GetAllDepartments")]
        public IActionResult GetAllDepartments()
        {
            var Departments = _context.Departments.Select(
                dep => new GetDepartmentDto()
                {
                    Id = dep.Id,
                    Name = dep.Name,
                });
            return Ok(Departments);
        }
        [HttpGet("Details")]
        public IActionResult GetDepById(int id)
        {
            var department = _context.Departments
                .Select(dep => new GetDepartmentDto()
                {
                    Id = dep.Id,
                    Name = dep.Name,
                })
                .Where(dep => dep.Id == id)
                .FirstOrDefault();

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }


        [HttpPost("CreateDepartment")]
        public IActionResult CreateDepartment(CreateDepartmentDto department)
        {
            Department DepartmentDto = new Department()
            {
                Name = department.Name,
            };
            _context.Departments.Add(DepartmentDto);
            _context.SaveChanges();
            return Ok(department);
        }

        [HttpPut("Update")]
        public IActionResult Update(int id, CreateDepartmentDto department)
        {
            var Department = _context.Departments.Find(id);
            Department.Name = department.Name;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(int id) {
            var Department = _context.Departments.Find(id);
            _context.Departments.Remove(Department);
            _context.SaveChanges();
            return Ok(Department);
        }


    }
}

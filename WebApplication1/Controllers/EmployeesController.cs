using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public IActionResult GetAll()
        {
            var employees = context.Employees.ToList();
        }
        //public IActionResult GetAllEmployees()
        //{
        //    var Employees = context.Employees
        //    return Ok(Employees);
        //}
    }
}

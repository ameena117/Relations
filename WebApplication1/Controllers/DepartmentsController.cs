using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        ApplicationDbContext context = new ApplicationDbContext();
        
        //[HttpGet]
        //public IActionResult GetAll()
        //{
        //    var Departments = context.Dep

        //}


    }
}

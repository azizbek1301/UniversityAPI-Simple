using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using University_API.Services;

namespace University_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        StudentService studentService=new StudentService();
        [HttpGet]
        public IActionResult GetStudentById(int id)
        {
            var student=studentService.GetStudentById(id);
            return Ok(student);
        }
    }
}

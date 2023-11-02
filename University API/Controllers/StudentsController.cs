using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using University_API.Models;
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
        [HttpGet]
        public IActionResult GetWithTwoParametr(int first, int two)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=University;Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                IEnumerable<Student> user = connection.Query<Student>($"exec GetStudentWithYear {first},{two}");

                return Ok(user);
            }
        }
    }
  
}

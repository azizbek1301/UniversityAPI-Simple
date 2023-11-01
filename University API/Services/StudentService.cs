using Dapper;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using University_API.Models;

namespace University_API.Services
{
    public class StudentService
    {
        private readonly string connectionString = WebApplication.CreateBuilder().Configuration.GetConnectionString("Default");
        public Student GetStudentById(int Id)
        {
            using (SqlConnection connection=new SqlConnection(connectionString))
            {
                DynamicParameters parameter=new DynamicParameters();
                parameter.Add("id", Id);
                var student = connection.QueryFirst<Student>("GetStudentById", parameter, commandType: CommandType.StoredProcedure);

                return student;
            }
        }
    }
}

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

        public List<string> OneDatabase(string task)
        {
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                var tableName = connection.Query<string>("Select Table_Name from Information_Schema.Tables",CommandType.StoredProcedure).ToList();
                var result=new List<string>();
                foreach (var table in tableName)
                {
                    string query = $"Select Column_Name from Information_Scheme.Columns where Table_Name='{table}";
                    var res = connection.Query<string>(query).ToList();
                    foreach(var i in res)
                    {
                        string sql = $"Select * from {table} where {i}='{task}'";
                        try
                        {
                            var checkresult = connection.Query<string>(sql).ToList();
                            if(checkresult.Count!=0)
                            {
                                result.Add($"{task}");
                            }
                            
                        }
                        catch(Exception e)
                        {

                        }
                    }
                }
                return result;
            }
        }
       
    }
}

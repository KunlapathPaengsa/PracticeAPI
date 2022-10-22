using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace PracticeAPI.Controllers
{
    [ApiController]
    [Route("interview")]
    public class InterviewController : ControllerBase
    {
        [HttpGet("get")]
        public List<Customer> Get()
        {
            var sqlQuery = "SELECT *  FROM Customers";
            try
            {
                var conn = new SqlConnection(@"Data Source=MSI\MSSQLSERVER01;Initial Catalog=Interview;Integrated Security=True");
                conn.Open();
                var result = new List<Customer>();
                //var objType = typeof(T);
                //PropertyInfo[] type = objType.GetProperties();
                using (var command = new SqlCommand(sqlQuery, conn))
                {
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //Type yy = reader[0].GetType();
                        //Console.WriteLine($"{yy}");
                        //var xxx = reader[0];
                        //var xxxxx = reader[1];
                        //var xxxx = reader[2];
                        //type.get .Parse(xxx)
                        //var xx = reader.VisibleFieldCount;
                        result.Add(new Customer
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            ReferredId = reader.IsDBNull(2) ? null : reader.GetInt32(2)
                        });
                    }
                }
                conn.Close();

                Console.WriteLine("Connection successful!");
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return new List<Customer>();
        }
    }
}

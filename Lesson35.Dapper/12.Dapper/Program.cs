using Dapper;
using Microsoft.Data.SqlClient;

using (var connection = new SqlConnection("Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True"))
{
    var sql = "SELECT COUNT(*) FROM Person.Person";
    var count = connection.ExecuteScalar<int>(sql);

    Console.WriteLine($"Total people: {count}");
}
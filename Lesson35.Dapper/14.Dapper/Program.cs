using Dapper;
using Microsoft.Data.SqlClient;

using (var connection = new SqlConnection("Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True"))
{
    var sql = "SELECT * FROM Person.Person WHERE BusinessEntityID = @id";

    Person person = connection.QuerySingle<Person>(sql, new { id = 1 });

    Console.WriteLine(person.FirstName + " " + person.LastName);
}

class Person
{
    public int BusinessEntityID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
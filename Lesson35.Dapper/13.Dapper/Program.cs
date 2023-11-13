using Dapper;
using Microsoft.Data.SqlClient;

using (var connection = new SqlConnection("Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True"))
{
    var sql = "SELECT * FROM Person.Person WHERE FirstName = @firstName";

    Person person = connection.QueryFirst<Person>(sql, new { firstName = "Ken" });

    Console.WriteLine(person.FirstName + " " + person.LastName);
}

class Person
{
    public int BusinessEntityID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
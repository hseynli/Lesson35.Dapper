using Dapper;
using Microsoft.Data.SqlClient;

using (var connection = new SqlConnection("Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True"))
{
    var sql = "SELECT * FROM Person.Person WHERE FirstName = @firstName";

    List<Person> people = connection.Query<Person>(sql, new { firstName = "Ken" }).ToList();

    foreach (Person person in people)
    {
        Console.WriteLine(person.FirstName + " " + person.LastName);
    }
}

class Person
{
    public int BusinessEntityID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
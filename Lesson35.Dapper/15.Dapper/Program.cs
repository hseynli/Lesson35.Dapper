using Dapper;
using Microsoft.Data.SqlClient;

string sql = @"
select * from Person.Person WHERE BusinessEntityId = @id;
select * from Person.PersonPhone WHERE BusinessEntityId = @id;
";

using (var connection = new SqlConnection("Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True"))
{
    using (var multi = connection.QueryMultiple(sql, new { id = 1 }))
    {
        Person person = multi.ReadFirst<Person>();
        List<PersonPhone> invoiceItems = multi.Read<PersonPhone>().ToList();

        Console.WriteLine(person.FirstName + " " + person.LastName);

        Console.WriteLine(new string('-', 80));

        foreach (PersonPhone phone in invoiceItems)
        {
            Console.WriteLine(phone.PhoneNumber);
        }
    }
}

class Person
{
    public int BusinessEntityID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

class PersonPhone
{
    public int BusinessEntityID { get; set; }
    public string PhoneNumber { get; set; }
}
using Microsoft.Data.SqlClient;
using System.Data;

DataSet ds = new DataSet();

string connecionString = @"Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True";
string commandString = "SELECT * FROM Person.Person";

SqlDataAdapter adapter = new SqlDataAdapter(commandString, connecionString);

adapter.Fill(ds);

DataTable table = ds.Tables[0];

if (table != null)
{
    var query = from row in table.AsEnumerable()
                where row.Field<int>("BusinessEntityID") == 1 || row.Field<int>("BusinessEntityID") == 2
                orderby row["FirstName"] descending
                select row;

    foreach (var row in query)
    {
        Console.WriteLine(row["FirstName"] + " " + row["LastName"]);
    }
}
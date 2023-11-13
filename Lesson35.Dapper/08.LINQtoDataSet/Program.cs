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
                select new
                {
                    FullName = row["FirstName"] + " " + row["LastName"]
                };

    foreach (var customerInfo in query)
    {
        Console.WriteLine(customerInfo.FullName);
    }
}
using Microsoft.Data.SqlClient;
using System.Data;

string connecionString = @"Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True";
string commandString = "SELECT * FROM Person.Person";

DataTable customers = new DataTable();

SqlDataAdapter adapter = new SqlDataAdapter(commandString, connecionString);

adapter.Fill(customers);

DataView dataView = new DataView(customers);

foreach (DataRowView view in dataView)
{
    Console.WriteLine("{0} {1} {2}", view["FirstName"], view["LastName"], view["MiddleName"]);
    Console.WriteLine();
}

Console.ReadKey();
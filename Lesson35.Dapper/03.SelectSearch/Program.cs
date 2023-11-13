using Microsoft.Data.SqlClient;
using System.Data;

DataSet ds = new DataSet();

string connecionString = @"Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True";
string commandString = "SELECT * FROM Person.Person";

SqlDataAdapter adapter = new SqlDataAdapter(commandString, connecionString);

adapter.Fill(ds);

DataTable customers = ds.Tables[0];

DataRow[] customersRows = customers.Select("LastName LIKE 'Du%'");

foreach (var customersRow in customersRows)
{
    foreach (DataColumn customersColumn in customers.Columns)
        Console.WriteLine(customersColumn.ColumnName + " " + customersRow[customersColumn]);

    Console.WriteLine();
}
using Microsoft.Data.SqlClient;
using System.Data;

string connectionString = @"Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True";
string commandString = "SELECT * FROM Person.Person";

DataTable customers = new DataTable();
customers.TableName = "Person";

SqlDataAdapter adapter = new SqlDataAdapter(commandString, connectionString);

adapter.Fill(customers);

// DataView-nun filtr və sıralama ilə yaradılması
DataView customersView = new DataView(customers, "BusinessEntityId < 5", "FirstName, LastName", DataViewRowState.Unchanged);

foreach (DataRowView viewRow in customersView)
{
    Console.WriteLine("Id: " + viewRow["BusinessEntityId"]);
    Console.WriteLine("{0} {1} {2}", viewRow["FirstName"], viewRow["LastName"], viewRow["MiddleName"]);

    Console.WriteLine();
}
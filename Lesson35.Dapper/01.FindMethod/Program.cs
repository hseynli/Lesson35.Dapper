using Microsoft.Data.SqlClient;
using System.Data;

DataSet ds = new DataSet();

string connecionString = @"Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True";
string commandString = "SELECT * FROM Person.Person";

SqlDataAdapter adapter = new SqlDataAdapter(commandString, connecionString);

adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
adapter.Fill(ds);

DataTable table = ds.Tables[0];
table.PrimaryKey = new DataColumn[] { table.Columns["BusinessEntityID"] };

DataRow row = table.Rows.Find(1);

foreach (DataColumn customersColumn in table.Columns)
    Console.WriteLine(customersColumn.ColumnName + " " + row[customersColumn]);

Console.ReadKey();
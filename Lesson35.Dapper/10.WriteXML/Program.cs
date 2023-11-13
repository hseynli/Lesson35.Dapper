using Microsoft.Data.SqlClient;
using System.Data;

string connectionString = @"Data Source=.;Initial Catalog=AdventureWorks2019;Integrated Security=True;TrustServerCertificate=True";
string sql = "SELECT * FROM Person.Person";
using (SqlConnection connection = new SqlConnection(connectionString))
{
    connection.Open();
    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);

    DataSet ds = new DataSet("Persons");
    DataTable dt = new DataTable("Person");
    ds.Tables.Add(dt);
    adapter.Fill(ds.Tables["Person"]);

    ds.WriteXml(Guid.NewGuid().ToString("N") + ".xml");

    Console.WriteLine("Ok!");

    Console.ReadKey();
}
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace CodeTest.AppSettings;

public class AppDbContext
{
    public static SqlConnectionStringBuilder _connBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "",
        UserID = "",
        Password = "",
        TrustServerCertificate = true
    };
}

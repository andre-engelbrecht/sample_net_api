using Microsoft.Data.SqlClient;

namespace Sample_API.ConnectionGenerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"{NewSqlServerTCPConnectionString()}");
            Console.ReadKey();
        }

        public static SqlConnectionStringBuilder NewSqlServerTCPConnectionString()
        {
            // Equivalent connection string:
            // "User Id=<DB_USER>;Password=<DB_PASS>;Server=<INSTANCE_HOST>;Database=<DB_NAME>;"
            var connectionString = new SqlConnectionStringBuilder()
            {
                // Note: Saving credentials in environment variables is convenient, but not
                // secure - consider a more secure solution such as
                // Cloud Secret Manager (https://cloud.google.com/secret-manager) to help
                // keep secrets safe.
                DataSource = "10.43.160.3", // Environment.GetEnvironmentVariable("INSTANCE_HOST"), // e.g. '127.0.0.1'
                // Set Host to 'cloudsql' when deploying to App Engine Flexible environment
                UserID = "sqlserver", // Environment.GetEnvironmentVariable("DB_USER"),         // e.g. 'my-db-user'
                Password = "Shadow@14", // Environment.GetEnvironmentVariable("DB_PASS"),       // e.g. 'my-db-password'
                InitialCatalog = "Sample_API.Dev", // Environment.GetEnvironmentVariable("DB_NAME"), // e.g. 'my-database'

                // The Cloud SQL proxy provides encryption between the proxy and instance
                Encrypt = false,
            };
            connectionString.Pooling = true;
            // Specify additional properties here.
            return connectionString;
        }
    }
}
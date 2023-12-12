using System.Data.SqlClient;
using webapp.Models;

namespace webapp.Services
{
    public class ProductService
    {
        private static string db_source = "appserver0503.database.windows.net";
        private static string db_user = "sqladmin";
        private static string db_password = "password!123";
        private static string db_database = "appdb";

        private SqlConnection GetConnection()
        {
            var builder = new SqlConnectionStringBuilder();
            builder.DataSource = db_source;
            builder.UserID = db_user;
            builder.Password = db_password;
            builder.InitialCatalog = db_database;
            return new SqlConnection(builder.ConnectionString);
        }

        public List<Product> GetProducts()
        {
            var conn = GetConnection();

            var products = new List<Product>();

            string statement = "SELECT ProductID, ProductName, Quantity FROM Products";

            conn.Open();

            var cmd = new SqlCommand(statement, conn);

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var product = new Product
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };

                    products.Add(product);
                }
            }

            conn.Close();
            return products;
        }
    }
}

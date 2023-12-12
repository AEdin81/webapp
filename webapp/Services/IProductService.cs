using System.Data.SqlClient;
using webapp.Models;

namespace webapp.Services;

public interface IProductService
{
    SqlConnection GetConnection();
    List<Product> GetProducts();
}
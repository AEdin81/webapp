using System.Data.SqlClient;
using webapp.Models;

namespace webapp.Services;

public interface IProductService
{
    SqlConnection GetConnection();
    Task<List<Product>> GetProducts();

    public Task<bool> IsBeta();
}
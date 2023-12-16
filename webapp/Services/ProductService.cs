using System.Data.SqlClient;
using System.Text.Json;
using Microsoft.FeatureManagement;
using webapp.Models;

namespace webapp.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;
        private readonly IFeatureManager _featureManager;

        public ProductService(IConfiguration configuration, IFeatureManager featureManager)
        {
            _configuration = configuration;
            _featureManager = featureManager;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration["SQLConnection"]);
        }

        public async Task<bool> IsBeta()
        {
            var isBeta = await _featureManager.IsEnabledAsync("beta");
            return isBeta;
        }

        public async Task<List<Product>> GetProducts()
        {
            var functionUrl = "https://edinfunctionapp0503.azurewebsites.net/api/GetProducts?code=3GfSX5cHplQfpin4EgQvqqyTQpgkmcS-LD5sAxq7E2oCAzFuE-8WoA==";

            using var client = new HttpClient();

            var response = await client.GetAsync(functionUrl);

            string content = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<Product>>(content);
        }
    }
}

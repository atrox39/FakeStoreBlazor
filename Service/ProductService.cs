using System.Net.Http.Json;

namespace FakeStore.Service
{
  public class Rating
  {
    public double Rate { get; set; }
    public int Count { get; set; }
  }

  public class Product
  {
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public double Price { get; set; }
    public string Category { get; set; } = null!;
    public string Image { get; set; } = null!;

    public Rating Rating { get; set; } = null!;
  }

  public interface IProductService
  {
    public Task<List<Product>> GetAll();
  }

  public class ProductService(HttpClient http) : IProductService
  {
    public async Task<List<Product>> GetAll()
    {
      var res = await http.GetFromJsonAsync<List<Product>>("https://fakestoreapi.com/products");
      if (res is null) {
        return [];
      }
      return res;
    }
  }
}
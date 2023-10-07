using Products.Models;
using System.Text.Json;

namespace Products.Services;

public class ProductsService : IProductsService
{
	
	// for now I just want to do it all in-mem
	// so what do I do here?

	// json to map?

	// how do I fetch only one product?

	//private readonly Dictionary<int, Product> _products = new();
	private readonly List<Product>? _products = new();

	public ProductsService() {
		string jsonFilePath = "Products.json";
		if(File.Exists(jsonFilePath)) {
			string jsonString = File.ReadAllText("Products.json");
			
			// Create a custom JSON serializer options to handle property name differences
			JsonSerializerOptions options = new()
			{
				PropertyNameCaseInsensitive = true,
			};
			
			List<Product>? products = JsonSerializer.Deserialize<List<Product>>(jsonString,  options);
			
			_products = products;

		} else {
			Console.WriteLine($"Json File {jsonFilePath} does not exist.");
		}

	}

	public Product FetchProduct(int id)
	{
		throw new NotImplementedException();
	}
}
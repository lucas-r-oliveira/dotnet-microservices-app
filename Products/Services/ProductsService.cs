using Products.Models;
using System.Text.Json;
using ErrorOr;
using Products.ServiceErrors;

namespace Products.Services;

public class ProductsService : IProductsService
{
	
	// for now I just want to do it all in-mem
	// so what do I do here?

	// json to map?

	// how do I fetch only one product?

	//private readonly Dictionary<int, Product> _products = new();
	//private readonly List<Product>? _products = new();
	private readonly Dictionary<int, Product> _products = new();

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
			if(products != null) {
				foreach(var product in products) {
					_products.Add(product.ID, product);
				}
			}
			

		} else {
			Console.WriteLine($"Json File {jsonFilePath} does not exist.");
		}

	}

	public List<Product> GetAllProducts()
	{
		return _products.Values.ToList();
	}

	/*public ErrorOr<Product> GetProductById(int id)
	{	
		if (_products.TryGetValue(id, out var product)) {
			/* {
				Console.WriteLine(product.ID);
				Console.WriteLine(product.Title);
				Console.WriteLine(product.Description);
				Console.WriteLine(product.Price);
				Console.WriteLine(product.Category);
				Console.WriteLine(product.Brand);
			} */
		/*	return product;
		} 
		return Errors.Products.NotFound;		
	}*/

	public Product? GetProductById(int id) {
		if(_products.TryGetValue(id, out var product)) {
			return product;
		}
		return null;
	}

	public Product AddProduct(Product product)
	{
		_products.Add(product.ID, product);
		return product;
	}

	public bool DeleteProduct(int id)
	{
		throw new NotImplementedException();
	}

	public Product UpdateProduct(Product product)
	{
		throw new NotImplementedException();
	}


	public int GetProductCount() {
		return _products.Count;
	}
}
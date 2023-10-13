using Products.Models;
using ErrorOr;
namespace Products.Services;


public interface IProductsService {
	public List<Product> GetAllProducts();
	public ErrorOr<Product> GetProductById(int id);
	public Product AddProduct(Product product);
	public Product UpdateProduct(Product product);
	public bool DeleteProduct(int id);

	public int GetProductCount();

}
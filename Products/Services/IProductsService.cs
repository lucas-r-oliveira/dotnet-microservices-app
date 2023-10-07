using Products.Models;
using ErrorOr;
namespace Products.Services;


public interface IProductsService {
	ErrorOr<Product> FetchProduct(int id);
}
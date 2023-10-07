using Products.Models;
namespace Products.Services;


public interface IProductsService {
	Product FetchProduct(int id);
}
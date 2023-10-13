using Products.Contracts;
using Products.Models;

namespace Products;

// HOW DOES THIS WORK?
// WHY IS IT SO EASILY RECOGNIZABLE?

public static class Extensions {
	public static ProductDto AsDto(this Product product) {
		return new ProductDto(
			product.ID,
			product.Title,
			product.Description,
			product.Price,
			product.Brand,
			product.Category
		);
	}
}
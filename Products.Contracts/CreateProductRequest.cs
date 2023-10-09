namespace Products.Contracts;

public record CreateProductRequest(
	string Name,
	string Description,
	float Price,
	string Brand,
	string Category
);
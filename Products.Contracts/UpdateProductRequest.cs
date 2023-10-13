namespace Products.Contracts;

public record UpdateProductRequest(
	string Name,
	string Description,
	float Price,
	string Brand,
	string Category
);
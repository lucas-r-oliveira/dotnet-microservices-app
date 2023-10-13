namespace Products.Contracts;

public record ProductDto(
	int ID,
	string Name,
	string Description,
	float Price,
	string Brand,
	string Category
);
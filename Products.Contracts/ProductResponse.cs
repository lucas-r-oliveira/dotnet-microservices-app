namespace Products.Contracts;

public record ProductResponse(
	int ID,
	string Name,
	string Description,
	float Price,
	string Brand,
	string Category
);
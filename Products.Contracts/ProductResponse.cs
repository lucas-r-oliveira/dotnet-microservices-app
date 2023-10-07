namespace Products.Contracts;

public record ProductResponse(
	int ID,
	string Name,
	string Description,
	int Price,
	string Brand,
	string Category
);
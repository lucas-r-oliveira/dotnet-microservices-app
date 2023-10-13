namespace Products.Contracts;

public record CreateOrUpdateProductDto(
	string Name,
	string Description,
	float Price,
	string Brand,
	string Category
);
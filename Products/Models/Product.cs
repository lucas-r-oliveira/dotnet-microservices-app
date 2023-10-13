using System.Text.Json.Serialization;

namespace Products.Models;

public class Product
{
	public int ID { get;  }
	[JsonPropertyName("title")]
	public string Name { get; set; }
	public string Description { get; set; }
	public float Price { get; set; }
	public string Brand { get; set; }
	public string Category { get; set; }


	public Product(
		int id, 
		string name, 
		string description, 
		float price, 
		string brand, 
		string category
	)
	{
		// enforce constraints / invariants here
		ID = id;
		Name = name;
		Description = description;
		Price = price; 
		Brand = brand;
		Category = category;
	}
}
namespace Products.Models;

public class Product
{
	public int ID { get;  }
	public string Title { get;  }
	public string Description { get;  }
	public int Price { get;  }
	public string Brand { get;  }
	public string Category { get;  }


	public Product(
		int id, 
		string title, 
		string description, 
		int price, 
		string brand, 
		string category
	)
	{
		// enforce constraints / invariants here
		ID = id;
		Title = title;
		Description = description;
		Price = price; 
		Brand = brand;
		Category = category;
	}
}
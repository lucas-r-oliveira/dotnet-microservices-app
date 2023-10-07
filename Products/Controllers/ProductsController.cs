using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Services;
using Products.ServiceErrors;
using ErrorOr;
using Products.Contracts;

namespace Products.Controllers;

[Route("[controller]")]
public class ProductsController : ApiController {
// every time a new request is sent to the service, 
// the framework creates a new controller object
	private readonly IProductsService _productsService;

	public ProductsController(IProductsService productsService) {
		_productsService = productsService;
	}

	[HttpGet]
	public IActionResult ListAllProducts() {
		// Let's return a json with all the items
		// for now
		string allText = System.IO.File.ReadAllText("Products.json");

		JsonNode? json = JsonObject.Parse(allText);

		return Ok(json);
	}

	[HttpGet("{id:int}")]
	public IActionResult GetProduct(int id){
		ErrorOr<Product> getProductResult = _productsService.FetchProduct(id: id);
		
		// this line summarizes the code that is commented
		return getProductResult.Match(
			product => Ok(MapProductResponse(product)),
			errors => Problem(errors)
		);
		
		
		/* if (getProductResult.IsError && getProductResult.FirstError == Errors.Products.NotFound) {
			return NotFound();
		}

		Product product = getProductResult.Value;

		var response = new ProductResponse(
			product.ID,
			product.Title,
			product.Description,
			product.Price,
			product.Brand,
			product.Category
		);

		return Ok(response); */
	}

	private static ProductResponse MapProductResponse(Product product) {
		return new ProductResponse(
			product.ID,
			product.Title,
			product.Description,
			product.Price,
			product.Brand,
			product.Category
		);
	}

}
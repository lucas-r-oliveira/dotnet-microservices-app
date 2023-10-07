using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Products.Services;

namespace Products.Controllers;

[ApiController] // ASP.NET
[Route("api/[controller]")]
public class ProductsController : ControllerBase {
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
		Product product = _productsService.FetchProduct(id: id);
		return Ok();
	}

}
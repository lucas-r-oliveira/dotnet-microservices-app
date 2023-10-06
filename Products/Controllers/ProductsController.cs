using Microsoft.AspNetCore.Mvc;

namespace Products.Controllers;

[ApiController] // ASP.NET
public class ProductsController : ControllerBase {

	[HttpGet("/products")]
	public IActionResult ListProducts() {
		return Ok("Well done");
	}

}
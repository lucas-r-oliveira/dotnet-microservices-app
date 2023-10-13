using Microsoft.AspNetCore.Mvc;

namespace Products.Controllers;

public class ErrorsController : ControllerBase {
	[Route("/error")]
	[HttpGet]
	public IActionResult Error() {

		// in here, we can have whatever
		// error handling logic we want

		// returns 500 internal server error
		// hides sensitive details
		return Problem(); 
	}
}
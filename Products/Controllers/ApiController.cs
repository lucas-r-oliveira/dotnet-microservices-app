using Microsoft.AspNetCore.Mvc;
using ErrorOr;

namespace Products.Controllers;

[ApiController] // ASP.NET
[Route("[controller]")]
public class ApiController : ControllerBase {
	// We're overriding the Problem method
	protected IActionResult Problem(List<Error> errors) {
		var firstError = errors[0];
		var statusCode = firstError.Type switch {
			ErrorType.NotFound => StatusCodes.Status404NotFound,
			ErrorType.Validation => StatusCodes.Status400BadRequest,
			ErrorType.Conflict => StatusCodes.Status409Conflict,
			_ => StatusCodes.Status500InternalServerError
		};
		
		return Problem(statusCode: statusCode, title: firstError.Description);
	}
}
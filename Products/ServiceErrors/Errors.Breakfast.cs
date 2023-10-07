using ErrorOr;

namespace Products.ServiceErrors;

public static class Errors {
	public static class Products {
		public static Error NotFound => Error.NotFound(
			code: "Products.NotFound",
			description: "Product not found"
		);
	}
}
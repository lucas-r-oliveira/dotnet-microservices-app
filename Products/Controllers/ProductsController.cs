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
	private readonly IMessageProducer _messageProducerService;

	// In-mem db
	// public static readonly Dict _products = new(); ...

	public ProductsController(IProductsService productsService, IMessageProducer messageProducer) {
		_productsService = productsService;
		_messageProducerService =  messageProducer;
	}

	[HttpGet]
	public IEnumerable<ProductDto> GetAllProducts() {
		var productsList = _productsService.GetAllProducts()
			.Select(product => product.AsDto());
		
		return productsList;
	}

	[HttpGet("{id:int}")]
	public ActionResult<ProductDto> GetProductById(int id) {
		var product = _productsService.GetProductById(id);
		if(product == null) {
			return NotFound("The product you requested does not exist");
		}
		return product.AsDto();
	}


	/*public IActionResult GetProductById(int id){
		ErrorOr<Product> getProductResult = _productsService.GetProductById(id: id);
		
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

		return Ok(response); *//*
	}*/
	/*[HttpGet("{id:int}")]
	public ActionResult<ProductDto> GetProductById(int id){
		var product = _productsService.GetProductById(id);
		return Ok();
	}*/

	[HttpPost]
	public IActionResult CreateProduct(CreateProductRequest request) {
		var product = new Product(
			// this is not very accurate, but for example purposes, it suffices.
			_productsService.GetProductCount() + 1, 
			request.Name,
			request.Description,
			request.Price, 
			request.Brand,
			request.Category
		);
		
		_productsService.AddProduct(product);
		_messageProducerService.SendMessage<Product>(product);

		var response = MapProductResponse(product);

		return Ok(response); //TODO: refactor with ErrorOr
	}

	[HttpPut("id:int")]
	public IActionResult UpdateProduct(int id, UpdateProductRequest request) {
		return Ok();
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
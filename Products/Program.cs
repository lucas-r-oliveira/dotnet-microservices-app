using Products.Services;

var  builder = WebApplication.CreateBuilder(args);
{
	builder.Services.AddControllers();
	// every time the interface IProductsService is requested in the 
	// constructor, use the ProductsService as an implementation 
	// for the interface

	// use the same ProductsService object throughout the lifetime of the
	// application 
	builder.Services.AddSingleton<IProductsService, ProductsService>(); 
	builder.Services.AddScoped<IMessageProducer, MessageProducer>();
	//builder.Services.AddScoped<IProductsService, ProductsService>();
	//builder.Services.AddTransient<IProductsService, ProductsService>();
}

var app = builder.Build();
{	
	// each one of these acts as a middleware
	// this one in particular adds code that
	// surrounds the following middlewares with
	// try-catch blocks
	// If an exception is caught, the request
	// route is redefined to what we specify
	// and it is re-executed.
	app.UseExceptionHandler("/error");
	
	//app.UseHttpsRedirection();
	app.MapControllers();
	app.Run();
}


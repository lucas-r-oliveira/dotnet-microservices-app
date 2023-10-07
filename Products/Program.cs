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
	//builder.Services.AddScoped<IProductsService, ProductsService>();
	//builder.Services.AddTransient<IProductsService, ProductsService>();
}

var app = builder.Build();
{
	//app.UseHttpsRedirection();
	app.MapControllers();
	app.Run();
}


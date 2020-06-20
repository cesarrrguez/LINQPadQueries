<Query Kind="Program" />

// IoC (Inversion of Control)
// ----------------------------------------------------------
// Is a software principle where rather than having the 
// application call the methods in a framework, the framework
// calls implementations provided by the application.
// ----------------------------------------------------------

void Main()
{
    IProductService productService = new ProductService(new ProductRepository());
    
    var product = new Product
    {
        Id = 21,
        Description = "Product description"
    };
    
    productService.RegisterNewProduct(product);
}

// App.Domain.Entities
public class Product
{
    public int Id {get; set;}
    public string Description {get; set;}
}

// App.Domain.Interfaces.Repositories
public interface IProductRepository
{
    void Add(Product product);
}

// App.Domain.Interfaces.Services
public interface IProductService
{
    void RegisterNewProduct(Product product);
}

// App.Application.Services       
public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    
    public ProductService(IProductRepository productRepository) => 
        _productRepository = productRepository;
    
    public void RegisterNewProduct(Product product) =>
        _productRepository.Add(product);
}

// App.Infrastructure.Data
public class ProductRepository : IProductRepository
{
    public void Add(Product product) =>
        Console.WriteLine($"Adding product {product.Id} - {product.Description} into db");
}
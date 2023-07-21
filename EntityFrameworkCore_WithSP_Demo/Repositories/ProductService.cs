using EntityFrameworkCore_WithSP_Demo.Data;
using EntityFrameworkCore_WithSP_Demo.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore_WithSP_Demo.Repositories
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext dbContext;
        public ProductService(ApplicationDbContext _dbContext)
        {
            this.dbContext = _dbContext;
        }

        public async Task<List<Product>> GetProductListAsync()
        {
            var products = await this.dbContext.Product.FromSqlRaw<Product>("spGetProductList").ToListAsync();
            return products;
        }

        public async Task<IEnumerable<Product>> GetProductByIdAsync(int productId)
        {
            var productIdParam = new SqlParameter("@productId", productId);
            var product = await Task.Run(() => this.dbContext.Product.FromSqlRaw(@"exec spGetProductById @productId", productIdParam).ToListAsync());
            return product;
        }

        public async Task<int> AddProductAsync(Product product)
        {
            var paratemers = new List<SqlParameter>();
            paratemers.Add(new SqlParameter("@productName", product.ProductName));
            paratemers.Add(new SqlParameter("@productDescription", product.ProductDescription));
            paratemers.Add(new SqlParameter("@productPrice", product.ProductPrice));
            paratemers.Add(new SqlParameter("@productStock", product.ProductStock));

            var result = await Task.Run(() => this.dbContext.Database.ExecuteSqlRawAsync(@"exec spCreateProduct @productName, @productDescription, @productPrice, @productStock", paratemers.ToArray()));

            return result;
        }

        public async Task<int> UpdateProductAsync(Product product)
        {
            var paratemers = new List<SqlParameter>();
            paratemers.Add(new SqlParameter("@productId", product.ProductId));
            paratemers.Add(new SqlParameter("@productName", product.ProductName));
            paratemers.Add(new SqlParameter("@productDescription", product.ProductDescription));
            paratemers.Add(new SqlParameter("@productPrice", product.ProductPrice));
            paratemers.Add(new SqlParameter("@productStock", product.ProductStock));

            var result = await Task.Run(() => this.dbContext.Database.ExecuteSqlRawAsync(@"exec spUpdateProduct @productId, @productName, @productDescription, @productPrice, @productStock", paratemers.ToArray()));

            return result;
        }

        public async Task<int> DeleteProductAsync(int productId)
        {
            var result = await Task.Run(() => this.dbContext.Database.ExecuteSqlInterpolatedAsync($"spDeleteProduct {productId}"));
            return result;
        }
    }
}
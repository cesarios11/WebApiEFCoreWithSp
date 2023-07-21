using EntityFrameworkCore_WithSP_Demo.Entities;
using EntityFrameworkCore_WithSP_Demo.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EntityFrameworkCore_WithSP_Demo.Controllers
{
    [ApiController]
    [Route("Products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        public ProductController(IProductService _productService)
        {
            this.productService = _productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductListAsync1()
        {
            try
            {
                var products = await this.productService.GetProductListAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getProductList")]
        public async Task<IActionResult> GetProductListAsync2()
        {
            try
            {
                var products = await this.productService.GetProductListAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{idProduct:int}")]
        public async Task<IActionResult> GetProductByIdAsync1(int idProduct)
        {
            try
            {
                var product = await this.productService.GetProductByIdAsync(idProduct);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getProductById")]
        public async Task<IActionResult> GetProductByIdAsync2(int idProduct)
        {
            try
            {
                var product = await this.productService.GetProductByIdAsync(idProduct);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductAsync1(Product product)
        {
            try
            {
                if (product != null)
                {
                    var result = await this.productService.AddProductAsync(product);
                    return Ok(result);
                }
                else
                {
                    return BadRequest("El objeto no puede ser nulo");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("createProduct")]
        public async Task<IActionResult> CreateProductAsync2(Product product)
        {
            try
            {
                if (product != null)
                {
                    var result = await this.productService.AddProductAsync(product);
                    return Ok(result);
                }
                else
                {
                    return BadRequest("El objeto no puede ser nulo");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync1(Product product)
        {
            try
            {
                if (product != null)
                {
                    var result = await this.productService.UpdateProductAsync(product);
                    return Ok(result);
                }
                else
                {
                    return BadRequest("El objeto no puede ser nulo");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("updateProduct")]
        public async Task<IActionResult> UpdateProductAsync2(Product product)
        {
            try
            {
                if (product != null)
                {
                    var result = await this.productService.UpdateProductAsync(product);
                    return Ok(result);
                }
                else
                {
                    return BadRequest("El objeto no puede ser nulo");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{idProduct:int}")]
        public async Task<IActionResult> DeleteProductAsync1(int idProduct)
        {
            try
            {
                var result = await this.productService.DeleteProductAsync(idProduct);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteProduct")]
        public async Task<IActionResult> DeleteProductAsync2(int idProduct)
        {
            try
            {
                var result = await this.productService.DeleteProductAsync(idProduct);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
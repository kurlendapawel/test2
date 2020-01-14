using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Infrastucture.DTOs;
using Application.Infrastucture.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Application.WebApi.Controllers
{
    [Route("v1")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(
            IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        public async Task<IActionResult> Get()
        {
            var result =  await _productService.GetAll();
            return Ok(result);
        }

        [HttpGet("product/{product_id}")]
        public async Task<IActionResult> Get(int product_id)
        {
            var result = await _productService.Get(product_id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost("product")]
        public async Task<IActionResult> Post([FromHeader]ProductDto product)
        {
            var result = await _productService.Add(product);

            return Ok(result);
        }

        [HttpPut("product/{product_id}")]
        public async Task<IActionResult> Put([FromHeader]ProductDto product, int product_id)
        {
            var result = await _productService.Update(product, product_id);

            if (result)
                return Ok();

            return NotFound();
        }

        [HttpDelete("product/{product_id}")]
        public async Task<IActionResult> Delete(int product_id)
        {
            var result = await _productService.Delete(product_id);

            if (result)
                return Ok();

            return NotFound();
        }
    }
}
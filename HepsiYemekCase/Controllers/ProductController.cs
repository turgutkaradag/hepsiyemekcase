using HepsiYemekCase.Infrastructure;
using HepsiYemekCase.Infrastructure.Abstractions.Redis;
using HepsiYemekCore.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HepsiYemekCase.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICache _cache;
        public ProductController(IProductService productService, ICache cache)
        {
            _productService = productService;
            _cache = cache;
        }
        [HttpGet("{id:length(24)}")]
        public ActionResult<Products> Get(string id)
        {
            var data = _productService.Get(id);
            if (data == null)
            {
                return NotFound();
            }
            string key = "Product_Key";
            if (!_cache.Exists(key))
            {
                _cache.Set(key, data, DateTime.Now.AddMinutes(5));
            }
            if (_cache.Exists(key))
            {
                var cachedData = _cache.Get<Products>(key);
                return Ok(cachedData);
            }
            return data;

        }
        [HttpPost]
        public ActionResult<Products> Create(Products product)
        {
            _productService.Create(product);
            return CreatedAtRoute(new { id = product.Id.ToString() }, product);
        }
        [HttpPut("{id:length(24)}")]
        public ActionResult<Products> Update(string id, Products productIn)
        {
            var product = _productService.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            _productService.Update(id, productIn);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public ActionResult<List<Products>> Delete(string id)
        {
            var product = _productService.Get(id);
            if (product == null)
            {
                return NotFound();
            }
            _productService.Remove(id);
            return NoContent();
        }

    }
}

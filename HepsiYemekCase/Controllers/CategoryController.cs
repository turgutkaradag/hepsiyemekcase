using HepsiYemekCase.Infrastructure.Interfaces;
using HepsiYemekCore.Core.Entities;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("{id:length(24)}")]
        public ActionResult<Categories> Get(string id)
        {
            var data = _categoryService.Get(id);
            if (data == null)
            {
                return NotFound();
            }
            return data;
        }
        [HttpPost]
        public ActionResult<Categories> Create(Categories category)
        {
            _categoryService.Create(category);
            return CreatedAtRoute(new { id = category.Id.ToString() }, category);
        }
        [HttpPut("{id:length(24)}")]
        public ActionResult<Categories> Update(string id, Categories categoryIn)
        {
            var data = _categoryService.Get(id);
            if (data == null)
            {
                return NotFound();
            }
            _categoryService.Update(id, categoryIn);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public ActionResult<List<Categories>> Delete(string id)
        {
            var data = _categoryService.Get(id);
            if (data==null)
            {
                return NotFound();
            }
            _categoryService.Remove(id);
            return NoContent();
        }
    }
}

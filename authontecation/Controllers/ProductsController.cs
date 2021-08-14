using authontecation.Authontecation;
using Microsoft.AspNetCore.Mvc;
using repo.interfces;
using repo.Models;
using repo.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        public IProductRepo ProductRepo { get; set; }
        public ProductsController(IProductRepo Product)
        {
            ProductRepo = Product;
        }

       // [HttpPost("Create")]
       [HttpPost]
        public IActionResult Create(ProductsVM Product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var c = ProductRepo.Add(Product);
                    return Ok(c);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }

            var data = new response();
            var errors = ModelState.Values;
            foreach (var item in errors)
            {
                data.Errors.Add(item.Errors.ToString());
            }
            data.Message = "Invalid Data";
            data.Status = "Error";
            return BadRequest(data);
        }

       // [HttpGet("GetAll")]
       [HttpGet]
        public IActionResult Get()
        {
            var data = ProductRepo.GetAll();
            return Ok(data);
        }

       // [HttpPost("Delete")]
       [HttpDelete]
        public IActionResult Delete(int id)
        {
            var data = ProductRepo.Delete(id);
            if (data == null)
                return BadRequest(new response { Message = "Can Not Delete", Status = "Error" });
            return Ok(data);
        }
       // [HttpPost("Edit")]
       [HttpPut]
        public IActionResult Edit(ProductsVM ob)
        {
            var data = ProductRepo.Edit(ob);
            if (data == null)
                return BadRequest(new response { Message = "Can Not Edit", Status = "Error" });
            return Ok(data);
        }
        [HttpPost("GetById")]
        public IActionResult GetById(int id)
        {
            var data=ProductRepo.GetById(id);
            if (data == null)
                return BadRequest(new response { Message = "Not Found", Status = "Error" });
            return Ok(data);
        }

    }
}

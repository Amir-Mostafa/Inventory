using authontecation.Authontecation;
using Microsoft.AspNetCore.Mvc;
using repo.interfces;
using repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        public ISupplierRepo SupplierRepo { get; set; }
        public SuppliersController (ISupplierRepo Supplier)
        {
            SupplierRepo = Supplier;
        }

      //  [HttpPost("Create")]
      [HttpPost]
        public IActionResult Create(SuppliersVM Supplier)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var c = SupplierRepo.Add(Supplier);
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
            var data = SupplierRepo.GetAll();
            return Ok(data);
        }

        //[HttpPost("Delete")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = SupplierRepo.Delete(id);
            if (data == null)
                return BadRequest(new response { Message = "Can Not Delete", Status = "Error" });
            return Ok(data);
        }
       // [HttpPost("Edit")]
       [HttpPut]
        public IActionResult Edit(SuppliersVM ob)
        {
            var data = SupplierRepo.Edit(ob);
            if (data == null)
                return BadRequest(new response { Message = "Can Not Edit", Status = "Error" });
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            var data = SupplierRepo.GetById(id);
            if (data == null)
                return BadRequest(new response { Message = "Not Found", Status = "Error" });
            return Ok(data);
        }
        [HttpGet("{name}")]
        public IActionResult Search(string name)
        {
           var data=SupplierRepo.Search(name);
            if (data == null)
                return BadRequest(new response { Message = "Not Found", Status = "Error" });
            return Ok(data);
        }



    }
}

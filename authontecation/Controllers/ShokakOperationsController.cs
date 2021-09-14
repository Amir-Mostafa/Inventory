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
    public class ShokakOperationsController : ControllerBase
    {
        public IShokakOperationRepo ShokakOperationRepo { get; set; }
        public ShokakOperationsController(IShokakOperationRepo ShokakOperation)
        {
            ShokakOperationRepo = ShokakOperation;
        }

       // [HttpPost("Create")]
       [HttpPost]
        public IActionResult Create(ShokakOperationVM ShokakOperation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var c = ShokakOperationRepo.Add(ShokakOperation);
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
            var data = ShokakOperationRepo.GetAll();
            return Ok(data);
        }

        //[HttpPost("Delete")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = ShokakOperationRepo.Delete(id);
            if (data == null)
                return BadRequest(new response { Message = "Can Not Delete", Status = "Error" });
            return Ok(data);
        }
        //[HttpPost("Edit")]
        [HttpPut]
        public IActionResult Edit(ShokakOperationVM ob)
        {
            var data = ShokakOperationRepo.Edit(ob);
            if (data == null)
                return BadRequest(new response { Message = "Can Not Edit", Status = "Error" });
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data=ShokakOperationRepo.GetById(id);
            if (data == null)
                return BadRequest(new response { Message = "Not Found", Status = "Error" });
            return Ok(data);
        }

        [HttpGet("clientOperations/{id}")]
        public IActionResult clientOperations(int id)
        {
            var data = ShokakOperationRepo.clientOperations(id);
            if (data == null)
                return Ok(new response { Message = "Not Found", Status = "Error" });
            return Ok(data);
        }

    }
}

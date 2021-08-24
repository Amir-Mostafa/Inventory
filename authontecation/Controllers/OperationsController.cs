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
    public class OperationsController : ControllerBase
    {
        public IOperationRepo OperationRepo { get; set; }
        public OperationsController(IOperationRepo Operation)
        {
            OperationRepo = Operation;
        }

        //[HttpPost("Create")]
        [HttpPost]
        public IActionResult Create(OperationsVM Operation)
        {
            if (ModelState.IsValid)
            {
                //try
                //{
                    var c = OperationRepo.Add(Operation);
                    return Ok(c);
              //  }
                //catch (Exception ex)
                //{
                //    return BadRequest(ex.Message);
                //}

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

      //  [HttpGet("GetAll")]
      [HttpGet]
        public IActionResult Get()
        {
            var data = OperationRepo.GetAll();
            return Ok(data);
        }

      //  [HttpPost("Delete")]
      [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = OperationRepo.Delete(id);
            if (data == null)
                return BadRequest(new response { Message = "Can Not Delete", Status = "Error" });
            return Ok(data);
        }
      //  [HttpPost("Edit")]
      [HttpPut]
        public IActionResult Edit(OperationsVM ob)
        {
            var data = OperationRepo.Edit(ob);
            if (data == null)
                return BadRequest(new response { Message = "Can Not Edit", Status = "Error" });
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data=OperationRepo.GetById(id);
            if (data == null)
                return BadRequest(new response { Message = "Not Found", Status = "Error" });
            return Ok(data);
        }
        [HttpGet("OperationsByOrderId/{id}")]
        public IActionResult OperationsByOrderId(int id)
        {
            var data = OperationRepo.OperationsByOrderId(id);
            if (data == null)
                return BadRequest(new response { Message = "Not Found", Status = "Error" });
            return Ok(data);
        }
    }
}

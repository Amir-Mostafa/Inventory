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
    public class BuyOperationsController : ControllerBase
    {
        public IBuyOperationRepo BuyOperationRepo { get; set; }
        public BuyOperationsController(IBuyOperationRepo BuyOperation)
        {
            BuyOperationRepo = BuyOperation;
        }

        // [HttpPost("Create")]
        [HttpPost]
        public IActionResult Create(BuyOperationsVM BuyOperation)
        {
            if (ModelState.IsValid)
            {
                //try
                //{
                    var c = BuyOperationRepo.Add(BuyOperation);
                    return Ok(c);
                //}
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

       // [HttpGet("GetAll")]
       [HttpGet]

        public IActionResult Get()
        {
            var data = BuyOperationRepo.GetAll();
            return Ok(data);
        }

        //[HttpPost("Delete")]
        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            var data = BuyOperationRepo.Delete(id);
            if (data == null)
                return BadRequest(new response { Message = "Can Not Delete", Status = "Error" });
            return Ok(data);
        }
        //[HttpPost("Edit")]
        [HttpPut]
        public IActionResult Edit(BuyOperationsVM ob)
        {
            var data = BuyOperationRepo.Edit(ob);
            if (data == null)
                return BadRequest(new response { Message = "Can Not Edit", Status = "Error" });
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
           var data=BuyOperationRepo.GetById(id);
            if (data == null)
                return BadRequest(new response { Message = "Not Found", Status = "Error" });
            return Ok(data);
        }
        [HttpGet("OperationsByOrderId/{id}")]
        public IActionResult OperationsByOrderId(int id)
        {
            var data = BuyOperationRepo.buyOperationsByOrderId(id);
            if (data == null)
                return BadRequest(new response { Message = "Not Found", Status = "Error" });
            return Ok(data);
        }
    }
}

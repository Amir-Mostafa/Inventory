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
    public class BuyOrderController : ControllerBase
    {
        public IBuyOrderRepo BuyOrderRepo { get; set; }
        public BuyOrderController(IBuyOrderRepo BuyOrder)
        {
            BuyOrderRepo = BuyOrder;
        }

        //[HttpPost("Create")]
        [HttpPost]
        public IActionResult Create(BuyOrderVM BuyOrder)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var c = BuyOrderRepo.Add(BuyOrder);
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

      //  [HttpGet("GetAll")]
      [HttpGet]
        public IActionResult Get()
        {
            var data = BuyOrderRepo.GetAll();
            return Ok(data);
        }

        //[HttpPost("Delete")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = BuyOrderRepo.Delete(id);
            if (data == null)
                return BadRequest(new response { Message = "Can Not Delete", Status = "Error" });
            return Ok(data);
        }
       // [HttpPost("Edit")]
       [HttpPut]
        public IActionResult Edit(BuyOrderVM ob)
        {
            var data = BuyOrderRepo.Edit(ob);
            if (data == null)
                return BadRequest(new response { Message = "Can Not Edit", Status = "Error" });
            return Ok(data);
        }
        [HttpPost("{id}")]
        public IActionResult GetById(int id)
        {
           var data=BuyOrderRepo.GetById(id);
            if (data == null)
                return BadRequest(new response { Message = "Not Found", Status = "Error" });
            return Ok(data);
        }

    }
}

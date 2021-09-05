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
    public class OrdersController : ControllerBase
    {
        public IOrderRepo OrderRepo { get; set; }
        public OrdersController(IOrderRepo Order)
        {
            OrderRepo = Order;
        }

      //  [HttpPost("Create")]
      [HttpPost]
        public IActionResult Create(OrdersVM Order)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var c = OrderRepo.Add(Order);
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
            var data = OrderRepo.GetAll();
            return Ok(data);
        }

       // [HttpPost("Delete")]
       [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var data = OrderRepo.Delete(id);
            if (data == null)
                return BadRequest(new response { Message = "Can Not Delete", Status = "Error" });
            return Ok(data);
        }
       // [HttpPost("Edit")]
       [HttpPut]
        public IActionResult Edit(OrdersVM ob)
        {
            var data = OrderRepo.Edit(ob);
            if (data == null)
                return Ok(new response { Message = "Can Not Edit", Status = "Error" });
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
          var data=OrderRepo.GetById(id);
            if (data == null)
                return Ok(new response { Message = "Not Found", Status = "Error" });
            return Ok(data);
        }
        [HttpGet("NextOrder/{id}")]
        public IActionResult NextOrder(int id)
        {
            var data = OrderRepo.NextOrder(id);
            if (data == null)
                return Ok(new response { Message = "Not Found", Status = "Error" });
            return Ok(data);
        }

        [HttpGet("PrevOrder/{id}")]
        public IActionResult PrevOrder(int id)
        {
            var data = OrderRepo.PrevOrder(id);
            if (data == null)
                return Ok(new response { Message = "Not Found", Status = "Error" });
            return Ok(data);
        }

        [HttpGet("LastOrder")]
        public IActionResult LastOrder()
        {
            var data = OrderRepo.LastOrder();
            if (data == null)
                return Ok(new response { Message = "Not Found", Status = "Error" });
            return Ok(data);
        }
    }
}

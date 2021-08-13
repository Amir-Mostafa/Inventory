using authontecation.Authontecation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [Authorize]

    public class CityController : ControllerBase
    {

        public ICityRepo CityRepo { get; set; }
        public CityController(ICityRepo city)
        {
            CityRepo = city;
        }

        [HttpPost]
        public IActionResult Create(CityVM client)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var c = CityRepo.Add(client);
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

        [HttpGet]

        
        public IActionResult Get()
        {
            var data = CityRepo.GetAll();
            return Ok(data);
        }

        [HttpDelete]
        public IActionResult Delete(CityVM ob)
        {
            var data = CityRepo.Delete(ob);
            if (data == null)
                return BadRequest(new response { Message = "Can Not Delete", Status = "Error" });
            return Ok(data);
        }
        [HttpPut]
        public IActionResult Edit(CityVM ob)
        {
            var data = CityRepo.Edit(ob);
            if (data == null)
                return BadRequest(new response { Message = "Can Not Edit", Status = "Error" });
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(CityRepo.GetById(id));
        }
        [HttpPost("{name}")]
        public IActionResult Search(string name)
        {
            return Ok(CityRepo.Search(name));
        }
    }
}

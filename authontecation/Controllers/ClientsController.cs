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
    public class ClientsController : ControllerBase
    {
        public IClientRepo ClientRepo { get; set; }
        public ClientsController(IClientRepo client)
        {
            ClientRepo = client;
        }

<<<<<<< HEAD
        //[HttpPost("Create")]
=======
>>>>>>> 80b442fecf3016c825ac67da35ce6bbc875c5461
        [HttpPost]
        public IActionResult Create(ClientVM client)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var c=ClientRepo.Add(client);
                    return Ok(c);
                }
                catch(Exception ex)
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

<<<<<<< HEAD
       // [HttpGet("GetAll")]
        [HttpGet]
=======
        [HttpGet]        
>>>>>>> 80b442fecf3016c825ac67da35ce6bbc875c5461
        public IActionResult Get()
        {
            var data = ClientRepo.GetAll();
            return Ok(data);
        }

<<<<<<< HEAD
       // [HttpPost("Delete")]
       [HttpDelete]
=======
        [HttpDelete("{id}")]
>>>>>>> 80b442fecf3016c825ac67da35ce6bbc875c5461
        public IActionResult Delete(int id)
        {
            var data = ClientRepo.Delete(id);
            if(data==null)
                return BadRequest(new response { Message = "Can Not Delete" ,Status="Error"});
            return Ok(data);
        }
<<<<<<< HEAD
       // [HttpPost("Edit")]
       [HttpPut]
=======
        [HttpPut]
>>>>>>> 80b442fecf3016c825ac67da35ce6bbc875c5461
        public IActionResult Edit(ClientVM ob)
        {
            var data = ClientRepo.Edit(ob);
            if (data == null)
                return BadRequest(new response { Message = "Can Not Edit", Status = "Error" });
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var data=ClientRepo.GetById(id);
            if (data == null)
                return BadRequest(new response { Message = "Not Found", Status = "Error" });
            return Ok(data);
        }

        
        [HttpPost("{name}")]
        public IActionResult Search(string name)
        {
            var data=ClientRepo.Search(name);
            if (data == null)
                return BadRequest(new response { Message = "Not Found", Status = "Error" });
            return Ok(data);
        }

    }
}


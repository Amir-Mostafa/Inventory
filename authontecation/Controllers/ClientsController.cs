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
    
    
    public class ClientsController : ControllerBase
    {
        public IClientRepo ClientRepo { get; set; }
        public ClientsController(IClientRepo client)
        {
            ClientRepo = client;
        }

        [HttpPost("Create")]
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

        [HttpGet("GetAll")]
        
        public IActionResult Get()
        {
            var data = ClientRepo.GetAll();
            return Ok(data);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(ClientVM ob)
        {
            var data = ClientRepo.Delete(ob);
            if(data==null)
                return BadRequest(new response { Message = "Can Not Delete" ,Status="Error"});
            return Ok(data);
        }
        [HttpPost("Edit")]
        public IActionResult Edit(ClientVM ob)
        {
            var data = ClientRepo.Edit(ob);
            if (data == null)
                return BadRequest(new response { Message = "Can Not Edit", Status = "Error" });
            return Ok(data);
        }
        [HttpPost("GetById")]
        public IActionResult GetById(int id)
        {
            return Ok(ClientRepo.GetById(id));
        }
        [HttpPost("Search")]
        public IActionResult Search(string name)
        {
            return Ok(ClientRepo.Search(name));
        }

    }
}


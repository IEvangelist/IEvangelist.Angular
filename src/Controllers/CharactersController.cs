using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;
using IEvangelist.Angular.Models;
using System.Threading.Tasks;
using IEvangelist.Angular.Repositories;

namespace IEvangelist.Angular.Controllers
{
    [Route("api/[controller]")]
    public class CharactersController : Controller
    {
        [HttpGet]
        public Task<IEnumerable<Character>> GetAsync(
            [FromServices] IDbRepository repository)
            => repository.GetAsync<Character>(chr => chr != null);
        
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
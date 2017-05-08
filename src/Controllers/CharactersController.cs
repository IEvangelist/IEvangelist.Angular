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
        private readonly IDbRepository _repository;

        public CharactersController(IDbRepository repository)
            => _repository =
                repository ?? throw new ArgumentNullException(nameof(repository));

        [HttpGet]
        public Task<IEnumerable<Character>> GetAll()
            => _repository.GetAsync<Character>(chr => chr != null);

        [HttpGet("{id}")]
        public Task<Character> Get([FromServices] IDbRepository repo, string id)
            => repo.GetAsync<Character>(id);

        [HttpPost]
        public Task Post([FromBody] Character character)
            => _repository.UpdateAsync(character.Id, character);
        
        [HttpDelete("{id}")]
        public Task Delete(string id)
            => _repository.DeleteAsync(id.ToString());


    }
}
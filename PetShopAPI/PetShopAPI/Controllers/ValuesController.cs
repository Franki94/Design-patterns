using Microsoft.AspNetCore.Mvc;
using PetShop.Models;
using PetShop.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace PetShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IDogsRepository dogsRepository;
        public ValuesController(IDogsRepository dogsRepository)
        {
            this.dogsRepository = dogsRepository;
        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(dogsRepository.GetPets(x => x.Age > 0, "PetTypeNavigation", "PetOwnersNavigation", "PetOwnersNavigation.OwnerNavigation").Select(x =>
            new Pets
            {
                Name = x.Name,
                PetTypeNavigation = new PetTypes { PetType = x.PetTypeNavigation.PetType, Description = x.PetTypeNavigation.Description },
                PetOwnersNavigation = new List<PetOwners>
                {
                   new PetOwners
                   {
                        OwnerId = x.PetOwnersNavigation.FirstOrDefault().OwnerId,
                        PetId = x.PetOwnersNavigation.FirstOrDefault().PetId,
                        OwnerNavigation = new Owners{ FirstName = x.PetOwnersNavigation.FirstOrDefault().OwnerNavigation?.FirstName }
                   }
                },
                PetType = x.PetType,
            }));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

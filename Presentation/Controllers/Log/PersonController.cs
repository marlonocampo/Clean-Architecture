using Domain.Interfaces.Log;
using Domain.Models.Log;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Presentation.Controllers.Log
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        readonly IPersonUseCase _personService;
        public PersonController(IPersonUseCase personService)
        {
            _personService = personService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] PersonModel person)
        {
            var model = _personService.Save(person);
            return Ok(model);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
           var person = _personService.GetById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPut]
        public IActionResult Update([FromBody] PersonModel person)
        {
            var model = _personService.Update(person);
            return Ok(model);
        }


        [HttpDelete("{id}")]
        public IActionResult Delte(string id)
        {
            var model = _personService.Delete(id);
            return Ok(model);
        }

    }
}

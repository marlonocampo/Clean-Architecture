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

        [HttpGet]
        public ActionResult GetNames()
        {
            var names = _personService.GetNames();
            if (names == null)
            {
                return NotFound();
            }
            return Ok(names);
        }
    }
}

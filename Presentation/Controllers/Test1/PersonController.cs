using Domain.Interfaces.Test1;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Presentation.Controllers.Test1
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

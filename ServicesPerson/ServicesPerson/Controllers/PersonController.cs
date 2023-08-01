using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;

namespace ServicesPerson.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private IPersonService _personService;

    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_personService.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById(long id)
    {
        Person person = _personService.FindById(id);
        if (person == null) { return NotFound(); }

        return Ok(person);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Person person)
    {
        if (person == null) { return BadRequest(); }

        return Ok(_personService.Create(person));

    }
    
    [HttpPut]
    public IActionResult Put([FromBody] Person person)
    {
        if (person == null) { return BadRequest(); }

        return Ok(_personService.Update(person));

    }

    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        _personService.Delete(id);
        return NoContent();
    }


}

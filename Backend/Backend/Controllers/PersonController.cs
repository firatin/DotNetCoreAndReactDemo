using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly AppDbContext _db;

    public PersonController(AppDbContext context)
    {
        _db = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddPerson(Person person)
    {
        try
        {
            _db.Person.Add(person);
            await _db.SaveChangesAsync();
            return Ok(person);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetPersonList()
    {
        try
        {
            //var personList= await _db.Person.ToListAsync();
            var personList = _db.Person.ToListAsync();           
            return Ok(personList);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    [HttpGet("{personID:int}")]
    public async Task<IActionResult> GetPerson(int personID)
    {
        try
        {
            //var person = await _db.Person.FindAsync(personID);
            var person = await _db.Person.Where(x => x.ID == personID).ToListAsync();
            return Ok(person);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePerson(Person person)
    {
        try
        {
            _db.Person.Update(person);
            await _db.SaveChangesAsync();
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{personID:int}")]
    public async Task<IActionResult> DeletePerson(int personID)
    {
        try
        {
            var person = await _db.Person.FindAsync(personID);
              _db.Person.Remove(person);
              await _db.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}


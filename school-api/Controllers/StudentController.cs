using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class SchoolController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public SchoolController(ApplicationDbContext dbContext)
    {
        this._context = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<School>>> GetSchools()
    {
        var schools = _context.Schools;
        if(schools != null)
        {
            return Ok(schools);
        } else
        {
            return NotFound();
        }
    }


    
    [HttpGet("{Id}")]
    public async Task<ActionResult<List<School>>> GetSchoolById(int Id)
    {
        var school = await _context.Schools.FindAsync(Id);
        if(school != null)
        {
            return Ok(school);
        } else
        {
            return NotFound();
        }
    }


    [HttpPost("createSchool")]
    public async Task<ActionResult<List<School>>> CreateSchool([FromBody] School school)
    {
        await _context.Schools.AddAsync(school);
        await _context.SaveChangesAsync();
        return Ok(_context.Schools);
    }

    [HttpPost("updateSchool")]
    public async Task<ActionResult<List<School>>> UpdateSchool([FromBody] School school)
    {
        _context.Schools.Update(school);
        await _context.SaveChangesAsync();
        return Ok(_context.Schools);
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult<List<School>>> DeleteSchool(int Id)
    {
        School school = await _context.Schools.FindAsync(Id);
        if(school != null)
        {
            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();
            return Ok(_context.Schools);
        } else
        {
            return NotFound();
        }
    }
}

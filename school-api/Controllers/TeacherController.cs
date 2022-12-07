using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public TeacherController(ApplicationDbContext dbContext)
    {
        this._context = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<Teacher>>> GetTeachers()
    {
        var teachers = _context.Teachers;
        if(teachers != null)
        {
            return Ok(teachers);
        } else
        {
            return NotFound();
        }
    }


    
    [HttpGet("{Id}")]
    public async Task<ActionResult<List<Teacher>>> GetTeacherById(int Id)
    {
        var teacher = await _context.Teachers.FindAsync(Id);
        if(teacher != null)
        {
            return Ok(teacher);
        } else
        {
            return NotFound();
        }
    }


    [HttpPost("createTeacher")]
    public async Task<ActionResult<List<Teacher>>> CreateTeacher([FromBody] Teacher teacher)
    {
        await _context.Teachers.AddAsync(teacher);
        await _context.SaveChangesAsync();
        return Ok(_context.Teachers);
    }

    [HttpPost("updateTeacher")]
    public async Task<ActionResult<List<Teacher>>> UpdateTeacher([FromBody] Teacher teacher)
    {
        _context.Teachers.Update(teacher);
        await _context.SaveChangesAsync();
        return Ok(_context.Teachers);
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult<List<Teacher>>> DeleteTeacher(int Id)
    {
        Teacher teacher = await _context.Teachers.FindAsync(Id);
        if(teacher != null)
        {
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
            return Ok(_context.Teachers);
        } else
        {
            return NotFound();
        }
    }
}

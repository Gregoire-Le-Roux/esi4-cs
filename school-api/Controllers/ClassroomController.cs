using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassroomController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ClassroomController(ApplicationDbContext dbContext)
    {
        this._context = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<Classroom>>> GetClassrooms()
    {
        var classrooms = _context.Classrooms;
        if(classrooms != null)
        {
            return Ok(classrooms);
        } else
        {
            return NotFound();
        }
    }


    
    [HttpGet("{Id}")]
    public async Task<ActionResult<List<Classroom>>> GetClassroomById(int Id)
    {
        var classroom = await _context.Classrooms.FindAsync(Id);
        if(classroom != null)
        {
            return Ok(classroom);
        } else
        {
            return NotFound();
        }
    }


    [HttpPost("createClassroom")]
    public async Task<ActionResult<List<Classroom>>> CreateClassroom([FromBody] Classroom classroom)
    {
        await _context.Classrooms.AddAsync(classroom);
        await _context.SaveChangesAsync();
        return Ok(_context.Classrooms);
    }

    [HttpPost("updateClassroom")]
    public async Task<ActionResult<List<Classroom>>> UpdateClassroom([FromBody] Classroom classroom)
    {
        _context.Classrooms.Update(classroom);
        await _context.SaveChangesAsync();
        return Ok(_context.Classrooms);
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult<List<Classroom>>> DeleteClassroom(int Id)
    {
        Classroom classroom = await _context.Classrooms.FindAsync(Id);
        if(classroom != null)
        {
            _context.Classrooms.Remove(classroom);
            await _context.SaveChangesAsync();
            return Ok(_context.Classrooms);
        } else
        {
            return NotFound();
        }
    }
}

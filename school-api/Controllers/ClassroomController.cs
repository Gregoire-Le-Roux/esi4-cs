using Microsoft.AspNetCore.Mvc;
using school_api.Services;

namespace web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassroomController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly DB_Classroom dbClassroom;

    public ClassroomController(ApplicationDbContext dbContext)
    {
        this._context = dbContext;
        this.dbClassroom = new(dbContext);
    }


    [HttpGet]
    public async Task<ActionResult<List<Classroom>>> GetClassrooms()
    {
        var classrooms = dbClassroom.GetClassroomsService(); // Linq utilisé uniquement pour la classe classroom par manque de temps
        return Ok(classrooms);
    }


    
    [HttpGet("{Id}")]
    public async Task<ActionResult<Classroom>> GetClassroomById(int Id)
    {
        var classroom =
                (from a in _context.Classrooms
                 where a.Id == Id
                 select new { a.Id, a.Name });
        if (classroom != null)
        {
            return Ok(classroom);
        } else
        {
            return NotFound();
        }
    }


    [HttpPost("createClassroom")]
    public async Task<ActionResult<Classroom>> CreateClassroom(string name)
    {
        if(name != null)
        {
            Classroom classroom = new Classroom { Name = name };
            await _context.Classrooms.AddAsync(classroom);
            await _context.SaveChangesAsync();
            return Ok(classroom);
        }
        {
            return BadRequest();
        }
    }

    [HttpPost("updateClassroom")]
    public async Task<ActionResult<Classroom>> UpdateClassroom(Classroom classroom)
    {
        if(classroom != null)
        {
            _context.Classrooms.Update(classroom);
            await _context.SaveChangesAsync();
            return Ok(classroom);
        } else
        {
            return BadRequest();
        }
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult<List<Classroom>>> DeleteClassroom(int Id)
    {
        Classroom classroom = await _context.Classrooms.FindAsync(Id);
        if(classroom != null)
        {
            _context.Classrooms.Remove(classroom);
            await _context.SaveChangesAsync();
            var classrooms = dbClassroom.GetClassroomsService();
            return Ok(classrooms);
        } else
        {
            return NotFound();
        }
    }
}

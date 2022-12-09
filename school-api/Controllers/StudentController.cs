using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public StudentController(ApplicationDbContext dbContext)
    {
        this._context = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<Student>>> GetStudents()
    {
        var students = _context.Students;
        if(students != null)
        {
            return Ok(students);
        } else
        {
            return NotFound();
        }
    }


    
    [HttpGet("{Id}")]
    public async Task<ActionResult<Student>> GetStudentById(int Id)
    {
        var student = await _context.Students.FindAsync(Id);
        if(student != null)
        {
            return Ok(student);
        } else
        {
            return NotFound();
        }
    }


    [HttpPost("createStudent")]
    public async Task<ActionResult<Student>> CreateStudent(string firstname, string lastname, int age)
    {
        if(firstname != null && lastname != null && age != 0)
        {
            Student student = new Student { Firstname = firstname, Lastname = lastname, Age = age };
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        } else
        {
            return BadRequest();
        }
    }

    [HttpPost("updateStudent")]
    public async Task<ActionResult<Student>> UpdateStudent(Student student)
    {
        if(student != null)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
            return Ok(student);
        } else
        {
            return BadRequest();
        }
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult<List<Student>>> DeleteStudent(int Id)
    {
        Student student = await _context.Students.FindAsync(Id);
        if(student != null)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return Ok(_context.Students);
        } else
        {
            return NotFound();
        }
    }
}

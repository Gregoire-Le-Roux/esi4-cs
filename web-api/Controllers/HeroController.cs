using Microsoft.AspNetCore.Mvc;

namespace web_api.Controllers;

[ApiController]
[Route("[controller]")]
public class HeroController : ControllerBase
{
    private static List<Hero> heroes = new List<Hero>
    {
        new Hero { Id = 1, Name = "Iron Man", Firstname = "Jon", Lastname = "Doe"},
        new Hero { Id = 2, Name = "Batman", Firstname = "Jon", Lastname = "Doe"},
        new Hero { Id = 3, Name = "Spider Man", Firstname = "Jon", Lastname = "Doe"},
        new Hero { Id = 4, Name = "Hulk", Firstname = "Jon", Lastname = "Doe"},
    };
    private readonly ApplicationDbContext _context;

    public HeroController(ApplicationDbContext dbContext)
    {
        this._context = dbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<Hero>>> AllHeroes()
    {
        var myHeroes = _context.Heroes;
        if(myHeroes != null)
        {
            return Ok(myHeroes);
        } else
        {
            return NotFound();
        }
    }


    
    [HttpGet("{Id}")]
    public async Task<ActionResult<List<Hero>>> HeroById(int Id)
    {
        var hero = await _context.Heroes.FindAsync(Id);
        if(hero != null)
        {
            return Ok(hero);
        } else
        {
            return NotFound();
        }
    }

    /*
    [HttpPut]
    public ActionResult Add(Hero hero)
    {
        heroes.Add(hero);
        return Ok();
    }
    */

    [HttpPost("createHero")]
    public async Task<ActionResult<List<Hero>>> CreateHero([FromBody] Hero hero)
    {
        await _context.Heroes.AddAsync(hero);
        await _context.SaveChangesAsync();
        return Ok(_context.Heroes);
    }

    [HttpPost("updateHero")]
    public async Task<ActionResult<List<Hero>>> UpdateHero([FromBody] Hero hero)
    {
        _context.Heroes.Update(hero);
        await _context.SaveChangesAsync();
        return Ok(_context.Heroes);
    }

    [HttpDelete("{Id}")]
    public async Task<ActionResult<List<Hero>>> DeleteHero(int Id)
    {
        Hero hero = await _context.Heroes.FindAsync(Id);
        if(hero != null)
        {
            _context.Heroes.Remove(hero);
            await _context.SaveChangesAsync();
            return Ok(_context.Heroes);
        } else
        {
            return NotFound();
        }
    }
}

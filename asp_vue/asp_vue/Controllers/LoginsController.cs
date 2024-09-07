using asp_vue.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class LoginsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public LoginsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/logins
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Login>>> GetLogins()
    {
        return await _context.Logins.ToListAsync();
    }

    // GET: api/logins/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Login>> GetLogin(int id)
    {
        var login = await _context.Logins.FindAsync(id);

        if (login == null)
        {
            return NotFound();
        }

        return login;
    }

    // POST: api/logins
    [HttpPost]
    public async Task<ActionResult<Login>> PostLogin(Login login)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Logins.Add(login);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetLogin), new { id = login.Id }, login);
    }

    // PUT: api/logins/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLogin(int id, Login login)
    {
        if (id != login.Id)
        {
            return BadRequest();
        }

        _context.Entry(login).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!LoginExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/logins/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLogin(int id)
    {
        var login = await _context.Logins.FindAsync(id);
        if (login == null)
        {
            return NotFound();
        }

        _context.Logins.Remove(login);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool LoginExists(int id)
    {
        return _context.Logins.Any(e => e.Id == id);
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaplistBlib.Models;

namespace taplistBLIBofficial.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthentController : ControllerBase
{
    private readonly BloggingContext _bloggingContext;

    public AuthentController([FromServices] BloggingContext bloggingContext)
    {
        _bloggingContext = bloggingContext;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Authent>>> GetBlogs()
    {
        var authents = await _bloggingContext.Authents.ToListAsync();
        if ( authents == null)
        {
            return NotFound();
        }
        return authents;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Authent>> GetBlog(int id)
    {
        var authent = await _bloggingContext.Authents.FindAsync(id);
        if(authent == null)
        {
            return NotFound();
        }
        return authent;
    }

    [HttpPost]
    public async Task<ActionResult<Authent>> PostBlog(Authent authent)
    {
        
        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(authent.Password);
        authent.Password = hashedPassword;
        
        _bloggingContext.Authents.Add(authent);
        await _bloggingContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBlog), new { id = authent.Id }, authent);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlog(int id)
    {
        var authent = await _bloggingContext.Authents.FindAsync(id);
        if (authent == null)
        {
            return NotFound();
        }

        _bloggingContext.Authents.Remove(authent);
        await _bloggingContext.SaveChangesAsync();

        return NoContent();
    }

    private bool BlogExists(int id)
    {
        return _bloggingContext.Authents.Any(e => e.Id == id);
    }

}
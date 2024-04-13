/*using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaplistBlib.Models;
using System.Security.Claims;




namespace taplistBLIBofficial.Controllers;


[Route("api/[controller]")]
[ApiController]
public class StandController : ControllerBase
{
    private readonly BloggingContext _bloggingContext;
    
    public StandController([FromServices] BloggingContext bloggingContext)
    {
        _bloggingContext = bloggingContext;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Stand>>> GetStands()
    {
        var stands = await _bloggingContext.Stands.ToListAsync();
        return Ok(stands);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Stand>> GetStand(int id)
    {
        var stand = await _bloggingContext.Stands.FindAsync(id);
        if (stand == null)
        {
            return NotFound();
        }
        return stand;
    }
    
    [HttpPost]
    public async Task<ActionResult<Stand>> PostStand(int authentId)
    {
         Créer un nouveau stand avec l'ID de l'utilisateur
        var stand = new Stand { AuthentId = authentId };

         Ajouter le stand à la base de données
        _bloggingContext.Stands.Add(stand);
        await _bloggingContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetStand), new { id = stand.Id }, stand);
   }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateStand(int id, Stand stand)
    {
        if (id != stand.Id)
        {
            return BadRequest("ID de stand invalide.");
        }

        _bloggingContext.Entry(stand).State = EntityState.Modified;

        try
        {
            await _bloggingContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StandExists(id))
            {
                return NotFound("Stand non trouvé.");
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteStand(int id)
    {
        var stand = await _bloggingContext.Stands.FindAsync(id);
        if (stand == null)
        {
            return NotFound("Stand non trouvé.");
        }

        _bloggingContext.Stands.Remove(stand);
        await _bloggingContext.SaveChangesAsync();

        return NoContent();
    }
    
    private bool StandExists(int id)
    {
        return _bloggingContext.Stands.Any(e => e.Id == id);
    }
}*/
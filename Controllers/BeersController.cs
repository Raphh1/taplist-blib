using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaplistBlib.Models;

namespace taplistBLIBofficial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeersController : ControllerBase
    {
        private readonly BloggingContext _bloggingContext;

        public BeersController([FromServices] BloggingContext bloggingContext)
        {
            _bloggingContext = bloggingContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Beer>>> GetBlogs()
        {
            var beers = await _bloggingContext.Beers.ToListAsync();
            if (beers == null)
            {
                return NotFound();
            }
            return beers;
        }
    
        [HttpGet("{id}")]
        public async Task<ActionResult<Beer>> GetBlog(int id)
        {
            var beer = await _bloggingContext.Beers.FindAsync(id);
            if (beer == null)
            {
                return NotFound();
            }
            return beer;
        }

        [HttpPost]
        public async Task<ActionResult<Beer>> PostBlog(Beer beer)
        {
            _bloggingContext.Beers.Add(beer);
            await _bloggingContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBlog), new { id = beer.Id }, beer);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog(int id, Beer beer)
        {
            if (id != beer.Id)
            {
                return BadRequest();
            }

            _bloggingContext.Entry(beer).State = EntityState.Modified;

            try
            {
                await _bloggingContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var beer = await _bloggingContext.Beers.FindAsync(id);
            if (beer == null)
            {
                return NotFound();
            }

            _bloggingContext.Beers.Remove(beer);
            await _bloggingContext.SaveChangesAsync();

            return NoContent();
        }

        private bool BlogExists(int id)
        {
            return _bloggingContext.Beers.Any(e => e.Id == id);
        }
    }
}
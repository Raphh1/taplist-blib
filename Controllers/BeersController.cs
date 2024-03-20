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
        public async Task<ActionResult<IEnumerable<Blog>>> GetBlogs()
        {
            var blogs = await _bloggingContext.Blogs.ToListAsync();
            if (blogs == null)
            {
                return NotFound();
            }
            return blogs;
        }
    
        [HttpGet("{id}")]
        public async Task<ActionResult<Blog>> GetBlog(int id)
        {
            var blog = await _bloggingContext.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return blog;
        }

        [HttpPost]
        public async Task<ActionResult<Blog>> PostBlog(Blog blog)
        {
            _bloggingContext.Blogs.Add(blog);
            await _bloggingContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBlog), new { id = blog.Id }, blog);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlog(int id, Blog blog)
        {
            if (id != blog.Id)
            {
                return BadRequest();
            }

            _bloggingContext.Entry(blog).State = EntityState.Modified;

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
            var blog = await _bloggingContext.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            _bloggingContext.Blogs.Remove(blog);
            await _bloggingContext.SaveChangesAsync();

            return NoContent();
        }

        private bool BlogExists(int id)
        {
            return _bloggingContext.Blogs.Any(e => e.Id == id);
        }
    }
}
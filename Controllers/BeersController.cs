﻿using Microsoft.AspNetCore.Mvc;
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
    }
}
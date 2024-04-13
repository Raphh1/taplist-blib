using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaplistBlib.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace taplistBLIBofficial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthentController : ControllerBase
    {
        private readonly BloggingContext _bloggingContext;
        private readonly IConfiguration _configuration;

        public AuthentController([FromServices] BloggingContext bloggingContext, IConfiguration configuration)
        {
            _bloggingContext = bloggingContext;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            //int standId = GetStandIdFromRequest(model); 

            var newUser = new Authent
            {
               Identifiant = model.Identifiant,
            Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
            //    StandId = standId 
            };

           _bloggingContext.Authents.Add(newUser);
            await _bloggingContext.SaveChangesAsync();

            return Ok("Utilisateur enregistré avec succès.");
        }
        
       // private int GetStandIdFromRequest(RegisterRequest model)
       // {
        //    return model.StandId;
        //}
        
        
        [HttpDelete("delete-account")]
        [Authorize]
        public async Task<IActionResult> DeleteAccount()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId) || !int.TryParse(userId, out int id))
            {
                return BadRequest("ID de l'utilisateur invalide.");
            }

            var user = await _bloggingContext.Authents.FindAsync(id);

            if (user == null)
            {
                return NotFound("Utilisateur non trouvé.");
            }

            _bloggingContext.Authents.Remove(user);
            await _bloggingContext.SaveChangesAsync();

            return Ok("Compte supprimé avec succès.");
        }

        [HttpGet("user/{id}")]
        [Authorize]
        public async Task<IActionResult> GetUserById(int id)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
            {
                return BadRequest("Impossible de récupérer l'ID de l'utilisateur à partir du jeton JWT.");
            }

            
            if (userId != id)
            {
                return Forbid(); 
            }

            var user = await _bloggingContext.Authents.FindAsync(id);

            if (user == null)
            {
                return NotFound("Utilisateur non trouvé.");
            }

            return Ok(new
            {
                user.Id,
                user.Identifiant
            });
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthentRequest model)
        {
            var authent = await _bloggingContext.Authents.FirstOrDefaultAsync(x => x.Identifiant == model.Identifiant);
            if (authent == null || !BCrypt.Net.BCrypt.Verify(model.Password, authent.Password))
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, authent.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new { Token = tokenString });
        }
    }
    
}
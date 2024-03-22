using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;


namespace TaplistBlib.Models
{
    public class Authent
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "L'identifiant est requis")]
        public string Identifiant { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public void HashPassword()
        {
            Password = BCrypt.Net.BCrypt.HashPassword(Password);
        }
    }
}
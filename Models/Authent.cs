using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;

namespace TaplistBlib.Models;

public class Authent
{
    [Key]
    public int Id { get; set; }
    public string Identifiant { get; set; }
    public string Password { get; set; }
}

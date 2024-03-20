using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace TaplistBlib.Models;


public class Blog
{
    [Key]
    public int Id { get; set; }
    public float Degree { get; set; }
    public string Nom { get; set; }
    public string Description{ get; set; }
    public string Brasserie { get; set; }
    public string Couleur { get; set; }
    
}
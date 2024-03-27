using System.ComponentModel.DataAnnotations;

namespace TaplistBlib.Models;

public class Stand
{
    [Key]
    public int Id { get; set; }
    public string BrasserieStand { get; set; }
    public Authent Authent { get; set; }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaplistBlib.Models;

public class Stand
{
    [Key]
    public int Id { get; set; }
    public string BrasserieStand { get; set; }

    // Clé étrangère vers Authent
   // [ForeignKey("Authent")]
   // public int AuthentId { get; set; }
    //public Authent Authent { get; set; }
}
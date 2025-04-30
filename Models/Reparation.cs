using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet5ApplicationDotNet.Models
{
    public class Reparation
    {
        public int Id { get; set; }
        public string Cout { get; set; }
        public string Commentaire { get; set; }
        [Required]
        public Voiture UneVoiture { get; set; }
    }
}

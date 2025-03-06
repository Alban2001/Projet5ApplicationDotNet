using System.ComponentModel.DataAnnotations;

namespace Projet5ApplicationDotNet.Models
{
    public class Reparation
    {
        public int Id { get; set; }
        public string Cout { get; set; }
        public string Commentaire { get; set; }
        public Voiture UneVoiture { get; set; }
    }
}

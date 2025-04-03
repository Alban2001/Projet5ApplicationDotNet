using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Projet5ApplicationDotNet.Models
{
    public class Modele
    {
        public int Id { get; set; }

        public int Annee { get; set; }

        public string Nom { get; set; }

        public Marque UneMarque { get; set; }

        public virtual ICollection<Voiture>? ListeVoiture { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Projet5ApplicationDotNet.Models
{
    public class Marque
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public virtual ICollection<Modele>? ListeModele { get; set; }
    }
}

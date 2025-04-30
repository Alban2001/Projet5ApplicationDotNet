using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Projet5ApplicationDotNet.Models
{
    public class ReparationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Coût")]
        [Required(ErrorMessage = "Veuillez remplir ce champ !")]
        public string? Cout { get; set; }

        [Required(ErrorMessage = "Veuillez remplir ce champ !")]
        public string? Commentaire { get; set; }

        public int IdVoiture { get; set; }

        public virtual IEnumerable<Reparation>? ListeReparation { get; set; }
    }
}

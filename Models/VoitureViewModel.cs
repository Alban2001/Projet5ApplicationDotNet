using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Projet5ApplicationDotNet.Models
{
    public class VoitureViewModel
    {
        [Required(ErrorMessage = "Veuillez remplir ce champ !")]
        public string PrixVente { get; set; }

        [Required(ErrorMessage = "Veuillez remplir ce champ !")]
        [Range(1990, 2025, ErrorMessage = "L'année doit être comprise entre 1990 et 2025.")]
        public int Annee { get; set; }

        [Required(ErrorMessage = "Veuillez remplir ce champ !")]
        public string Marque { get; set; }

        [Required(ErrorMessage = "Veuillez remplir ce champ !")]
        public string Modele { get; set; }

        [Required(ErrorMessage = "Veuillez remplir ce champ !")]
        public string Finition { get; set; }

        [Required(ErrorMessage = "Veuillez remplir ce champ !")]
        public IFormFile Photo { get; set; }
    }
}

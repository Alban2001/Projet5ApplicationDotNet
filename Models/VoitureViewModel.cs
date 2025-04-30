using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Projet5ApplicationDotNet.Models
{
    public class VoitureViewModel
    {
        public int IdVoiture { get; set; }

        [Display(Name = "Code VIN")]
        public string? CodeVIN { get; set; }

        [Display(Name = "Date d'achat")]
        public DateTime? DateAchat { get; set; }

        [Display(Name = "Prix d'achat")]
        [Required(ErrorMessage = "Veuillez remplir ce champ !")]
        public string PrixAchat { get; set; }

        public bool Disponible { get; set; } = false;

        [Display(Name = "Date de vente")]
        public DateTime? DateVente { get; set; }

        [Display(Name = "Prix de vente")]
        public string? PrixVente { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Veuillez remplir ce champ !")]
        [Range(1990, 2025, ErrorMessage = "L'année doit être comprise entre 1990 et 2025.")]
        [Display(Name = "Année")]
        public int Annee { get; set; }

        [Required(ErrorMessage = "Veuillez remplir ce champ !")]
        public string Marque { get; set; }

        [Required(ErrorMessage = "Veuillez remplir ce champ !")]
        [Display(Name = "Modèle")]
        public string Modele { get; set; }

        [Required(ErrorMessage = "Veuillez remplir ce champ !")]
        public string Finition { get; set; }

        [Required(ErrorMessage = "Veuillez remplir ce champ !")]
        public IFormFile Photo { get; set; }

        [Display(Name = "Photo")]
        public string? PhotoS { get; set; }
    }
}

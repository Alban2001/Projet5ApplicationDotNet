using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Projet5ApplicationDotNet.Models
{
    public class CreateVoitureViewModel : VoitureViewModel
    {
        [Required(ErrorMessage = "Veuillez remplir ce champ !")]
        public IFormFile Photo { get; set; }
    }
}

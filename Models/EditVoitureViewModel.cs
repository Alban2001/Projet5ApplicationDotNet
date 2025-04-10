using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Projet5ApplicationDotNet.Models
{
    public class EditVoitureViewModel : VoitureViewModel
    {
        public IFormFile? Photo { get; set; }
    }
}

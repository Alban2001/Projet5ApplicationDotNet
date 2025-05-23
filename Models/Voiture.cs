﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Projet5ApplicationDotNet.Models
{
    public class Voiture
    {
        public int Id {  get; set; }

        public string? CodeVIN { get; set; }

        public string Finition { get; set; }

        public DateTime? DateAchat { get; set; }

        public string PrixAchat { get; set; }

        public bool Disponible { get; set; } = false;

        public DateTime? DateVente { get; set; }

        public string Photo { get; set; }

        public string? Description { get; set; }

        public string? PrixVente { get; set; }

        public Modele UnModele { get; set; }

        public virtual ICollection<Reparation>? ListeReparation { get; set; }
    }
}

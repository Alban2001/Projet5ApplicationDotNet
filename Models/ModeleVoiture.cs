namespace Projet5ApplicationDotNet.Models
{
    public class ModeleVoiture
    {
        public int Id { get; set; }
        public int Annee { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public virtual ICollection<Voiture>? ListeVoiture { get; set; }
    }
}

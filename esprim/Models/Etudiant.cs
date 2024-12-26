using mini.project.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mini.project.Models
{
    public class Etudiant
    {
        [Key]
        public int CodeEtudiant { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateNaissance { get; set; }
        public string? NumInscription { get; set; }
        public string? Adresse { get; set; }
        public string? Mail { get; set; }
        public string? Tel { get; set; }

        [ForeignKey("Classe")]
        public int? CodeClasse { get; set; }

        public Classe? Classe { get; set; }
        public ICollection<LigneFicheAbsence> LignesFicheAbsence { get; set; } = new List<LigneFicheAbsence>();

    }
}
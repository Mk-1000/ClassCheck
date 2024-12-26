using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mini.project.Models
{
    public class Classe
    {
        [Key]
        public int CodeClasse { get; set; }

        [Required]
        [StringLength(100)]
        public string NomClasse { get; set; }

        [ForeignKey("Groupe")]
        public int? CodeGroupe { get; set; }

        [ForeignKey("Departement")]
        public int? CodeDepartement { get; set; }

        public Groupe? Groupe { get; set; }
        public Departement? Departement { get; set; }

        public ICollection<Etudiant> Etudiants { get; set; } = new List<Etudiant>();

        public ICollection<FicheAbsence> FichesAbsence { get; set; } = new List<FicheAbsence>();

    }
}

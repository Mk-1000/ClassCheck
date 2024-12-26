using mini.project.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mini.project.Models
{
    public class FicheAbsence
    {
        [Key]
        public int CodeFicheAbsence { get; set; }

        [Required]
        public DateTime DateJour { get; set; }

        [Required]
        [ForeignKey("Matiere")]
        public int CodeMatiere { get; set; }

        [Required]
        [ForeignKey("Enseignant")]
        public int CodeEnseignant { get; set; }

        [Required]
        [ForeignKey("Classe")]
        public int CodeClasse { get; set; }

        // Navigation properties
        public Matiere? Matiere { get; set; }
        public Enseignant? Enseignant { get; set; }
        public Classe? Classe { get; set; }
        public ICollection<FicheAbsenceSeance> FichesAbsenceSeances { get; set; } = new List<FicheAbsenceSeance>();
    }
}
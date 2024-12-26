using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mini.project.Models
{
    public class LigneFicheAbsence
    {
        [Key]
        public int CodeLigneFicheAbsence { get; set; }

        [ForeignKey("Etudiant")]
        public int CodeEtudiant { get; set; }

        [ForeignKey("FicheAbsenceSeance")]
        public int CodeFicheAbsenceSeance { get; set; }

        public bool IsAbsent { get; set; }

        public Etudiant? Etudiant { get; set; }
        public FicheAbsenceSeance? FicheAbsenceSeance { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mini.project.Models
{
    public class FicheAbsenceSeance
    {
        [Key]
        public int CodeFicheAbsenceSeance { get; set; }

        [ForeignKey("FicheAbsence")]
        public int CodeFicheAbsence { get; set; }

        [ForeignKey("Seance")]
        public int CodeSeance { get; set; }

        // Navigation properties
        public FicheAbsence? FicheAbsence { get; set; }
        public Seance? Seance { get; set; }
        public ICollection<LigneFicheAbsence> LignesFicheAbsence { get; set; } = new List<LigneFicheAbsence>();
    }
}

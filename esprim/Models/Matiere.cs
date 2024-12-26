using System.ComponentModel.DataAnnotations;

namespace mini.project.Models
{
    public class Matiere
    {
        [Key]
        public int CodeMatiere { get; set; }
        public string NomMatiere { get; set; }
        public int NbreHeureCoursParSemaine { get; set; }
        public int NbreHeureTDParSemaine { get; set; }
        public int NbreHeureTPParSemaine { get; set; }

        // Navigation property
        public ICollection<FicheAbsence> FichesAbsence { get; set; } = new List<FicheAbsence>(); // Default empty list
    }
}

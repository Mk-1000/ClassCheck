using System.ComponentModel.DataAnnotations;

namespace mini.project.Models
{
    public class Seance
    {
        [Key]
        public int CodeSeance { get; set; }
        public string NomSeance { get; set; }
        public TimeSpan HeureDebut { get; set; }
        public TimeSpan HeureFin { get; set; }

        // Navigation property
        public ICollection<FicheAbsenceSeance> FichesAbsenceSeances { get; set; } = new List<FicheAbsenceSeance>(); // Default empty list
    }
}

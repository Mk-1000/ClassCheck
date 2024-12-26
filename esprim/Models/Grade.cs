using System.ComponentModel.DataAnnotations;

namespace mini.project.Models
{
    public class Grade
    {
        [Key]
        public int CodeGrade { get; set; }
        public string NomGrade { get; set; }

        // Navigation property
        public ICollection<Enseignant> Enseignants { get; set; } = new List<Enseignant>(); // Default empty list
    }
}

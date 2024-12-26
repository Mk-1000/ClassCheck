using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mini.project.Models
{
    public class Enseignant
    {
        [Key]
        public int CodeEnseignant { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime DateRecrutement { get; set; }
        public string? Adresse { get; set; }
        public string? Mail { get; set; }
        public string? Tel { get; set; }

        [ForeignKey("Departement")]
        public int CodeDepartement { get; set; }
        [ForeignKey("Grade")]
        public int CodeGrade { get; set; }
        public Departement? Departement { get; set; }
        public Grade? Grade { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mini.project.Models
{
    public class Departement
    {
        [Key]
        public int CodeDepartement { get; set; }

        [Required]
        [StringLength(100)]
        public string NomDepartement { get; set; }

        public ICollection<Classe> Classes { get; set; } = new List<Classe>();
        public ICollection<Enseignant> Enseignants { get; set; } = new List<Enseignant>();
    }
}

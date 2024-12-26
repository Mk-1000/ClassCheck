using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace mini.project.Models
{
    public class Groupe
    {
        [Key]
        public int CodeGroupe { get; set; }

        [Required]
        [StringLength(100)]  // Limiting the length of the group name
        public string NomGroupe { get; set; }

        // Navigation property (one-to-many relationship with Classe)
        public ICollection<Classe> Classes { get; set; } = new List<Classe>();
    }
}

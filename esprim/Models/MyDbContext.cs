using Microsoft.EntityFrameworkCore;

namespace mini.project.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        // DbSet properties
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<Seance> Seances { get; set; }
        public DbSet<Groupe> Groupes { get; set; }
        public DbSet<FicheAbsence> FichesAbsence { get; set; }
        public DbSet<FicheAbsenceSeance> FichesAbsenceSeances { get; set; }
        public DbSet<LigneFicheAbsence> LignesFicheAbsence { get; set; }
        public DbSet<Departement> Departements { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Enseignant> Enseignants { get; set; }
        public DbSet<Etudiant> Etudiants { get; set; }

        // OnModelCreating configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Primary Key configurations
            modelBuilder.Entity<Classe>().HasKey(c => c.CodeClasse);
            modelBuilder.Entity<Groupe>().HasKey(g => g.CodeGroupe);
            modelBuilder.Entity<Departement>().HasKey(d => d.CodeDepartement);
            modelBuilder.Entity<Matiere>().HasKey(m => m.CodeMatiere);
            modelBuilder.Entity<Grade>().HasKey(g => g.CodeGrade);

            // Composite Key configurations
            modelBuilder.Entity<FicheAbsenceSeance>()
                .HasKey(fas => fas.CodeFicheAbsenceSeance);

            modelBuilder.Entity<LigneFicheAbsence>()
                .HasKey(lfa => lfa.CodeLigneFicheAbsence);

            // Relationships and Foreign Key configurations
            modelBuilder.Entity<Classe>()
                .HasOne(c => c.Groupe)
                .WithMany(g => g.Classes)
                .HasForeignKey(c => c.CodeGroupe)
                .OnDelete(DeleteBehavior.SetNull);  // Cascade or SetNull based on your business rules

            modelBuilder.Entity<Classe>()
                .HasOne(c => c.Departement)
                .WithMany(d => d.Classes)
                .HasForeignKey(c => c.CodeDepartement)
                .OnDelete(DeleteBehavior.SetNull);  // Cascade or SetNull based on your business rules

            modelBuilder.Entity<Enseignant>()
                .HasOne(e => e.Departement)
                .WithMany(d => d.Enseignants)
                .HasForeignKey(e => e.CodeDepartement);

            modelBuilder.Entity<FicheAbsence>()
                .HasMany(fa => fa.FichesAbsenceSeances)
                .WithOne(fas => fas.FicheAbsence)
                .HasForeignKey(fas => fas.CodeFicheAbsence);

            modelBuilder.Entity<FicheAbsenceSeance>()
                .HasMany(fas => fas.LignesFicheAbsence)
                .WithOne(lfa => lfa.FicheAbsenceSeance)
                .HasForeignKey(lfa => lfa.CodeFicheAbsenceSeance);

            modelBuilder.Entity<FicheAbsenceSeance>()
                .HasOne(fas => fas.Seance)
                .WithMany(s => s.FichesAbsenceSeances)
                .HasForeignKey(fas => fas.CodeSeance);

            modelBuilder.Entity<LigneFicheAbsence>()
                .HasOne(lfa => lfa.Etudiant)
                .WithMany(e => e.LignesFicheAbsence)
                .HasForeignKey(lfa => lfa.CodeEtudiant);

            // Configure other foreign key constraints as needed
        }
    }
}
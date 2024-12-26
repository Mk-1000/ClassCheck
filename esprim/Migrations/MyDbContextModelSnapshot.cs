﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mini.project.Models;

#nullable disable

namespace esprim.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("mini.project.Models.Classe", b =>
                {
                    b.Property<int>("CodeClasse")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CodeClasse"));

                    b.Property<int?>("CodeDepartement")
                        .HasColumnType("int");

                    b.Property<int?>("CodeGroupe")
                        .HasColumnType("int");

                    b.Property<string>("NomClasse")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("CodeClasse");

                    b.HasIndex("CodeDepartement");

                    b.HasIndex("CodeGroupe");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("mini.project.Models.Departement", b =>
                {
                    b.Property<int>("CodeDepartement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CodeDepartement"));

                    b.Property<string>("NomDepartement")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("CodeDepartement");

                    b.ToTable("Departements");
                });

            modelBuilder.Entity("mini.project.Models.Enseignant", b =>
                {
                    b.Property<int>("CodeEnseignant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CodeEnseignant"));

                    b.Property<string>("Adresse")
                        .HasColumnType("longtext");

                    b.Property<int>("CodeDepartement")
                        .HasColumnType("int");

                    b.Property<int>("CodeGrade")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRecrutement")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Mail")
                        .HasColumnType("longtext");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tel")
                        .HasColumnType("longtext");

                    b.HasKey("CodeEnseignant");

                    b.HasIndex("CodeDepartement");

                    b.HasIndex("CodeGrade");

                    b.ToTable("Enseignants");
                });

            modelBuilder.Entity("mini.project.Models.Etudiant", b =>
                {
                    b.Property<int>("CodeEtudiant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CodeEtudiant"));

                    b.Property<string>("Adresse")
                        .HasColumnType("longtext");

                    b.Property<int?>("CodeClasse")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Mail")
                        .HasColumnType("longtext");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("NumInscription")
                        .HasColumnType("longtext");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tel")
                        .HasColumnType("longtext");

                    b.HasKey("CodeEtudiant");

                    b.HasIndex("CodeClasse");

                    b.ToTable("Etudiants");
                });

            modelBuilder.Entity("mini.project.Models.FicheAbsence", b =>
                {
                    b.Property<int>("CodeFicheAbsence")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CodeFicheAbsence"));

                    b.Property<int>("CodeClasse")
                        .HasColumnType("int");

                    b.Property<int>("CodeEnseignant")
                        .HasColumnType("int");

                    b.Property<int>("CodeMatiere")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateJour")
                        .HasColumnType("datetime(6)");

                    b.HasKey("CodeFicheAbsence");

                    b.HasIndex("CodeClasse");

                    b.HasIndex("CodeEnseignant");

                    b.HasIndex("CodeMatiere");

                    b.ToTable("FichesAbsence");
                });

            modelBuilder.Entity("mini.project.Models.FicheAbsenceSeance", b =>
                {
                    b.Property<int>("CodeFicheAbsenceSeance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CodeFicheAbsenceSeance"));

                    b.Property<int>("CodeFicheAbsence")
                        .HasColumnType("int");

                    b.Property<int>("CodeSeance")
                        .HasColumnType("int");

                    b.HasKey("CodeFicheAbsenceSeance");

                    b.HasIndex("CodeFicheAbsence");

                    b.HasIndex("CodeSeance");

                    b.ToTable("FichesAbsenceSeances");
                });

            modelBuilder.Entity("mini.project.Models.Grade", b =>
                {
                    b.Property<int>("CodeGrade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CodeGrade"));

                    b.Property<string>("NomGrade")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CodeGrade");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("mini.project.Models.Groupe", b =>
                {
                    b.Property<int>("CodeGroupe")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CodeGroupe"));

                    b.Property<string>("NomGroupe")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("CodeGroupe");

                    b.ToTable("Groupes");
                });

            modelBuilder.Entity("mini.project.Models.LigneFicheAbsence", b =>
                {
                    b.Property<int>("CodeLigneFicheAbsence")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CodeLigneFicheAbsence"));

                    b.Property<int>("CodeEtudiant")
                        .HasColumnType("int");

                    b.Property<int>("CodeFicheAbsenceSeance")
                        .HasColumnType("int");

                    b.Property<bool>("IsAbsent")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("CodeLigneFicheAbsence");

                    b.HasIndex("CodeEtudiant");

                    b.HasIndex("CodeFicheAbsenceSeance");

                    b.ToTable("LignesFicheAbsence");
                });

            modelBuilder.Entity("mini.project.Models.Matiere", b =>
                {
                    b.Property<int>("CodeMatiere")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CodeMatiere"));

                    b.Property<int>("NbreHeureCoursParSemaine")
                        .HasColumnType("int");

                    b.Property<int>("NbreHeureTDParSemaine")
                        .HasColumnType("int");

                    b.Property<int>("NbreHeureTPParSemaine")
                        .HasColumnType("int");

                    b.Property<string>("NomMatiere")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CodeMatiere");

                    b.ToTable("Matieres");
                });

            modelBuilder.Entity("mini.project.Models.Seance", b =>
                {
                    b.Property<int>("CodeSeance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("CodeSeance"));

                    b.Property<TimeSpan>("HeureDebut")
                        .HasColumnType("time(6)");

                    b.Property<TimeSpan>("HeureFin")
                        .HasColumnType("time(6)");

                    b.Property<string>("NomSeance")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CodeSeance");

                    b.ToTable("Seances");
                });

            modelBuilder.Entity("mini.project.Models.Classe", b =>
                {
                    b.HasOne("mini.project.Models.Departement", "Departement")
                        .WithMany("Classes")
                        .HasForeignKey("CodeDepartement")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("mini.project.Models.Groupe", "Groupe")
                        .WithMany("Classes")
                        .HasForeignKey("CodeGroupe")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Departement");

                    b.Navigation("Groupe");
                });

            modelBuilder.Entity("mini.project.Models.Enseignant", b =>
                {
                    b.HasOne("mini.project.Models.Departement", "Departement")
                        .WithMany("Enseignants")
                        .HasForeignKey("CodeDepartement")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mini.project.Models.Grade", "Grade")
                        .WithMany("Enseignants")
                        .HasForeignKey("CodeGrade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departement");

                    b.Navigation("Grade");
                });

            modelBuilder.Entity("mini.project.Models.Etudiant", b =>
                {
                    b.HasOne("mini.project.Models.Classe", "Classe")
                        .WithMany("Etudiants")
                        .HasForeignKey("CodeClasse");

                    b.Navigation("Classe");
                });

            modelBuilder.Entity("mini.project.Models.FicheAbsence", b =>
                {
                    b.HasOne("mini.project.Models.Classe", "Classe")
                        .WithMany("FichesAbsence")
                        .HasForeignKey("CodeClasse")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mini.project.Models.Enseignant", "Enseignant")
                        .WithMany()
                        .HasForeignKey("CodeEnseignant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mini.project.Models.Matiere", "Matiere")
                        .WithMany("FichesAbsence")
                        .HasForeignKey("CodeMatiere")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Classe");

                    b.Navigation("Enseignant");

                    b.Navigation("Matiere");
                });

            modelBuilder.Entity("mini.project.Models.FicheAbsenceSeance", b =>
                {
                    b.HasOne("mini.project.Models.FicheAbsence", "FicheAbsence")
                        .WithMany("FichesAbsenceSeances")
                        .HasForeignKey("CodeFicheAbsence")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mini.project.Models.Seance", "Seance")
                        .WithMany("FichesAbsenceSeances")
                        .HasForeignKey("CodeSeance")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FicheAbsence");

                    b.Navigation("Seance");
                });

            modelBuilder.Entity("mini.project.Models.LigneFicheAbsence", b =>
                {
                    b.HasOne("mini.project.Models.Etudiant", "Etudiant")
                        .WithMany("LignesFicheAbsence")
                        .HasForeignKey("CodeEtudiant")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("mini.project.Models.FicheAbsenceSeance", "FicheAbsenceSeance")
                        .WithMany("LignesFicheAbsence")
                        .HasForeignKey("CodeFicheAbsenceSeance")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Etudiant");

                    b.Navigation("FicheAbsenceSeance");
                });

            modelBuilder.Entity("mini.project.Models.Classe", b =>
                {
                    b.Navigation("Etudiants");

                    b.Navigation("FichesAbsence");
                });

            modelBuilder.Entity("mini.project.Models.Departement", b =>
                {
                    b.Navigation("Classes");

                    b.Navigation("Enseignants");
                });

            modelBuilder.Entity("mini.project.Models.Etudiant", b =>
                {
                    b.Navigation("LignesFicheAbsence");
                });

            modelBuilder.Entity("mini.project.Models.FicheAbsence", b =>
                {
                    b.Navigation("FichesAbsenceSeances");
                });

            modelBuilder.Entity("mini.project.Models.FicheAbsenceSeance", b =>
                {
                    b.Navigation("LignesFicheAbsence");
                });

            modelBuilder.Entity("mini.project.Models.Grade", b =>
                {
                    b.Navigation("Enseignants");
                });

            modelBuilder.Entity("mini.project.Models.Groupe", b =>
                {
                    b.Navigation("Classes");
                });

            modelBuilder.Entity("mini.project.Models.Matiere", b =>
                {
                    b.Navigation("FichesAbsence");
                });

            modelBuilder.Entity("mini.project.Models.Seance", b =>
                {
                    b.Navigation("FichesAbsenceSeances");
                });
#pragma warning restore 612, 618
        }
    }
}
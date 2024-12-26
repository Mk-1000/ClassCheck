using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace esprim.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Departements",
                columns: table => new
                {
                    CodeDepartement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomDepartement = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.CodeDepartement);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    CodeGrade = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomGrade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.CodeGrade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Groupes",
                columns: table => new
                {
                    CodeGroupe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomGroupe = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.CodeGroupe);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Matieres",
                columns: table => new
                {
                    CodeMatiere = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomMatiere = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NbreHeureCoursParSemaine = table.Column<int>(type: "int", nullable: false),
                    NbreHeureTDParSemaine = table.Column<int>(type: "int", nullable: false),
                    NbreHeureTPParSemaine = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matieres", x => x.CodeMatiere);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Seances",
                columns: table => new
                {
                    CodeSeance = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomSeance = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeureDebut = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    HeureFin = table.Column<TimeSpan>(type: "time(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seances", x => x.CodeSeance);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Enseignants",
                columns: table => new
                {
                    CodeEnseignant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prenom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateRecrutement = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Adresse = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tel = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodeDepartement = table.Column<int>(type: "int", nullable: false),
                    CodeGrade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignants", x => x.CodeEnseignant);
                    table.ForeignKey(
                        name: "FK_Enseignants_Departements_CodeDepartement",
                        column: x => x.CodeDepartement,
                        principalTable: "Departements",
                        principalColumn: "CodeDepartement",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enseignants_Grades_CodeGrade",
                        column: x => x.CodeGrade,
                        principalTable: "Grades",
                        principalColumn: "CodeGrade",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    CodeClasse = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomClasse = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodeGroupe = table.Column<int>(type: "int", nullable: true),
                    CodeDepartement = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.CodeClasse);
                    table.ForeignKey(
                        name: "FK_Classes_Departements_CodeDepartement",
                        column: x => x.CodeDepartement,
                        principalTable: "Departements",
                        principalColumn: "CodeDepartement",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Classes_Groupes_CodeGroupe",
                        column: x => x.CodeGroupe,
                        principalTable: "Groupes",
                        principalColumn: "CodeGroupe",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Etudiants",
                columns: table => new
                {
                    CodeEtudiant = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prenom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateNaissance = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    NumInscription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Adresse = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mail = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Tel = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodeClasse = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.CodeEtudiant);
                    table.ForeignKey(
                        name: "FK_Etudiants_Classes_CodeClasse",
                        column: x => x.CodeClasse,
                        principalTable: "Classes",
                        principalColumn: "CodeClasse");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FichesAbsence",
                columns: table => new
                {
                    CodeFicheAbsence = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateJour = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CodeMatiere = table.Column<int>(type: "int", nullable: false),
                    CodeEnseignant = table.Column<int>(type: "int", nullable: false),
                    CodeClasse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichesAbsence", x => x.CodeFicheAbsence);
                    table.ForeignKey(
                        name: "FK_FichesAbsence_Classes_CodeClasse",
                        column: x => x.CodeClasse,
                        principalTable: "Classes",
                        principalColumn: "CodeClasse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FichesAbsence_Enseignants_CodeEnseignant",
                        column: x => x.CodeEnseignant,
                        principalTable: "Enseignants",
                        principalColumn: "CodeEnseignant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FichesAbsence_Matieres_CodeMatiere",
                        column: x => x.CodeMatiere,
                        principalTable: "Matieres",
                        principalColumn: "CodeMatiere",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FichesAbsenceSeances",
                columns: table => new
                {
                    CodeFicheAbsenceSeance = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodeFicheAbsence = table.Column<int>(type: "int", nullable: false),
                    CodeSeance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FichesAbsenceSeances", x => x.CodeFicheAbsenceSeance);
                    table.ForeignKey(
                        name: "FK_FichesAbsenceSeances_FichesAbsence_CodeFicheAbsence",
                        column: x => x.CodeFicheAbsence,
                        principalTable: "FichesAbsence",
                        principalColumn: "CodeFicheAbsence",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FichesAbsenceSeances_Seances_CodeSeance",
                        column: x => x.CodeSeance,
                        principalTable: "Seances",
                        principalColumn: "CodeSeance",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LignesFicheAbsence",
                columns: table => new
                {
                    CodeLigneFicheAbsence = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodeEtudiant = table.Column<int>(type: "int", nullable: false),
                    CodeFicheAbsenceSeance = table.Column<int>(type: "int", nullable: false),
                    IsAbsent = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LignesFicheAbsence", x => x.CodeLigneFicheAbsence);
                    table.ForeignKey(
                        name: "FK_LignesFicheAbsence_Etudiants_CodeEtudiant",
                        column: x => x.CodeEtudiant,
                        principalTable: "Etudiants",
                        principalColumn: "CodeEtudiant",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LignesFicheAbsence_FichesAbsenceSeances_CodeFicheAbsenceSean~",
                        column: x => x.CodeFicheAbsenceSeance,
                        principalTable: "FichesAbsenceSeances",
                        principalColumn: "CodeFicheAbsenceSeance",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CodeDepartement",
                table: "Classes",
                column: "CodeDepartement");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CodeGroupe",
                table: "Classes",
                column: "CodeGroupe");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignants_CodeDepartement",
                table: "Enseignants",
                column: "CodeDepartement");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignants_CodeGrade",
                table: "Enseignants",
                column: "CodeGrade");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_CodeClasse",
                table: "Etudiants",
                column: "CodeClasse");

            migrationBuilder.CreateIndex(
                name: "IX_FichesAbsence_CodeClasse",
                table: "FichesAbsence",
                column: "CodeClasse");

            migrationBuilder.CreateIndex(
                name: "IX_FichesAbsence_CodeEnseignant",
                table: "FichesAbsence",
                column: "CodeEnseignant");

            migrationBuilder.CreateIndex(
                name: "IX_FichesAbsence_CodeMatiere",
                table: "FichesAbsence",
                column: "CodeMatiere");

            migrationBuilder.CreateIndex(
                name: "IX_FichesAbsenceSeances_CodeFicheAbsence",
                table: "FichesAbsenceSeances",
                column: "CodeFicheAbsence");

            migrationBuilder.CreateIndex(
                name: "IX_FichesAbsenceSeances_CodeSeance",
                table: "FichesAbsenceSeances",
                column: "CodeSeance");

            migrationBuilder.CreateIndex(
                name: "IX_LignesFicheAbsence_CodeEtudiant",
                table: "LignesFicheAbsence",
                column: "CodeEtudiant");

            migrationBuilder.CreateIndex(
                name: "IX_LignesFicheAbsence_CodeFicheAbsenceSeance",
                table: "LignesFicheAbsence",
                column: "CodeFicheAbsenceSeance");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LignesFicheAbsence");

            migrationBuilder.DropTable(
                name: "Etudiants");

            migrationBuilder.DropTable(
                name: "FichesAbsenceSeances");

            migrationBuilder.DropTable(
                name: "FichesAbsence");

            migrationBuilder.DropTable(
                name: "Seances");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Enseignants");

            migrationBuilder.DropTable(
                name: "Matieres");

            migrationBuilder.DropTable(
                name: "Groupes");

            migrationBuilder.DropTable(
                name: "Departements");

            migrationBuilder.DropTable(
                name: "Grades");
        }
    }
}

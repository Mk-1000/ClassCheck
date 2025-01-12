using System;
using System.Collections.Generic;

namespace mini.project.Models
{
    public class Dashboard
    {
        // Total counts for various entities
        public int TotalStudents { get; set; }
        public int TotalProfessors { get; set; }
        public int TotalClasses { get; set; }
        public int TotalDepartments { get; set; }

        // List of recent absence records to be displayed on the dashboard
        public List<AbsenceRecordViewModel> RecentAbsenceRecords { get; set; }

        // Pagination information
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
    }

    // ViewModel to represent each absence record in the list
    public class AbsenceRecordViewModel
    {
        public List<string> StudentNames { get; set; }  // List of absent student names
        public string ClassName { get; set; }
        public DateTime Date { get; set; }
        public string Seance { get; set; }  // Add this property
        public bool IsExcused { get; set; }
    }
    public class StudentViewModel
    {
        public int CodeEtudiant { get; set; }
        public string FullName { get; set; }
        public int CodeClasse { get; set; }
    }

}

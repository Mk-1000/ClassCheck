# Mini Project - .NET

## Overview

This project is a mini application built with **ASP.NET Core**, which involves managing and tracking student absences, courses, departments, groups, and instructors. It includes functionality for CRUD operations on various entities such as `Classe`, `Departement`, `Enseignant`, `Etudiant`, and `FicheAbsence`.

## Table of Contents

- [Technologies Used](#technologies-used)
- [Setup and Installation](#setup-and-installation)
- [Database Setup](#database-setup)
- [Entities](#entities)
- [Project Structure](#project-structure)
- [License](#license)

## Technologies Used

- **ASP.NET Core** (MVC Architecture)
- **Entity Framework Core** (ORM)
- **SQL Server/MySQL** (Database)
- **Bootstrap 5** (Frontend Framework)
- **jQuery** (Frontend Library)

## Setup and Installation

To get started with this project locally, follow these steps:

1. **Clone the Repository**  
   Clone the repository to your local machine using Git:
   ```bash
   git clone https://github.com/yourusername/mini.projet.net.git
   ```

2. **Restore NuGet Packages**  
   Open the solution in Visual Studio or use the following command to restore the required packages:
   ```bash
   dotnet restore
   ```

3. **Database Configuration**  
   Ensure your database connection is set up properly in the `appsettings.json` file:
   ```json
   "ConnectionStrings": {
       "DefaultConnection": "server=localhost;database=yourdb;user=root;password=yourpassword"
   }
   ```

4. **Apply Database Migrations**  
   Run the following commands to create the necessary database tables based on your models:
   ```bash
   dotnet ef database update
   ```

5. **Run the Application**  
   Start the application using:
   ```bash
   dotnet run
   ```

   Open your browser and navigate to `http://localhost:5000` to access the application.

6. ## Demo

![Demo GIF](assets/demo.gif)
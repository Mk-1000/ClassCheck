using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using mini.project.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
{
    public MyDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
        var connectionString = "server=localhost;port=3306;database=miniproject;uid=root;password=Root@712;charset=utf8mb4";

        optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 32)));

        return new MyDbContext(optionsBuilder.Options);
    }
}

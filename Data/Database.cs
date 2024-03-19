using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using TaplistBlib.Models;

public class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }

    public string DbPath { get; }

    public BloggingContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "blogging.db");
    }

    // Configuration pour utiliser MySQL
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;port=3306;database=DataBeer;user=root;password=koala355;",
                new MySqlServerVersion(new Version(8, 0, 23))); 
        }
    }
}




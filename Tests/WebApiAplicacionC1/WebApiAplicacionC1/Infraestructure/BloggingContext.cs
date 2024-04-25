//FASE 1:  
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using WebApiAplicacionC1.Infraestructure;
using WebApiAplicacionC1.Models;

internal class BloggingContext : DbContext
{
    
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
    {

    }

}



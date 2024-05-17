using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HelloWorldAPI.Models;

public partial class WebContext : DbContext
{
    private readonly IConfiguration _configuration;
    

    public WebContext(IConfiguration configuration, DbContextOptions<WebContext> options)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Employee> Employee { get; set; }

    public virtual DbSet<News> News { get; set; }

    public virtual DbSet<NewsFiles> NewsFiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("WebDatabase"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.EmployeeId).ValueGeneratedOnAdd();
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<News>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.EndDateTime).HasColumnType("datetime");
            entity.Property(e => e.InsertDateTime).HasColumnType("datetime");
            entity.Property(e => e.StartDateTime).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(250);
            entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");
        });

        modelBuilder.Entity<NewsFiles>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Extension).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

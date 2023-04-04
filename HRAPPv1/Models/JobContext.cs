using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HRAPPv1.Models;

public partial class JobContext : DbContext
{
    public JobContext()
    {
    }

    public JobContext(DbContextOptions<JobContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ColaboradorCompetency> ColaboradorCompetencies { get; set; }

    public virtual DbSet<ColaboradorType> ColaboradorTypes { get; set; }

    public virtual DbSet<Competency> Competencies { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
		{
       

//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//    => optionsBuilder.UseSqlServer("server= LAPTOP-4IKMKHGF\\SQLEXPRESS; database=Job; integrated security=true; Encrypt=False;");
		}
	}
	protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ColaboradorCompetency>(entity =>
        {
            entity.HasKey(e => e.Idcc);

            entity.Property(e => e.ColaboradorTypeIdType).HasMaxLength(450);
            entity.Property(e => e.CompetencieIdCompetencie).HasMaxLength(450);

            entity.HasOne(d => d.ColaboradorTypeIdTypeNavigation).WithMany(p => p.ColaboradorCompetencies).HasForeignKey(d => d.ColaboradorTypeIdType);

            entity.HasOne(d => d.CompetencieIdCompetencieNavigation).WithMany(p => p.ColaboradorCompetencies).HasForeignKey(d => d.CompetencieIdCompetencie);
        });

        modelBuilder.Entity<ColaboradorType>(entity =>
        {
            entity.HasKey(e => e.IdType);
        });

        modelBuilder.Entity<Competency>(entity =>
        {
            entity.HasKey(e => e.IdCompetencie);
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.HasKey(e => e.IdQuestion);

            entity.Property(e => e.CompetencieIdCompetencie).HasMaxLength(450);

            entity.HasOne(d => d.CompetencieIdCompetencieNavigation).WithMany(p => p.Questions).HasForeignKey(d => d.CompetencieIdCompetencie);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

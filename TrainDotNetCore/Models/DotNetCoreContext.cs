using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TrainDotNetCore.Models
{
    public partial class DotNetCoreContext : DbContext
    {
        public DotNetCoreContext()
        {
        }

        public DotNetCoreContext(DbContextOptions<DotNetCoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AppParameter> AppParameter { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Hero> Hero { get; set; }
        public virtual DbSet<ParameterDetail> ParameterDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=DotNetCore;Persist Security Info=True;User ID=adminEWF;Password=P@ssw0rd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<AppParameter>(entity =>
            {
                entity.ToTable("app_parameter");

                entity.HasIndex(e => e.Code)
                    .HasName("UK_gtiaw1dp6waq5evtqotn10uk4")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ParameterDescription)
                    .HasColumnName("parameter_description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("updated_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Version).HasColumnName("version");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IpAddress)
                    .HasColumnName("ip_address")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hero>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ParameterDetail>(entity =>
            {
                entity.ToTable("parameter_detail");

                entity.HasIndex(e => new { e.Code, e.AppParameter })
                    .HasName("UK_t5w89twlin0k5gq84vooo0dq")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("numeric(19, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AppParameter)
                    .HasColumnName("app_parameter")
                    .HasColumnType("numeric(19, 0)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommentParameterValue1)
                    .HasColumnName("comment_parameter_value1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommentParameterValue10)
                    .HasColumnName("comment_parameter_value10")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommentParameterValue2)
                    .HasColumnName("comment_parameter_value2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommentParameterValue3)
                    .HasColumnName("comment_parameter_value3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommentParameterValue4)
                    .HasColumnName("comment_parameter_value4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommentParameterValue5)
                    .HasColumnName("comment_parameter_value5")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommentParameterValue6)
                    .HasColumnName("comment_parameter_value6")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommentParameterValue7)
                    .HasColumnName("comment_parameter_value7")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommentParameterValue8)
                    .HasColumnName("comment_parameter_value8")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CommentParameterValue9)
                    .HasColumnName("comment_parameter_value9")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("created_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ParameterDescription)
                    .HasColumnName("parameter_description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterValue1)
                    .HasColumnName("parameter_value1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterValue10)
                    .HasColumnName("parameter_value10")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterValue2)
                    .HasColumnName("parameter_value2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterValue3)
                    .HasColumnName("parameter_value3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterValue4)
                    .HasColumnName("parameter_value4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterValue5)
                    .HasColumnName("parameter_value5")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterValue6)
                    .HasColumnName("parameter_value6")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterValue7)
                    .HasColumnName("parameter_value7")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterValue8)
                    .HasColumnName("parameter_value8")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ParameterValue9)
                    .HasColumnName("parameter_value9")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasColumnName("updated_by")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnName("updated_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Version).HasColumnName("version");

                entity.HasOne(d => d.AppParameterNavigation)
                    .WithMany(p => p.ParameterDetail)
                    .HasForeignKey(d => d.AppParameter)
                    .HasConstraintName("FK_81ybinmyp8gbvewkd5hqupv84");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
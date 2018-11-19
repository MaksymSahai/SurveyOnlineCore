using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SurveyOnlineCore.Data.Entities;

namespace SurveyOnlineCore.Data
{
    public partial class SurveyOnlineContext : DbContext
    {
        public SurveyOnlineContext()
        {
        }

        public SurveyOnlineContext(DbContextOptions<SurveyOnlineContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnswerVariants> AnswerVariants { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<QuestionTypes> QuestionTypes { get; set; }
        public virtual DbSet<Surveys> Surveys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=SO_DataBase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnswerVariants>(entity =>
            {
                entity.HasKey(e => e.AnswerVariantId);

                entity.Property(e => e.AnswerVariantId).ValueGeneratedNever();

                entity.Property(e => e.AnswerVariantName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.AnswerVariants)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AnswerVar__Quest__2E1BDC42");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.Property(e => e.CustomerId).ValueGeneratedNever();

                entity.Property(e => e.CustomerAbilities).IsRequired();

                entity.Property(e => e.CustomerEmail)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CustomerPassword)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.CustomerSalt)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.HasKey(e => e.QuestionId);

                entity.Property(e => e.QuestionId).ValueGeneratedNever();

                entity.Property(e => e.QuestionName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SelectedAnswer)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.QuestionType)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.QuestionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Questions__Quest__2A4B4B5E");

                entity.HasOne(d => d.Surveys)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.SurveysId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Questions__Surve__2B3F6F97");
            });

            modelBuilder.Entity<QuestionTypes>(entity =>
            {
                entity.HasKey(e => e.QuestionTypeId);

                entity.Property(e => e.QuestionTypeId).ValueGeneratedNever();

                entity.Property(e => e.QuestionTypeDescription).IsRequired();

                entity.Property(e => e.QuestionTypeName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Surveys>(entity =>
            {
                entity.Property(e => e.SurveysId).ValueGeneratedNever();

                entity.Property(e => e.SurveyDescription).IsRequired();

                entity.Property(e => e.SurveyName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.SurveyUrl)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Surveys)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Surveys__Custome__25869641");
            });
        }
    }
}

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
        public virtual DbSet<Questionnaires> Questionnaires { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<QuestionTypes> QuestionTypes { get; set; }
        public virtual DbSet<Surveys> Surveys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnswerVariants>(entity =>
            {
                entity.Property(e => e.AnswerVariantId).ValueGeneratedNever();

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.AnswerVariants)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AnswerVar__Quest__2E1BDC42");
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.Property(e => e.CustomerId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Questionnaires>(entity =>
            {
                entity.Property(e => e.QuestionnairesId).ValueGeneratedNever();

                entity.HasOne(d => d.AnswerVariant)
                    .WithMany(p => p.Questionnaires)
                    .HasForeignKey(d => d.AnswerVariantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Questionn__Answe__04E4BC85");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Questionnaires)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Questionn__Quest__03F0984C");

                entity.HasOne(d => d.Surveys)
                    .WithMany(p => p.Questionnaires)
                    .HasForeignKey(d => d.SurveysId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Questionn__Surve__02FC7413");
            });


            modelBuilder.Entity<Questions>(entity =>
            {
                entity.Property(e => e.QuestionId).ValueGeneratedNever();

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
                entity.Property(e => e.QuestionTypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<Surveys>(entity =>
            {
                entity.Property(e => e.SurveysId).ValueGeneratedNever();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Surveys)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Surveys__Custome__25869641");
            });
        }
    }
}

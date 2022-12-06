using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TournamentDistributionHexa.Infrastructure.Models
{
    public partial class RepartitionTournoiContext : DbContext
    {
        public RepartitionTournoiContext()
        {
        }

        public RepartitionTournoiContext(DbContextOptions<RepartitionTournoiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Composition> Compositions { get; set; } = null!;
        public virtual DbSet<Jeu> Jeus { get; set; } = null!;
        public virtual DbSet<Joueur> Joueurs { get; set; } = null!;
        public virtual DbSet<Match> Matches { get; set; } = null!;
        public virtual DbSet<Mecanique> Mecaniques { get; set; } = null!;
        public virtual DbSet<Score> Scores { get; set; } = null!;
        public virtual DbSet<Tournoi> Tournois { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Composition>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.JeuId, e.TournoiId })
                    .HasName("PK_MatchTournoiJeu");

                entity.ToTable("Composition");

                entity.HasOne(d => d.Jeu)
                    .WithMany(p => p.Compositions)
                    .HasForeignKey(d => d.JeuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MatchTour__JeuId__628FA481");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Compositions)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK__MatchTour__Match__619B8048");

                entity.HasOne(d => d.Tournoi)
                    .WithMany(p => p.Compositions)
                    .HasForeignKey(d => d.TournoiId)
                    .HasConstraintName("FK__MatchTour__Tourn__6383C8BA");
            });

            modelBuilder.Entity<Jeu>(entity =>
            {
                entity.ToTable("Jeu");

                entity.Property(e => e.Nom).HasMaxLength(100);

                entity.HasOne(d => d.Mecanique)
                    .WithMany(p => p.Jeus)
                    .HasForeignKey(d => d.MecaniqueId)
                    .HasConstraintName("FK__Jeu__MecaniqueId__45F365D3");
            });

            modelBuilder.Entity<Joueur>(entity =>
            {
                entity.ToTable("Joueur");

                entity.Property(e => e.Nom).HasMaxLength(50);

                entity.Property(e => e.Prenom).HasMaxLength(50);

                entity.Property(e => e.Telephone).HasMaxLength(50);
            });

            modelBuilder.Entity<Match>(entity =>
            {
                entity.ToTable("Match");

                entity.Property(e => e.DateFin).HasColumnType("datetime");

                entity.Property(e => e.Nom).HasMaxLength(50);
            });

            modelBuilder.Entity<Mecanique>(entity =>
            {
                entity.ToTable("Mecanique");

                entity.Property(e => e.Nom).HasMaxLength(50);
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.JoueurId });

                entity.ToTable("Score");

                entity.HasOne(d => d.Joueur)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.JoueurId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Score__JoueurId__5441852A");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.Scores)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("FK__Score__MatchId__534D60F1");
            });

            modelBuilder.Entity<Tournoi>(entity =>
            {
                entity.ToTable("Tournoi");

                entity.Property(e => e.DateDebut).HasColumnType("datetime");

                entity.Property(e => e.DateFin).HasColumnType("datetime");

                entity.Property(e => e.Nom).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TrainDetailsAPI.Models
{
    public partial class TICKET_BOOKINGContext : DbContext
    {
        public TICKET_BOOKINGContext()
        {
        }

        public TICKET_BOOKINGContext(DbContextOptions<TICKET_BOOKINGContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<PassengerDetail> PassengerDetails { get; set; }
        public virtual DbSet<Register> Registers { get; set; }
        public virtual DbSet<TrainDetail> TrainDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=KANINI-LTP-333;Database=TICKET_BOOKING;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<BookingDetail>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK__BOOKING___C1EBE7B37CE2DC97");

                entity.ToTable("BOOKING_DETAILS");

                entity.Property(e => e.BookingId).HasColumnName("BOOKING_ID");

                entity.Property(e => e.BookingStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BOOKING_STATUS");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL_ID");

                entity.Property(e => e.FromStation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FROM_STATION");

                entity.Property(e => e.JourneyDate)
                    .HasColumnType("date")
                    .HasColumnName("JOURNEY_DATE");

                entity.Property(e => e.NoOfSeats).HasColumnName("NO_OF_SEATS");

                entity.Property(e => e.ToStation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TO_STATION");

                entity.Property(e => e.TrainNo).HasColumnName("TRAIN_NO");

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.EmailId)
                    .HasConstraintName("FK__BOOKING_D__EMAIL__3A81B327");

                entity.HasOne(d => d.TrainNoNavigation)
                    .WithMany(p => p.BookingDetails)
                    .HasForeignKey(d => d.TrainNo)
                    .HasConstraintName("FK__BOOKING_D__TRAIN__3B75D760");
            });

            modelBuilder.Entity<PassengerDetail>(entity =>
            {
                entity.HasKey(e => e.SerialNo)
                    .HasName("PK__PASSENGE__2A5625AAAD80873A");

                entity.ToTable("PASSENGER_DETAILS");

                entity.Property(e => e.SerialNo).HasColumnName("SERIAL_NO");

                entity.Property(e => e.Age).HasColumnName("AGE");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL_ID");

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.PassengerName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PASSENGER_NAME");

                entity.Property(e => e.TrainNo).HasColumnName("TRAIN_NO");

                entity.HasOne(d => d.Email)
                    .WithMany(p => p.PassengerDetails)
                    .HasForeignKey(d => d.EmailId)
                    .HasConstraintName("FK__PASSENGER__EMAIL__3F466844");

                entity.HasOne(d => d.TrainNoNavigation)
                    .WithMany(p => p.PassengerDetails)
                    .HasForeignKey(d => d.TrainNo)
                    .HasConstraintName("FK__PASSENGER__TRAIN__3E52440B");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("PK__REGISTER__6BB22C4DBCA68432");

                entity.ToTable("REGISTER");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADDRESS");

                entity.Property(e => e.ConfirmPassword)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CONFIRM_PASSWORD");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PHONE_NO");
            });

            modelBuilder.Entity<TrainDetail>(entity =>
            {
                entity.HasKey(e => e.TrainNo)
                    .HasName("PK__TRAIN_DE__84E4E0F922269264");

                entity.ToTable("TRAIN_DETAILS");

                entity.Property(e => e.TrainNo).HasColumnName("TRAIN_NO");

                entity.Property(e => e.FareA).HasColumnName("FARE_A");

                entity.Property(e => e.FareB).HasColumnName("FARE_B");

                entity.Property(e => e.FareC).HasColumnName("FARE_C");

                entity.Property(e => e.FromStation)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FROM_STATION");

                entity.Property(e => e.JourneyDate)
                    .HasColumnType("date")
                    .HasColumnName("JOURNEY_DATE");

                entity.Property(e => e.SeatAvailA).HasColumnName("SEAT_AVAIL_A");

                entity.Property(e => e.SeatAvailB).HasColumnName("SEAT_AVAIL_B");

                entity.Property(e => e.SeatAvailC).HasColumnName("SEAT_AVAIL_C");

                entity.Property(e => e.ToStation)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TO_STATION");

                entity.Property(e => e.TrainName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRAIN_NAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

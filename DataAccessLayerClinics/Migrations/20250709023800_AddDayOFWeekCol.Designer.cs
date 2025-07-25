﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _3_DataAccessLayerClinics.Models;

#nullable disable

namespace _3_DataAccessLayerClinics.Migrations
{
    [DbContext(typeof(ClinicDBContext))]
    [Migration("20250709023800_AddDayOFWeekCol")]
    partial class AddDayOFWeekCol
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_3_DataAccessLayerClinics.Models.Booking", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateOnly>("BookingDate")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("BookingTime")
                        .HasColumnType("time");

                    b.Property<DateOnly>("CreatedAt")
                        .HasColumnType("date");

                    b.Property<int?>("CreatedByNurseID")
                        .HasColumnType("int");

                    b.Property<decimal?>("DetectionCost")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int?>("DoctorID")
                        .HasColumnType("int");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int?>("OrderID")
                        .HasColumnType("int");

                    b.Property<int?>("PatientID")
                        .HasColumnType("int");

                    b.HasKey("ID")
                        .HasName("PK__Bookings__3214EC27CDF1AB5B");

                    b.HasIndex("CreatedByNurseID");

                    b.HasIndex("DoctorID");

                    b.HasIndex("PatientID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("_3_DataAccessLayerClinics.Models.Doctor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("NurseID")
                        .HasColumnType("int");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .IsFixedLength();

                    b.Property<string>("SecondName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("SpecialtyID")
                        .HasColumnType("int");

                    b.Property<string>("ThirdName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .IsFixedLength();

                    b.Property<string>("password")
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .IsFixedLength();

                    b.HasKey("ID")
                        .HasName("PK__Doctors__3214EC272C30FD7C");

                    b.HasIndex("NurseID");

                    b.HasIndex("SpecialtyID");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("_3_DataAccessLayerClinics.Models.DoctorSchedule", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("DayOfWeek")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime");

                    b.HasKey("ID")
                        .HasName("PK__DoctorSc__3214EC27D3AD828A");

                    b.ToTable("DoctorSchedule", (string)null);
                });

            modelBuilder.Entity("_3_DataAccessLayerClinics.Models.Nurse", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .IsFixedLength();

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("Salt")
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .IsFixedLength();

                    b.Property<string>("SecondName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ThirdName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .HasMaxLength(100)
                        .HasColumnType("nchar(100)")
                        .IsFixedLength();

                    b.HasKey("ID")
                        .HasName("PK__Nurses__3214EC271C2B6E6B");

                    b.ToTable("Nurses");
                });

            modelBuilder.Entity("_3_DataAccessLayerClinics.Models.Patient", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("SecondName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ThirdName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID")
                        .HasName("PK__Patients__3214EC27AF2CDC74");

                    b.HasIndex("Phone")
                        .IsUnique();

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("_3_DataAccessLayerClinics.Models.Payment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("BookingID")
                        .HasColumnType("int");

                    b.Property<decimal?>("DetectionCost")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<bool?>("IsCash")
                        .HasColumnType("bit");

                    b.Property<string>("PaymentMethod")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("phoneNumberpaymentTo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID")
                        .HasName("PK__Payments__3214EC27008BDE01");

                    b.HasIndex("BookingID");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("_3_DataAccessLayerClinics.Models.Review", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("BookingID")
                        .HasColumnType("int");

                    b.Property<int?>("DoctorID")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PatientID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReviewDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.HasKey("ID")
                        .HasName("PK__Reviews__3214EC27CC92E2B4");

                    b.HasIndex("BookingID");

                    b.HasIndex("PatientID");

                    b.HasIndex(new[] { "DoctorID" }, "IX_Reviews_DoctorID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("_3_DataAccessLayerClinics.Models.ScheduleDoctorMapping", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal?>("DetectionCost")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int?>("DoctorID")
                        .HasColumnType("int");

                    b.Property<int?>("DoctorScheduleID")
                        .HasColumnType("int");

                    b.HasKey("ID")
                        .HasName("PK__Schedule__3214EC27F6B94BF9");

                    b.HasIndex("DoctorID");

                    b.HasIndex("DoctorScheduleID");

                    b.ToTable("ScheduleDoctorMapping", (string)null);
                });

            modelBuilder.Entity("_3_DataAccessLayerClinics.Models.Specialty", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID")
                        .HasName("PK__Specialt__3214EC271470B744");

                    b.HasIndex(new[] { "Name" }, "UQ__Specialt__737584F656FE1CC5")
                        .IsUnique();

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("_3_DataAccessLayerClinics.Models.Booking", b =>
                {
                    b.HasOne("_3_DataAccessLayerClinics.Models.Nurse", "CreatedByNurse")
                        .WithMany("Bookings")
                        .HasForeignKey("CreatedByNurseID")
                        .HasConstraintName("FK_Bookings_Nurses");

                    b.HasOne("_3_DataAccessLayerClinics.Models.Doctor", "Doctor")
                        .WithMany("Bookings")
                        .HasForeignKey("DoctorID")
                        .HasConstraintName("FK__Bookings__Doctor__4E88ABD4");

                    b.HasOne("_3_DataAccessLayerClinics.Models.Patient", "Patient")
                        .WithMany("Bookings")
                        .HasForeignKey("PatientID")
                        .HasConstraintName("FK__Bookings__Patien__4D94879B");

                    b.Navigation("CreatedByNurse");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("_3_DataAccessLayerClinics.Models.Doctor", b =>
                {
                    b.HasOne("_3_DataAccessLayerClinics.Models.Nurse", "Nurse")
                        .WithMany("Doctors")
                        .HasForeignKey("NurseID")
                        .HasConstraintName("FK_Doctors_Nurses");

                    b.HasOne("_3_DataAccessLayerClinics.Models.Specialty", "Specialty")
                        .WithMany("Doctors")
                        .HasForeignKey("SpecialtyID")
                        .HasConstraintName("FK__Doctors__Special__3C69FB99");

                    b.Navigation("Nurse");

                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("_3_DataAccessLayerClinics.Models.Payment", b =>
                {
                    b.HasOne("_3_DataAccessLayerClinics.Models.Booking", "Booking")
                        .WithMany("Payments")
                        .HasForeignKey("BookingID")
                        .HasConstraintName("FK__Payments__Bookin__5165187F");

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("_3_DataAccessLayerClinics.Models.Review", b =>
                {
                    b.HasOne("_3_DataAccessLayerClinics.Models.Booking", "Booking")
                        .WithMany("Reviews")
                        .HasForeignKey("BookingID")
                        .HasConstraintName("FK__Reviews__Booking__5535A963");

                    b.HasOne("_3_DataAccessLayerClinics.Models.Doctor", "Doctor")
                        .WithMany("Reviews")
                        .HasForeignKey("DoctorID");

                    b.HasOne("_3_DataAccessLayerClinics.Models.Patient", "Patient")
                        .WithMany("Reviews")
                        .HasForeignKey("PatientID")
                        .HasConstraintName("FK__Reviews__Patient__5629CD9C");

                    b.Navigation("Booking");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("_3_DataAccessLayerClinics.Models.ScheduleDoctorMapping", b =>
                {
                    b.HasOne("_3_DataAccessLayerClinics.Models.Doctor", "Doctor")
                        .WithMany("ScheduleDoctorMappings")
                        .HasForeignKey("DoctorID")
                        .HasConstraintName("FK__ScheduleD__Docto__49C3F6B7");

                    b.HasOne("_3_DataAccessLayerClinics.Models.DoctorSchedule", "DoctorSchedule")
                        .WithMany("ScheduleDoctorMappings")
                        .HasForeignKey("DoctorScheduleID")
                        .HasConstraintName("FK__ScheduleD__Docto__4AB81AF0");

                    b.Navigation("Doctor");

                    b.Navigation("DoctorSchedule");
                });

            modelBuilder.Entity("_3_DataAccessLayerClinics.Models.Booking", b =>
                {
                    b.Navigation("Payments");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("_3_DataAccessLayerClinics.Models.Doctor", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Reviews");

                    b.Navigation("ScheduleDoctorMappings");
                });

            modelBuilder.Entity("_3_DataAccessLayerClinics.Models.DoctorSchedule", b =>
                {
                    b.Navigation("ScheduleDoctorMappings");
                });

            modelBuilder.Entity("_3_DataAccessLayerClinics.Models.Nurse", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Doctors");
                });

            modelBuilder.Entity("_3_DataAccessLayerClinics.Models.Patient", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("_3_DataAccessLayerClinics.Models.Specialty", b =>
                {
                    b.Navigation("Doctors");
                });
#pragma warning restore 612, 618
        }
    }
}

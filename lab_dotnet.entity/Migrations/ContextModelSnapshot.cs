﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab_dotnet.entity;

#nullable disable

namespace lab_dotnet.entity.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.Borrower", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Inn")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PassportIssueDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PassportIssuerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PassportNumber")
                        .HasColumnType("int");

                    b.Property<int>("PassportSerial")
                        .HasColumnType("int");

                    b.Property<string>("RegistrationAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResidentialAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Snils")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Inn")
                        .IsUnique();

                    b.HasIndex("PassportIssuerId");

                    b.HasIndex("Snils")
                        .IsUnique();

                    b.HasIndex("PassportSerial", "PassportNumber", "PassportIssuerId", "PassportIssueDate")
                        .IsUnique();

                    b.ToTable("Borrowers", (string)null);

                    b.HasCheckConstraint("PassportIssueDate", "PassportIssueDate > Birthdate");

                    b.HasCheckConstraint("PassportNumber", "PassportNumber >= 100000 and PassportNumber <= 999999");

                    b.HasCheckConstraint("PassportSerial", "PassportSerial >= 1000 and PassportSerial <= 9999");
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.Contribution", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BorrowerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ContributionDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ContributorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BorrowerId");

                    b.HasIndex("ContributorId");

                    b.ToTable("Contributions", (string)null);
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.Contributor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Inn")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Inn")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Contributors", (string)null);
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.Credit", b =>
                {
                    b.Property<Guid>("CreditApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("InterestRate")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CreditApplicationId");

                    b.ToTable("Credits", (string)null);

                    b.HasCheckConstraint("InterestRate", "InterestRate >= 0 and InterestRate <= 100");
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.CreditApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ApplicationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("BorrowerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreditAmount")
                        .HasColumnType("int");

                    b.Property<Guid>("CreditTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreditorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("BorrowerId");

                    b.HasIndex("CreditTypeId");

                    b.HasIndex("CreditorId");

                    b.ToTable("CreditApplications", (string)null);
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.Creditor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Inn")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Inn")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Creditors", (string)null);
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.CreditType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CreditTypes", (string)null);
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.PassportIssuer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("PassportIssuers", (string)null);
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.Payment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreditId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Debt")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PaymentAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RemainingAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreditId");

                    b.ToTable("Payments", (string)null);

                    b.HasCheckConstraint("Debt", "Debt <= RemainingAmount");
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.Request", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BorrowerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RequestDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RequesterId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BorrowerId");

                    b.HasIndex("RequesterId");

                    b.ToTable("Requests", (string)null);
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.Requester", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Inn")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Inn")
                        .IsUnique();

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Requesters", (string)null);
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.User.AppUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessLevel")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("JobTitleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobTitleId");

                    b.ToTable("AppUsers", (string)null);

                    b.HasCheckConstraint("AccessLevel", "AccessLevel >= 1 and AccessLevel <= 3");
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.User.JobTitle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("JobTitles", (string)null);
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.Borrower", b =>
                {
                    b.HasOne("lab_dotnet.entity.Models.CreditHistory.PassportIssuer", "PassportIssuer")
                        .WithMany("Borrowers")
                        .HasForeignKey("PassportIssuerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("PassportIssuer");
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.Contribution", b =>
                {
                    b.HasOne("lab_dotnet.entity.Models.CreditHistory.Borrower", "Borrower")
                        .WithMany("Contributions")
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("lab_dotnet.entity.Models.CreditHistory.Contributor", "Contributor")
                        .WithMany("Contributions")
                        .HasForeignKey("ContributorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Borrower");

                    b.Navigation("Contributor");
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.Credit", b =>
                {
                    b.HasOne("lab_dotnet.entity.Models.CreditHistory.CreditApplication", "CreditApplication")
                        .WithOne("Credit")
                        .HasForeignKey("lab_dotnet.entity.Models.CreditHistory.Credit", "CreditApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreditApplication");
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.CreditApplication", b =>
                {
                    b.HasOne("lab_dotnet.entity.Models.CreditHistory.Borrower", "Borrower")
                        .WithMany("CreditApplications")
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("lab_dotnet.entity.Models.CreditHistory.CreditType", "CreditType")
                        .WithMany("CreditApplications")
                        .HasForeignKey("CreditTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("lab_dotnet.entity.Models.CreditHistory.Creditor", "Creditor")
                        .WithMany("CreditApplications")
                        .HasForeignKey("CreditorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Borrower");

                    b.Navigation("CreditType");

                    b.Navigation("Creditor");
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.Payment", b =>
                {
                    b.HasOne("lab_dotnet.entity.Models.CreditHistory.Credit", "Credit")
                        .WithMany("Payments")
                        .HasForeignKey("CreditId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Credit");
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.Request", b =>
                {
                    b.HasOne("lab_dotnet.entity.Models.CreditHistory.Borrower", "Borrower")
                        .WithMany("Requests")
                        .HasForeignKey("BorrowerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("lab_dotnet.entity.Models.CreditHistory.Requester", "Requester")
                        .WithMany("Requests")
                        .HasForeignKey("RequesterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Borrower");

                    b.Navigation("Requester");
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.User.AppUser", b =>
                {
                    b.HasOne("lab_dotnet.entity.Models.User.JobTitle", "JobTitle")
                        .WithMany("AppUsers")
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("JobTitle");
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.Borrower", b =>
                {
                    b.Navigation("Contributions");

                    b.Navigation("CreditApplications");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.Contributor", b =>
                {
                    b.Navigation("Contributions");
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.Credit", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.CreditApplication", b =>
                {
                    b.Navigation("Credit")
                        .IsRequired();
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.Creditor", b =>
                {
                    b.Navigation("CreditApplications");
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.CreditType", b =>
                {
                    b.Navigation("CreditApplications");
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.PassportIssuer", b =>
                {
                    b.Navigation("Borrowers");
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.CreditHistory.Requester", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("lab_dotnet.entity.Models.User.JobTitle", b =>
                {
                    b.Navigation("AppUsers");
                });
#pragma warning restore 612, 618
        }
    }
}

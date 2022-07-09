﻿// <auto-generated />
using System;
using Mabill.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Mabill.Data.Migrations
{
    [DbContext(typeof(MabillDbContext))]
    partial class MabillDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Mabill.Domain.Entities.Journals.Journal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModificatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(24)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.ToTable("Journals");
                });

            modelBuilder.Entity("Mabill.Domain.Entities.Loanees.Loanee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AddedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime?>("BrithDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("JournalId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("LastModificatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(24)");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("JournalId");

                    b.ToTable("Loanees");
                });

            modelBuilder.Entity("Mabill.Domain.Entities.LoaneesBalancesInJournals.LoaneeBalanceInJournal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric");

                    b.Property<Guid>("JournalId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("LoaneeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("JournalId");

                    b.HasIndex("LoaneeId");

                    b.HasIndex("UserId");

                    b.ToTable("LoaneesBalanceInJournals");
                });

            modelBuilder.Entity("Mabill.Domain.Entities.Loans.Loan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CurrencyType")
                        .HasColumnType("varchar(24)");

                    b.Property<string>("CustomCurrencyType")
                        .HasColumnType("text");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<Guid>("GivenById")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("boolean");

                    b.Property<Guid>("JournalId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("LastModificatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("LoaneeId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(24)");

                    b.Property<Guid?>("TakenById")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GivenById");

                    b.HasIndex("JournalId");

                    b.HasIndex("LoaneeId");

                    b.HasIndex("TakenById");

                    b.HasIndex("UserId");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Mabill.Domain.Entities.Organizations.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModificatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(24)");

                    b.Property<decimal>("SumOfGivenLoans")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("Mabill.Domain.Entities.StaffsInOrganizations.StaffInOrganization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrganizationId")
                        .HasColumnType("uuid");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("varchar(24)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("UserId");

                    b.ToTable("StaffsInOrganizations");
                });

            modelBuilder.Entity("Mabill.Domain.Entities.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime?>("BrithDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid?>("DeletedBy")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("LastModificatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uuid");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("varchar(24)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Mabill.Domain.Entities.Journals.Journal", b =>
                {
                    b.HasOne("Mabill.Domain.Entities.Organizations.Organization", "Organization")
                        .WithMany("Journals")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");
                });

            modelBuilder.Entity("Mabill.Domain.Entities.Loanees.Loanee", b =>
                {
                    b.HasOne("Mabill.Domain.Entities.Users.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mabill.Domain.Entities.Journals.Journal", null)
                        .WithMany("Loanees")
                        .HasForeignKey("JournalId");

                    b.Navigation("AddedBy");
                });

            modelBuilder.Entity("Mabill.Domain.Entities.LoaneesBalancesInJournals.LoaneeBalanceInJournal", b =>
                {
                    b.HasOne("Mabill.Domain.Entities.Journals.Journal", "Journal")
                        .WithMany("LoaneesBalance")
                        .HasForeignKey("JournalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mabill.Domain.Entities.Loanees.Loanee", "Loanee")
                        .WithMany("BalanceInJournals")
                        .HasForeignKey("LoaneeId");

                    b.HasOne("Mabill.Domain.Entities.Users.User", "User")
                        .WithMany("BalanceInJournals")
                        .HasForeignKey("UserId");

                    b.Navigation("Journal");

                    b.Navigation("Loanee");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mabill.Domain.Entities.Loans.Loan", b =>
                {
                    b.HasOne("Mabill.Domain.Entities.Users.User", "GivenBy")
                        .WithMany()
                        .HasForeignKey("GivenById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mabill.Domain.Entities.Journals.Journal", "Journal")
                        .WithMany("Loans")
                        .HasForeignKey("JournalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mabill.Domain.Entities.Loanees.Loanee", "Loanee")
                        .WithMany("Loans")
                        .HasForeignKey("LoaneeId");

                    b.HasOne("Mabill.Domain.Entities.Users.User", "TakeBy")
                        .WithMany()
                        .HasForeignKey("TakenById");

                    b.HasOne("Mabill.Domain.Entities.Users.User", "User")
                        .WithMany("Loans")
                        .HasForeignKey("UserId");

                    b.Navigation("GivenBy");

                    b.Navigation("Journal");

                    b.Navigation("Loanee");

                    b.Navigation("TakeBy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mabill.Domain.Entities.StaffsInOrganizations.StaffInOrganization", b =>
                {
                    b.HasOne("Mabill.Domain.Entities.Organizations.Organization", "Organization")
                        .WithMany("Staffs")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mabill.Domain.Entities.Users.User", "User")
                        .WithMany("Occupations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Mabill.Domain.Entities.Journals.Journal", b =>
                {
                    b.Navigation("Loanees");

                    b.Navigation("LoaneesBalance");

                    b.Navigation("Loans");
                });

            modelBuilder.Entity("Mabill.Domain.Entities.Loanees.Loanee", b =>
                {
                    b.Navigation("BalanceInJournals");

                    b.Navigation("Loans");
                });

            modelBuilder.Entity("Mabill.Domain.Entities.Organizations.Organization", b =>
                {
                    b.Navigation("Journals");

                    b.Navigation("Staffs");
                });

            modelBuilder.Entity("Mabill.Domain.Entities.Users.User", b =>
                {
                    b.Navigation("BalanceInJournals");

                    b.Navigation("Loans");

                    b.Navigation("Occupations");
                });
#pragma warning restore 612, 618
        }
    }
}

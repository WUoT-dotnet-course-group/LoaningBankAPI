﻿// <auto-generated />
using System;
using LoaningBank.DataPersistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LoaningBank.DataPersistence.Migrations
{
    [DbContext(typeof(RepositoryDbContext))]
    [Migration("20230112181044_AlterOfferDocumentLinkColumn")]
    partial class AlterOfferDocumentLinkColumn
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LoaningBank.Domain.Entities.Inquiry", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("InquireDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<int>("LoanValue")
                        .HasColumnType("int");

                    b.Property<short>("NumberOfInstallments")
                        .HasColumnType("smallint");

                    b.HasKey("ID");

                    b.ToTable("Inquiries");
                });

            modelBuilder.Entity("LoaningBank.Domain.Entities.Offer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApprovedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<Guid>("DocumentKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("newid()");

                    b.Property<DateTime>("DocumentLinkValidDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("InquiryID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("LoanPeriod")
                        .HasColumnType("smallint");

                    b.Property<int>("LoanValue")
                        .HasColumnType("int");

                    b.Property<float>("MonthlyInstallment")
                        .HasColumnType("real");

                    b.Property<float>("Percentage")
                        .HasColumnType("real");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("InquiryID")
                        .IsUnique();

                    b.ToTable("Offers");
                });

            modelBuilder.Entity("LoaningBank.Domain.Entities.Inquiry", b =>
                {
                    b.OwnsOne("LoaningBank.Domain.Entities.PersonalData", "PersonalData", b1 =>
                        {
                            b1.Property<Guid>("InquiryID")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTime>("BirthDate")
                                .HasColumnType("datetime2")
                                .HasColumnName("Debtor_BirthDate");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Debtor_FirstName");

                            b1.Property<string>("GovernmentId")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Debtor_GovernmentId");

                            b1.Property<int>("GovernmentIdType")
                                .HasColumnType("int")
                                .HasColumnName("Debtor_GovernmentIdType");

                            b1.Property<DateTime?>("JobEndDate")
                                .HasColumnType("datetime2")
                                .HasColumnName("Debtor_JobEndDate");

                            b1.Property<DateTime>("JobStartDate")
                                .HasColumnType("datetime2")
                                .HasColumnName("Debtor_JobStartDate");

                            b1.Property<int>("JobType")
                                .HasColumnType("int")
                                .HasColumnName("Debtor_JobType");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Debtor_LastName");

                            b1.HasKey("InquiryID");

                            b1.ToTable("Inquiries");

                            b1.WithOwner()
                                .HasForeignKey("InquiryID");
                        });

                    b.Navigation("PersonalData")
                        .IsRequired();
                });

            modelBuilder.Entity("LoaningBank.Domain.Entities.Offer", b =>
                {
                    b.HasOne("LoaningBank.Domain.Entities.Inquiry", "Inquiry")
                        .WithOne("Offer")
                        .HasForeignKey("LoaningBank.Domain.Entities.Offer", "InquiryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inquiry");
                });

            modelBuilder.Entity("LoaningBank.Domain.Entities.Inquiry", b =>
                {
                    b.Navigation("Offer");
                });
#pragma warning restore 612, 618
        }
    }
}

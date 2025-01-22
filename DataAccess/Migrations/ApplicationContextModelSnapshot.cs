﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductionStructure.DataAccess.Context;

#nullable disable

namespace ProductionStructure.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.27");

            modelBuilder.Entity("ProductionStructure.Domain.Entity.ConfigurationData.Area", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("SiteId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("Areas", (string)null);
                });

            modelBuilder.Entity("ProductionStructure.Domain.Entity.ConfigurationData.Site", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sites", (string)null);
                });

            modelBuilder.Entity("ProductionStructure.Domain.Entity.ConfigurationData.Unit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CurrentWorkSessionId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("WorkCenterId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CurrentWorkSessionId")
                        .IsUnique();

                    b.HasIndex("WorkCenterId");

                    b.ToTable("Units", (string)null);
                });

            modelBuilder.Entity("ProductionStructure.Domain.Entity.ConfigurationData.WorkCenter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AreaId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("WorkMode")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.ToTable("Work Centers", (string)null);
                });

            modelBuilder.Entity("ProductionStructure.Domain.Entity.HistoricalData.WorkSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("UnitId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UnitId");

                    b.ToTable("Work Sessions", (string)null);
                });

            modelBuilder.Entity("ProductionStructure.Domain.Entity.ConfigurationData.Area", b =>
                {
                    b.HasOne("ProductionStructure.Domain.Entity.ConfigurationData.Site", "Site")
                        .WithMany("Areas")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");
                });

            modelBuilder.Entity("ProductionStructure.Domain.Entity.ConfigurationData.Site", b =>
                {
                    b.OwnsOne("ProductionStructure.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("SiteId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Server")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Username")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("SiteId");

                            b1.ToTable("Sites");

                            b1.WithOwner()
                                .HasForeignKey("SiteId");
                        });

                    b.OwnsOne("ProductionStructure.Domain.ValueObjects.Location", "Location", b1 =>
                        {
                            b1.Property<Guid>("SiteId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("Address");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT")
                                .HasColumnName("City");

                            b1.HasKey("SiteId");

                            b1.ToTable("Sites");

                            b1.WithOwner()
                                .HasForeignKey("SiteId");

                            b1.OwnsOne("CountryData.Standard.Country", "Country", b2 =>
                                {
                                    b2.Property<Guid>("LocationSiteId")
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("CountryName")
                                        .HasColumnType("TEXT")
                                        .HasColumnName("Country Name");

                                    b2.Property<string>("CountryShortCode")
                                        .HasColumnType("TEXT")
                                        .HasColumnName("Short Code");

                                    b2.Property<string>("PhoneCode")
                                        .HasColumnType("TEXT")
                                        .HasColumnName("Phone Code");

                                    b2.HasKey("LocationSiteId");

                                    b2.ToTable("Sites");

                                    b2.WithOwner()
                                        .HasForeignKey("LocationSiteId");
                                });

                            b1.Navigation("Country")
                                .IsRequired();
                        });

                    b.OwnsOne("ProductionStructure.Domain.ValueObjects.PhoneNumber", "PhoneNumber", b1 =>
                        {
                            b1.Property<Guid>("SiteId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Phone")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("SiteId");

                            b1.ToTable("Sites");

                            b1.WithOwner()
                                .HasForeignKey("SiteId");
                        });

                    b.Navigation("Email");

                    b.Navigation("Location")
                        .IsRequired();

                    b.Navigation("PhoneNumber");
                });

            modelBuilder.Entity("ProductionStructure.Domain.Entity.ConfigurationData.Unit", b =>
                {
                    b.HasOne("ProductionStructure.Domain.Entity.HistoricalData.WorkSession", "CurrentWorkSession")
                        .WithOne()
                        .HasForeignKey("ProductionStructure.Domain.Entity.ConfigurationData.Unit", "CurrentWorkSessionId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("ProductionStructure.Domain.Entity.ConfigurationData.WorkCenter", "WorkCenter")
                        .WithMany("Units")
                        .HasForeignKey("WorkCenterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CurrentWorkSession");

                    b.Navigation("WorkCenter");
                });

            modelBuilder.Entity("ProductionStructure.Domain.Entity.ConfigurationData.WorkCenter", b =>
                {
                    b.HasOne("ProductionStructure.Domain.Entity.ConfigurationData.Area", "Area")
                        .WithMany("WorkCenters")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Area");
                });

            modelBuilder.Entity("ProductionStructure.Domain.Entity.HistoricalData.WorkSession", b =>
                {
                    b.HasOne("ProductionStructure.Domain.Entity.ConfigurationData.Unit", "Unit")
                        .WithMany("WorkSessions")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("ProductionStructure.Domain.Entity.ConfigurationData.Area", b =>
                {
                    b.Navigation("WorkCenters");
                });

            modelBuilder.Entity("ProductionStructure.Domain.Entity.ConfigurationData.Site", b =>
                {
                    b.Navigation("Areas");
                });

            modelBuilder.Entity("ProductionStructure.Domain.Entity.ConfigurationData.Unit", b =>
                {
                    b.Navigation("WorkSessions");
                });

            modelBuilder.Entity("ProductionStructure.Domain.Entity.ConfigurationData.WorkCenter", b =>
                {
                    b.Navigation("Units");
                });
#pragma warning restore 612, 618
        }
    }
}

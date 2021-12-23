﻿// <auto-generated />
using System;
using EntityFrameworkCoreDemo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EntityFrameworkCoreDemo.Migrations
{
    [DbContext(typeof(DemoDbContext))]
    [Migration("20211223052645_RemoveAddressProvinceRequired")]
    partial class RemoveAddressProvinceRequired
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EntityFrameworkCoreDemo.Relational.Schedule", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Day")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("EntityFrameworkCoreDemo.Relational.ScheduleParticipant", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ParticipantID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParticipantType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScheduleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ScheduleId");

                    b.ToTable("ScheduleParticipant");
                });

            modelBuilder.Entity("EntityFrameworkCoreDemo.ValueConversions.People", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("ContactNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ContactType")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Peoples");
                });

            modelBuilder.Entity("EntityFrameworkCoreDemo.ValueObject.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EntityFrameworkCoreDemo.Relational.ScheduleParticipant", b =>
                {
                    b.HasOne("EntityFrameworkCoreDemo.Relational.Schedule", "Schedule")
                        .WithMany("Participants")
                        .HasForeignKey("ScheduleId");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("EntityFrameworkCoreDemo.ValueObject.Order", b =>
                {
                    b.OwnsOne("EntityFrameworkCoreDemo.ValueObject.Address", "Address", b1 =>
                        {
                            b1.Property<string>("OrderId")
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("County")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Detail")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Province")
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)");

                            b1.Property<string>("Street")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ZipCode")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.OwnsMany("EntityFrameworkCoreDemo.ValueObject.OrderItem", "Items", b1 =>
                        {
                            b1.Property<int>("id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("id"), 1L, 1);

                            b1.Property<decimal>("Price")
                                .HasColumnType("decimal(18,4)");

                            b1.Property<string>("ProduceId")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ProduceName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("orderId")
                                .IsRequired()
                                .HasColumnType("nvarchar(50)");

                            b1.HasKey("id");

                            b1.HasIndex("orderId");

                            b1.ToTable("OrderItem");

                            b1.WithOwner()
                                .HasForeignKey("orderId");
                        });

                    b.Navigation("Address");

                    b.Navigation("Items");
                });

            modelBuilder.Entity("EntityFrameworkCoreDemo.Relational.Schedule", b =>
                {
                    b.Navigation("Participants");
                });
#pragma warning restore 612, 618
        }
    }
}

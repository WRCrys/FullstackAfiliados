﻿// <auto-generated />
using System;
using FullstackAfiliados.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FullstackAfiliados.Data.Migrations
{
    [DbContext(typeof(FullstackAfiliadosDbContext))]
    [Migration("20230822133824_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FullstackAfiliados.Business.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ProcessedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Product")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Seller")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Transaction", (string)null);
                });

            modelBuilder.Entity("FullstackAfiliados.Business.Models.TransactionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Nature")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Sinal")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("TransactionType", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 8, 22, 10, 38, 24, 801, DateTimeKind.Local).AddTicks(7417),
                            Description = "Venda produtor",
                            Nature = "Entrada",
                            Sinal = "+"
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 8, 22, 10, 38, 24, 801, DateTimeKind.Local).AddTicks(7434),
                            Description = "Venda afiliado",
                            Nature = "Entrada",
                            Sinal = "+"
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 8, 22, 10, 38, 24, 801, DateTimeKind.Local).AddTicks(7435),
                            Description = "Comissão paga",
                            Nature = "Saída",
                            Sinal = "-"
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 8, 22, 10, 38, 24, 801, DateTimeKind.Local).AddTicks(7436),
                            Description = "Comissão recebida",
                            Nature = "Entrada",
                            Sinal = "+"
                        });
                });

            modelBuilder.Entity("FullstackAfiliados.Business.Models.Transaction", b =>
                {
                    b.HasOne("FullstackAfiliados.Business.Models.TransactionType", "TransactionType")
                        .WithMany("Transactions")
                        .HasForeignKey("TransactionTypeId")
                        .IsRequired();

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("FullstackAfiliados.Business.Models.TransactionType", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}

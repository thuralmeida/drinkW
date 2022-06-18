﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using drinkW.Models;

#nullable disable

namespace drinkW.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220618172351_Nova-Tabela-Consumo")]
    partial class NovaTabelaConsumo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("drinkW.Models.Consumo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DataConsumo")
                        .HasColumnType("datetime2")
                        .HasColumnName("Data");

                    b.Property<string>("RecipienteConsumo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Recipiente");

                    b.Property<string>("TamanhoConsumo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Tamanho");

                    b.HasKey("Id");

                    b.ToTable("tblConsumo");
                });

            modelBuilder.Entity("drinkW.Models.Recipiente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Foto");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<string>("Tamanho")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Tamanho");

                    b.HasKey("Id");

                    b.ToTable("tblRecipiente");
                });
#pragma warning restore 612, 618
        }
    }
}

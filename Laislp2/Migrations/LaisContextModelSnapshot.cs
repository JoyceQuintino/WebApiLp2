﻿// <auto-generated />
using Laislp2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Laislp2.Migrations
{
    [DbContext(typeof(LaisContext))]
    partial class LaisContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("Laislp2.Models.Consulta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Gravidez");

                    b.Property<string>("TempoGestacao");

                    b.Property<string>("TipoParto");

                    b.HasKey("Id");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("Laislp2.Models.Crianca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apgar1");

                    b.Property<string>("Apgar2");

                    b.Property<int>("IdMae");

                    b.Property<int>("IdParto");

                    b.Property<double>("Peso");

                    b.Property<string>("Sexo");

                    b.HasKey("Id");

                    b.ToTable("Criancas");
                });

            modelBuilder.Entity("Laislp2.Models.Mae", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EstadoCivil");

                    b.Property<int>("IdadeMae");

                    b.Property<string>("Nome");

                    b.Property<int>("QuantFilhosMortos");

                    b.Property<int>("QuantFilhosVivos");

                    b.Property<string>("escolaridade");

                    b.HasKey("Id");

                    b.ToTable("Maes");
                });

            modelBuilder.Entity("Laislp2.Models.MaeConsulta", b =>
                {
                    b.Property<int>("IdMae");

                    b.Property<int>("IdConsulta");

                    b.Property<int>("Id");

                    b.HasKey("IdMae", "IdConsulta");

                    b.ToTable("MaeConcultas");
                });

            modelBuilder.Entity("Laislp2.Models.Parto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Horario");

                    b.Property<int>("IdMae");

                    b.Property<string>("LocalNasci");

                    b.HasKey("Id");

                    b.ToTable("Partos");
                });
#pragma warning restore 612, 618
        }
    }
}

﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projectEF;

#nullable disable

namespace projectEF.Migrations
{
    [DbContext(typeof(TareasContext))]
    [Migration("20241219044703_InitialData")]
    partial class InitialData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("projectEF.Models.Categoria", b =>
                {
                    b.Property<Guid>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Peso")
                        .HasColumnType("int");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categoria", (string)null);

                    b.HasData(
                        new
                        {
                            CategoriaId = new Guid("f36c7b0b-bdcf-4c76-8d18-a426c57fc477"),
                            Descripcion = "Descripción de la categoría act pendientes",
                            Nombre = "Actividades pendientes",
                            Peso = 20
                        },
                        new
                        {
                            CategoriaId = new Guid("f36c7b0b-bdcf-4c76-8d18-a426c57fc402"),
                            Descripcion = "Descripción de la categoría act personales",
                            Nombre = "Actividades personales",
                            Peso = 20
                        });
                });

            modelBuilder.Entity("projectEF.Models.Tarea", b =>
                {
                    b.Property<Guid>("TareaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoriaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("PrioridadTarea")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TareaId");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Tarea", (string)null);

                    b.HasData(
                        new
                        {
                            TareaId = new Guid("f36c7b0b-bdcf-4c76-8d18-a426c57fc413"),
                            CategoriaId = new Guid("f36c7b0b-bdcf-4c76-8d18-a426c57fc477"),
                            Descripcion = "Descripción del pago",
                            FechaCreacion = new DateTime(2024, 12, 18, 23, 47, 2, 856, DateTimeKind.Local).AddTicks(1135),
                            PrioridadTarea = 2,
                            Titulo = "Revisar pago de servicios publicos"
                        },
                        new
                        {
                            TareaId = new Guid("f36c7b0b-bdcf-4c76-8d18-a426c57fc412"),
                            CategoriaId = new Guid("f36c7b0b-bdcf-4c76-8d18-a426c57fc402"),
                            Descripcion = "Descripción de la compra",
                            FechaCreacion = new DateTime(2024, 12, 18, 23, 47, 2, 857, DateTimeKind.Local).AddTicks(2093),
                            PrioridadTarea = 1,
                            Titulo = "Comprar regalo de cumpleaños"
                        });
                });

            modelBuilder.Entity("projectEF.Models.Tarea", b =>
                {
                    b.HasOne("projectEF.Models.Categoria", "Categoria")
                        .WithMany("Tareas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("projectEF.Models.Categoria", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}

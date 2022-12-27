﻿// <auto-generated />
using EVO_WebAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EVOWebAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("EVO_WebAPI.Controllers.Departamento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("sigla")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Departamentos");

                    b.HasData(
                        new
                        {
                            id = 1,
                            nome = "Informática",
                            sigla = "TI"
                        },
                        new
                        {
                            id = 2,
                            nome = "Segurança",
                            sigla = "SEG"
                        },
                        new
                        {
                            id = 3,
                            nome = "Recursos Humanos",
                            sigla = "RH"
                        },
                        new
                        {
                            id = 4,
                            nome = "Marketing",
                            sigla = "MK"
                        },
                        new
                        {
                            id = 5,
                            nome = "Administrativo",
                            sigla = "ADM"
                        });
                });

            modelBuilder.Entity("EVO_WebAPI.Controllers.Funcionario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Departamentoid")
                        .HasColumnType("INTEGER");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("rg")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("Departamentoid");

                    b.ToTable("Funcionarios");

                    b.HasData(
                        new
                        {
                            id = 1,
                            Departamentoid = 2,
                            nome = "Marta Kent",
                            rg = 33225555
                        },
                        new
                        {
                            id = 2,
                            Departamentoid = 1,
                            nome = "Paula Isabela",
                            rg = 3354288
                        },
                        new
                        {
                            id = 3,
                            Departamentoid = 3,
                            nome = "Laura Antonia",
                            rg = 566889
                        },
                        new
                        {
                            id = 4,
                            Departamentoid = 4,
                            nome = "Luiza Maria",
                            rg = 656559
                        },
                        new
                        {
                            id = 5,
                            Departamentoid = 5,
                            nome = "Lucas Machado",
                            rg = 6568541
                        },
                        new
                        {
                            id = 6,
                            Departamentoid = 2,
                            nome = "Pedro Alvares",
                            rg = 45645445
                        },
                        new
                        {
                            id = 7,
                            Departamentoid = 4,
                            nome = "Paulo José",
                            rg = 9874512
                        });
                });

            modelBuilder.Entity("EVO_WebAPI.Controllers.Funcionario", b =>
                {
                    b.HasOne("EVO_WebAPI.Controllers.Departamento", "Departamento")
                        .WithMany()
                        .HasForeignKey("Departamentoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departamento");
                });
#pragma warning restore 612, 618
        }
    }
}

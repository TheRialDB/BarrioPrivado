﻿// <auto-generated />
using BarrioPrivado.BD.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BarrioPrivado.BD.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BarrioPrivado.BD.Data.Entity.Domicilio", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("ResidenteId")
                        .HasColumnType("int");

                    b.Property<int>("lote")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<int>("manzana")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ResidenteId");

                    b.ToTable("Domicilios");
                });

            modelBuilder.Entity("BarrioPrivado.BD.Data.Entity.Residente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("DNI")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.HasIndex(new[] { "DNI" }, "Residente_DNI_UQ")
                        .IsUnique();

                    b.ToTable("Residentes");
                });

            modelBuilder.Entity("BarrioPrivado.BD.Data.Entity.Visitante", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("DNI")
                        .HasMaxLength(10)
                        .HasColumnType("int");

                    b.Property<int>("ResidenteId")
                        .HasColumnType("int");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.HasIndex("ResidenteId");

                    b.HasIndex(new[] { "DNI" }, "Visitante_DNI_UQ")
                        .IsUnique();

                    b.ToTable("Visitantes");
                });

            modelBuilder.Entity("BarrioPrivado.BD.Data.Entity.Domicilio", b =>
                {
                    b.HasOne("BarrioPrivado.BD.Data.Entity.Residente", "Residente")
                        .WithMany()
                        .HasForeignKey("ResidenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Residente");
                });

            modelBuilder.Entity("BarrioPrivado.BD.Data.Entity.Visitante", b =>
                {
                    b.HasOne("BarrioPrivado.BD.Data.Entity.Residente", "Residente")
                        .WithMany("Visitantes")
                        .HasForeignKey("ResidenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Residente");
                });

            modelBuilder.Entity("BarrioPrivado.BD.Data.Entity.Residente", b =>
                {
                    b.Navigation("Visitantes");
                });
#pragma warning restore 612, 618
        }
    }
}

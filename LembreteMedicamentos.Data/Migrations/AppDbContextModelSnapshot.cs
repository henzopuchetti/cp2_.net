
using System;
using LembreteMedicamentos.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace LembreteMedicamentos.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LembreteMedicamentos.Domain.Entities.Idoso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Idade")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Idosos");
                });

            modelBuilder.Entity("LembreteMedicamentos.Domain.Entities.Lembrete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Horario")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("IdosoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("MedicamentoId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.HasIndex("IdosoId");

                    b.HasIndex("MedicamentoId");

                    b.ToTable("Lembretes");
                });

            modelBuilder.Entity("LembreteMedicamentos.Domain.Entities.Medicamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Dosagem")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("Id");

                    b.ToTable("Medicamentos");
                });

            modelBuilder.Entity("LembreteMedicamentos.Domain.Entities.Lembrete", b =>
                {
                    b.HasOne("LembreteMedicamentos.Domain.Entities.Idoso", "Idoso")
                        .WithMany("Lembretes")
                        .HasForeignKey("IdosoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LembreteMedicamentos.Domain.Entities.Medicamento", "Medicamento")
                        .WithMany()
                        .HasForeignKey("MedicamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Idoso");

                    b.Navigation("Medicamento");
                });

            modelBuilder.Entity("LembreteMedicamentos.Domain.Entities.Idoso", b =>
                {
                    b.Navigation("Lembretes");
                });
#pragma warning restore 612, 618
        }
    }
}

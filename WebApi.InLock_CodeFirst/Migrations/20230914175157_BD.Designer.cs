﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.InLock_CodeFirst.Contexts;

#nullable disable

namespace WebApi.InLock_CodeFirst.Migrations
{
    [DbContext(typeof(InLockContext))]
    [Migration("20230914175157_BD")]
    partial class BD
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApi.InLock_CodeFirst.Domains.Estudio", b =>
                {
                    b.Property<Guid>("IdEstudio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdEstudio");

                    b.ToTable("Estudio");
                });

            modelBuilder.Entity("WebApi.InLock_CodeFirst.Domains.Jogo", b =>
                {
                    b.Property<Guid>("IdJogo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataLancamento")
                        .HasColumnType("DATE");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("IdEstudio")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("DECIMAL(4,2)");

                    b.HasKey("IdJogo");

                    b.HasIndex("IdEstudio");

                    b.ToTable("Jogo");
                });

            modelBuilder.Entity("WebApi.InLock_CodeFirst.Domains.TiposUsuario", b =>
                {
                    b.Property<Guid>("IdTipoUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.HasKey("IdTipoUsuario");

                    b.ToTable("TiposUsuario");
                });

            modelBuilder.Entity("WebApi.InLock_CodeFirst.Domains.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(100)");

                    b.Property<Guid>("IdTipoUsuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR(60)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("IdTipoUsuario");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("WebApi.InLock_CodeFirst.Domains.Jogo", b =>
                {
                    b.HasOne("WebApi.InLock_CodeFirst.Domains.Estudio", "Estudio")
                        .WithMany("Jogo")
                        .HasForeignKey("IdEstudio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estudio");
                });

            modelBuilder.Entity("WebApi.InLock_CodeFirst.Domains.Usuario", b =>
                {
                    b.HasOne("WebApi.InLock_CodeFirst.Domains.TiposUsuario", "TipoUsuario")
                        .WithMany()
                        .HasForeignKey("IdTipoUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoUsuario");
                });

            modelBuilder.Entity("WebApi.InLock_CodeFirst.Domains.Estudio", b =>
                {
                    b.Navigation("Jogo");
                });
#pragma warning restore 612, 618
        }
    }
}
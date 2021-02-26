﻿// <auto-generated />
using System;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ContextBase))]
    [Migration("20210225201114_Initial_Base")]
    partial class Initial_Base
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entities.Entities.Conta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataPagamento")
                        .HasColumnName("DataPagamento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataVencimento")
                        .HasColumnName("DataVencimento")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Juros")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Multa")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("QuantidadeDiasAtraso")
                        .HasColumnName("QuantidadeDiasAtraso")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorCorrigido")
                        .HasColumnName("ValorCorrigido")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ValorOriginal")
                        .HasColumnName("ValorOriginal")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("tblConta");
                });
#pragma warning restore 612, 618
        }
    }
}

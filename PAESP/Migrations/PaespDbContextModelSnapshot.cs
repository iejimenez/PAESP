﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PAESP.Datos;

namespace PAESP.Migrations
{
    [DbContext(typeof(PaespDbContext))]
    partial class PaespDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PAESP.Models.Aula", b =>
                {
                    b.Property<int>("IdAula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bloque")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CodigoAula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<string>("NombreAula")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdAula");

                    b.ToTable("Aula");
                });

            modelBuilder.Entity("PAESP.Models.Concepto", b =>
                {
                    b.Property<int>("IdConcepto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoConcepto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("TipoConcepto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdConcepto");

                    b.ToTable("Conceptos");
                });

            modelBuilder.Entity("PAESP.Models.Configuraciones", b =>
                {
                    b.Property<int>("IdConfig")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Valor")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdConfig");

                    b.ToTable("configuraciones");
                });

            modelBuilder.Entity("PAESP.Models.Estado", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreEstado")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdEstado");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("PAESP.Models.Estudiante", b =>
                {
                    b.Property<int>("IdEstudiante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FEchaInscripcion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdEstudiante");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Estudiantes");
                });

            modelBuilder.Entity("PAESP.Models.Grupo", b =>
                {
                    b.Property<int>("IdGrupo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cupo")
                        .HasColumnType("int");

                    b.Property<int>("IdMateria")
                        .HasColumnType("int");

                    b.Property<int>("IdProfesor")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdGrupo");

                    b.HasIndex("IdMateria");

                    b.HasIndex("IdProfesor");

                    b.ToTable("Grupo");
                });

            modelBuilder.Entity("PAESP.Models.GrupoAula", b =>
                {
                    b.Property<int>("IdGrupoaula")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Dia")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("HoraFin")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HoraInicio")
                        .HasColumnType("time");

                    b.Property<int>("IdAula")
                        .HasColumnType("int");

                    b.Property<int>("IdGrupo")
                        .HasColumnType("int");

                    b.HasKey("IdGrupoaula");

                    b.HasIndex("IdAula");

                    b.HasIndex("IdGrupo");

                    b.ToTable("GrupoAula");
                });

            modelBuilder.Entity("PAESP.Models.GrupoEstudiante", b =>
                {
                    b.Property<int>("IdGrupoEstudiante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("EstudianteIdEstudiante")
                        .HasColumnType("int");

                    b.Property<int>("EstudianteIdEstudiante1")
                        .HasColumnType("int");

                    b.Property<int>("GrupoIdGrupo")
                        .HasColumnType("int");

                    b.Property<int>("GrupoIdGrupo1")
                        .HasColumnType("int");

                    b.Property<int>("IdEstudiante")
                        .HasColumnType("int");

                    b.Property<int>("IdGrupo")
                        .HasColumnType("int");

                    b.Property<double>("PrimerCorte")
                        .HasColumnType("float");

                    b.Property<double>("SegundoCorte")
                        .HasColumnType("float");

                    b.Property<double>("TercerCorte")
                        .HasColumnType("float");

                    b.HasKey("IdGrupoEstudiante");

                    b.HasIndex("EstudianteIdEstudiante");

                    b.HasIndex("GrupoIdGrupo");

                    b.HasIndex("IdEstudiante");

                    b.HasIndex("IdGrupo");

                    b.ToTable("GrupoEstudiante");
                });

            modelBuilder.Entity("PAESP.Models.Materia", b =>
                {
                    b.Property<int>("IdMateria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Creditos")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMateria");

                    b.ToTable("Materia");
                });

            modelBuilder.Entity("PAESP.Models.Preinscripcion", b =>
                {
                    b.Property<string>("IdPresinscripcion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("FechaDePreInscripcion")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.Property<string>("NumeroRecibo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonaIdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdPresinscripcion");

                    b.HasIndex("PersonaIdUsuario");

                    b.ToTable("Preinscripcions");
                });

            modelBuilder.Entity("PAESP.Models.Profesor", b =>
                {
                    b.Property<int>("IdProfesor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdProfesor");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Profesor");
                });

            modelBuilder.Entity("PAESP.Models.Programa", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("EstudianteIdEstudiante")
                        .HasColumnType("int");

                    b.Property<string>("NombrePograma")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Semestres")
                        .HasColumnType("int");

                    b.HasKey("Codigo");

                    b.HasIndex("EstudianteIdEstudiante");

                    b.ToTable("Programa");
                });

            modelBuilder.Entity("PAESP.Models.ProgramaMateria", b =>
                {
                    b.Property<int>("IdProgramaMateria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoPrograma")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<int>("IdMateria")
                        .HasColumnType("int");

                    b.HasKey("IdProgramaMateria");

                    b.HasIndex("CodigoPrograma");

                    b.HasIndex("IdMateria");

                    b.ToTable("ProgramaMateria");
                });

            modelBuilder.Entity("PAESP.Models.Recibo", b =>
                {
                    b.Property<int>("IdRecibo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ConceptoIdConcepto")
                        .HasColumnType("int");

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaReg")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdConcepto")
                        .HasColumnType("int");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NroRecibo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("IdRecibo");

                    b.HasIndex("ConceptoIdConcepto");

                    b.ToTable("Recibos");
                });

            modelBuilder.Entity("PAESP.Models.TipoIdentificacion", b =>
                {
                    b.Property<int>("IdTipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abreviatura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdTipo");

                    b.ToTable("TipoIdentificacions");
                });

            modelBuilder.Entity("PAESP.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apeliidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cedula")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contraseña")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TipodeIdentificacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("PAESP.Models.Estudiante", b =>
                {
                    b.HasOne("PAESP.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PAESP.Models.Grupo", b =>
                {
                    b.HasOne("PAESP.Models.Materia", "Materia")
                        .WithMany()
                        .HasForeignKey("IdMateria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PAESP.Models.Profesor", "Profesor")
                        .WithMany("Grupos")
                        .HasForeignKey("IdProfesor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Materia");

                    b.Navigation("Profesor");
                });

            modelBuilder.Entity("PAESP.Models.GrupoAula", b =>
                {
                    b.HasOne("PAESP.Models.Aula", "Aula")
                        .WithMany()
                        .HasForeignKey("IdAula")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PAESP.Models.Grupo", "Grupo")
                        .WithMany("Horaio")
                        .HasForeignKey("IdGrupo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aula");

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("PAESP.Models.GrupoEstudiante", b =>
                {
                    b.HasOne("PAESP.Models.Estudiante", null)
                        .WithMany("Grupos")
                        .HasForeignKey("EstudianteIdEstudiante")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PAESP.Models.Grupo", null)
                        .WithMany("Estudiantes")
                        .HasForeignKey("GrupoIdGrupo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PAESP.Models.Estudiante", "Estudiante")
                        .WithMany()
                        .HasForeignKey("IdEstudiante")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PAESP.Models.Grupo", "Grupo")
                        .WithMany()
                        .HasForeignKey("IdGrupo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Estudiante");

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("PAESP.Models.Preinscripcion", b =>
                {
                    b.HasOne("PAESP.Models.Usuario", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaIdUsuario");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("PAESP.Models.Profesor", b =>
                {
                    b.HasOne("PAESP.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("PAESP.Models.Programa", b =>
                {
                    b.HasOne("PAESP.Models.Estudiante", null)
                        .WithMany("Programas")
                        .HasForeignKey("EstudianteIdEstudiante");
                });

            modelBuilder.Entity("PAESP.Models.ProgramaMateria", b =>
                {
                    b.HasOne("PAESP.Models.Programa", "Programa")
                        .WithMany("Materias")
                        .HasForeignKey("CodigoPrograma");

                    b.HasOne("PAESP.Models.Materia", "Materia")
                        .WithMany("Programas")
                        .HasForeignKey("IdMateria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Materia");

                    b.Navigation("Programa");
                });

            modelBuilder.Entity("PAESP.Models.Recibo", b =>
                {
                    b.HasOne("PAESP.Models.Concepto", "Concepto")
                        .WithMany("Recibos")
                        .HasForeignKey("ConceptoIdConcepto");

                    b.Navigation("Concepto");
                });

            modelBuilder.Entity("PAESP.Models.Concepto", b =>
                {
                    b.Navigation("Recibos");
                });

            modelBuilder.Entity("PAESP.Models.Estudiante", b =>
                {
                    b.Navigation("Grupos");

                    b.Navigation("Programas");
                });

            modelBuilder.Entity("PAESP.Models.Grupo", b =>
                {
                    b.Navigation("Estudiantes");

                    b.Navigation("Horaio");
                });

            modelBuilder.Entity("PAESP.Models.Materia", b =>
                {
                    b.Navigation("Programas");
                });

            modelBuilder.Entity("PAESP.Models.Profesor", b =>
                {
                    b.Navigation("Grupos");
                });

            modelBuilder.Entity("PAESP.Models.Programa", b =>
                {
                    b.Navigation("Materias");
                });
#pragma warning restore 612, 618
        }
    }
}

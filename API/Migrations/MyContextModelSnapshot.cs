﻿// <auto-generated />
using System;
using API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.Property<string>("EmployeeNIK")
                        .HasColumnType("char(5)")
                        .HasColumnName("employee_nik");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.HasKey("EmployeeNIK");

                    b.ToTable("tb_m_accounts");
                });

            modelBuilder.Entity("API.Models.AccountRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountNIK")
                        .HasColumnType("char(5)")
                        .HasColumnName("account_nik");

                    b.Property<int?>("RoleID")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.HasKey("Id");

                    b.HasIndex("AccountNIK");

                    b.HasIndex("RoleID");

                    b.ToTable("tb_tr_account_roles");
                });

            modelBuilder.Entity("API.Models.Education", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Degree")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasColumnName("degree");

                    b.Property<string>("GPA")
                        .IsRequired()
                        .HasColumnType("varchar(5)")
                        .HasColumnName("gpa");

                    b.Property<string>("Major")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("major");

                    b.Property<int?>("UniversityID")
                        .HasColumnType("int")
                        .HasColumnName("university_id");

                    b.HasKey("ID");

                    b.HasIndex("UniversityID");

                    b.ToTable("tb_m_educations");
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.Property<string>("NIK")
                        .HasColumnType("char(5)")
                        .HasColumnName("nik");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime")
                        .HasColumnName("birth_date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("first_name");

                    b.Property<int>("Gender")
                        .HasColumnType("int")
                        .HasColumnName("gender");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime")
                        .HasColumnName("hiring_date");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(50)")
                        .HasColumnName("last_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("phone_number");

                    b.HasKey("NIK");

                    b.ToTable("tb_m_employees");
                });

            modelBuilder.Entity("API.Models.Profiling", b =>
                {
                    b.Property<string>("EmployeeNIK")
                        .HasColumnType("char(5)")
                        .HasColumnName("employee_nik");

                    b.Property<int?>("EducationID")
                        .HasColumnType("int")
                        .HasColumnName("education_id");

                    b.HasKey("EmployeeNIK");

                    b.HasIndex("EducationID")
                        .IsUnique()
                        .HasFilter("[education_id] IS NOT NULL");

                    b.ToTable("tb_tr_profilings");
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("tb_m_roles");
                });

            modelBuilder.Entity("API.Models.University", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("tb_m_universities");
                });

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.HasOne("API.Models.Employee", "Employee")
                        .WithOne("Account")
                        .HasForeignKey("API.Models.Account", "EmployeeNIK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("API.Models.AccountRole", b =>
                {
                    b.HasOne("API.Models.Account", "Account")
                        .WithMany("AccountRoles")
                        .HasForeignKey("AccountNIK")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("API.Models.Role", "Role")
                        .WithMany("AccountRoles")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Account");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("API.Models.Education", b =>
                {
                    b.HasOne("API.Models.University", "University")
                        .WithMany("Educations")
                        .HasForeignKey("UniversityID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("University");
                });

            modelBuilder.Entity("API.Models.Profiling", b =>
                {
                    b.HasOne("API.Models.Education", "Education")
                        .WithOne("Profiling")
                        .HasForeignKey("API.Models.Profiling", "EducationID")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("API.Models.Employee", "Employee")
                        .WithOne("Profiling")
                        .HasForeignKey("API.Models.Profiling", "EmployeeNIK")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Education");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("API.Models.Account", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("API.Models.Education", b =>
                {
                    b.Navigation("Profiling");
                });

            modelBuilder.Entity("API.Models.Employee", b =>
                {
                    b.Navigation("Account");

                    b.Navigation("Profiling");
                });

            modelBuilder.Entity("API.Models.Role", b =>
                {
                    b.Navigation("AccountRoles");
                });

            modelBuilder.Entity("API.Models.University", b =>
                {
                    b.Navigation("Educations");
                });
#pragma warning restore 612, 618
        }
    }
}

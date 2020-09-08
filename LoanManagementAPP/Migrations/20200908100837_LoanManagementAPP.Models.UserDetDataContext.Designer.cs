﻿// <auto-generated />
using LoanManagementAPP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoanManagementAPP.Migrations
{
    [DbContext(typeof(UserDetDataContext))]
    [Migration("20200908100837_LoanManagementAPP.Models.UserDetDataContext")]
    partial class LoanManagementAPPModelsUserDetDataContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LoanManagementAPP.Models.UserDetail", b =>
                {
                    b.Property<string>("UserName")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Roleid")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserName");

                    b.ToTable("UserDetailsData");

                    b.HasData(
                        new
                        {
                            UserName = "Adithya@gmail.com",
                            Password = "police",
                            Roleid = "1"
                        },
                        new
                        {
                            UserName = "Daya@gmail.com",
                            Password = "rams",
                            Roleid = "0"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
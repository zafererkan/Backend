﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Sobis.DAL.Concrete.EntityFramework.Contexts;

#nullable disable

namespace Sobis.DAL.Migrations
{
    [DbContext(typeof(PgDbContext))]
    [Migration("20240405212007_mig5")]
    partial class mig5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Sobis.Core.Entities.Concrete.AppClaimEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<string>("ClaimCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("CLAIM_CODE");

                    b.Property<string>("ClaimName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("CLAIM_NAME");

                    b.Property<DateTime?>("CrDate")
                        .HasColumnType("DATE")
                        .HasColumnName("CR_DATE");

                    b.Property<int?>("CrUser")
                        .HasColumnType("integer")
                        .HasColumnName("CR_USER");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("DATE")
                        .HasColumnName("MOD_DATE");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer")
                        .HasColumnName("MOD_USER");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("character varying(1)")
                        .HasDefaultValue("E")
                        .HasColumnName("STATUS");

                    b.HasKey("Id")
                        .HasName("APP_CLAIM_PK");

                    b.HasIndex(new[] { "ClaimCode" }, "APP_CLAIM_UK1")
                        .IsUnique();

                    b.ToTable("APP_CLAIM", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimCode = "admin",
                            ClaimName = "Sistem Yöneticisi",
                            CrDate = new DateTime(2024, 4, 6, 0, 20, 7, 262, DateTimeKind.Local).AddTicks(5035),
                            ModDate = new DateTime(2024, 4, 6, 0, 20, 7, 262, DateTimeKind.Local).AddTicks(5044)
                        },
                        new
                        {
                            Id = 2,
                            ClaimCode = "editor",
                            ClaimName = "Editör",
                            CrDate = new DateTime(2024, 4, 6, 0, 20, 7, 262, DateTimeKind.Local).AddTicks(5047),
                            ModDate = new DateTime(2024, 4, 6, 0, 20, 7, 262, DateTimeKind.Local).AddTicks(5047)
                        },
                        new
                        {
                            Id = 3,
                            ClaimCode = "user",
                            ClaimName = "user",
                            CrDate = new DateTime(2024, 4, 6, 0, 20, 7, 262, DateTimeKind.Local).AddTicks(5048),
                            ModDate = new DateTime(2024, 4, 6, 0, 20, 7, 262, DateTimeKind.Local).AddTicks(5049)
                        });
                });

            modelBuilder.Entity("Sobis.Core.Entities.Concrete.AppUserClaimEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<int>("AppClaimId")
                        .IsUnicode(false)
                        .HasColumnType("integer")
                        .HasColumnName("APP_CLAIM_ID");

                    b.Property<int>("AppUserId")
                        .IsUnicode(false)
                        .HasColumnType("integer")
                        .HasColumnName("APP_USER_ID");

                    b.Property<DateTime?>("CrDate")
                        .HasColumnType("DATE")
                        .HasColumnName("CR_DATE");

                    b.Property<int?>("CrUser")
                        .HasColumnType("integer")
                        .HasColumnName("CR_USER");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("DATE")
                        .HasColumnName("MOD_DATE");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer")
                        .HasColumnName("MOD_USER");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("character varying(1)")
                        .HasDefaultValue("E")
                        .HasColumnName("STATUS");

                    b.HasKey("Id")
                        .HasName("APP_USER_CLAIM_PK");

                    b.HasIndex(new[] { "AppUserId" }, "APP_USER_CLAIM_X1");

                    b.HasIndex(new[] { "AppClaimId" }, "APP_USER_CLAIM_X2");

                    b.ToTable("APP_USER_CLAIM", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AppClaimId = 1,
                            AppUserId = 1,
                            CrDate = new DateTime(2024, 4, 6, 0, 20, 7, 263, DateTimeKind.Local).AddTicks(5244),
                            ModDate = new DateTime(2024, 4, 6, 0, 20, 7, 263, DateTimeKind.Local).AddTicks(5247)
                        });
                });

            modelBuilder.Entity("Sobis.Core.Entities.Concrete.AppUserEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("CrDate")
                        .HasColumnType("DATE")
                        .HasColumnName("CR_DATE");

                    b.Property<int?>("CrUser")
                        .HasColumnType("integer")
                        .HasColumnName("CR_USER");

                    b.Property<int?>("DefaultCompanyId")
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("integer")
                        .HasColumnName("DEFAULT_COMPANY_ID");

                    b.Property<string>("Email")
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("EmailConfirmed")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("character varying(1)")
                        .HasDefaultValue("H")
                        .HasColumnName("EMAIL_CONFIRMED");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("DATE")
                        .HasColumnName("MOD_DATE");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer")
                        .HasColumnName("MOD_USER");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("NAME");

                    b.Property<string>("Password")
                        .HasMaxLength(120)
                        .IsUnicode(false)
                        .HasColumnType("character varying(120)")
                        .HasColumnName("PASSWORD");

                    b.Property<string>("Phone")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("character varying(15)")
                        .HasColumnName("PHONE");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("character varying(1)")
                        .HasDefaultValue("E")
                        .HasColumnName("STATUS");

                    b.Property<string>("Surname")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("SURNAME");

                    b.Property<int?>("Type")
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("integer")
                        .HasColumnName("TYPE");

                    b.HasKey("Id")
                        .HasName("APP_USER_PK");

                    b.HasIndex(new[] { "Email" }, "APP_USER_UK1")
                        .IsUnique();

                    b.HasIndex(new[] { "Phone" }, "APP_USER_UK2")
                        .IsUnique();

                    b.HasIndex(new[] { "Email", "Password" }, "APP_USER_X1");

                    b.HasIndex(new[] { "Phone", "Password" }, "APP_USER_X2");

                    b.ToTable("APP_USER", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CrDate = new DateTime(2024, 4, 6, 0, 20, 7, 265, DateTimeKind.Local).AddTicks(1030),
                            Email = "SRDR",
                            EmailConfirmed = "E",
                            ModDate = new DateTime(2024, 4, 6, 0, 20, 7, 265, DateTimeKind.Local).AddTicks(1033),
                            Name = "Serdar",
                            Password = "R6vvE51wrwp4yAo2Ld+VdQ==",
                            Phone = "0535 647 39 71",
                            Status = "E",
                            Surname = "ÖZDEMİR",
                            Type = 3
                        });
                });

            modelBuilder.Entity("Sobis.Entities.Concrete.Category.SubCategoryEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<int?>("CategoryId")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("integer")
                        .HasColumnName("CATEGORY_ID");

                    b.Property<DateTime?>("CrDate")
                        .HasColumnType("DATE")
                        .HasColumnName("CR_DATE");

                    b.Property<int?>("CrUser")
                        .HasColumnType("integer")
                        .HasColumnName("CR_USER");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("DATE")
                        .HasColumnName("MOD_DATE");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer")
                        .HasColumnName("MOD_USER");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("character varying(1)")
                        .HasDefaultValue("E")
                        .HasColumnName("STATUS");

                    b.Property<string>("SubCategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("SUB_CATEGORY_NAME");

                    b.HasKey("Id")
                        .HasName("SUB_CATEGORY_PK");

                    b.HasIndex("CategoryId");

                    b.ToTable("SUB_CATEGORY", (string)null);
                });

            modelBuilder.Entity("Sobis.Entities.Concrete.CategoryEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("CrDate")
                        .HasColumnType("DATE")
                        .HasColumnName("CR_DATE");

                    b.Property<int?>("CrUser")
                        .HasColumnType("integer")
                        .HasColumnName("CR_USER");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("DATE")
                        .HasColumnName("MOD_DATE");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer")
                        .HasColumnName("MOD_USER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("NAME");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("character varying(1)")
                        .HasDefaultValue("E")
                        .HasColumnName("STATUS");

                    b.HasKey("Id")
                        .HasName("CATEGORY_PK");

                    b.ToTable("CATEGORY", (string)null);
                });

            modelBuilder.Entity("Sobis.Entities.Concrete.City.CityEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("CITY_NAME");

                    b.Property<DateTime?>("CrDate")
                        .HasColumnType("DATE")
                        .HasColumnName("CR_DATE");

                    b.Property<int?>("CrUser")
                        .HasColumnType("integer")
                        .HasColumnName("CR_USER");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("DATE")
                        .HasColumnName("MOD_DATE");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer")
                        .HasColumnName("MOD_USER");

                    b.Property<string>("PlaneNo")
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("PLATE_NO");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("character varying(1)")
                        .HasDefaultValue("E")
                        .HasColumnName("STATUS");

                    b.HasKey("Id")
                        .HasName("CITY_PK");

                    b.HasIndex(new[] { "PlaneNo" }, "CITY_X1");

                    b.ToTable("CITY", (string)null);
                });

            modelBuilder.Entity("Sobis.Entities.Concrete.Parameter.ParameterDetailEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("CrDate")
                        .HasColumnType("DATE")
                        .HasColumnName("CR_DATE");

                    b.Property<int?>("CrUser")
                        .HasColumnType("integer")
                        .HasColumnName("CR_USER");

                    b.Property<int?>("Data")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("integer")
                        .HasColumnName("DATA");

                    b.Property<string>("DataValue")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("DATA_VALUE");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("DATE")
                        .HasColumnName("MOD_DATE");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer")
                        .HasColumnName("MOD_USER");

                    b.Property<int?>("OrderNo")
                        .IsUnicode(false)
                        .HasColumnType("integer")
                        .HasColumnName("ORDER_NO");

                    b.Property<string>("ParamDetailName")
                        .IsRequired()
                        .HasMaxLength(60)
                        .IsUnicode(false)
                        .HasColumnType("character varying(60)")
                        .HasColumnName("PARAM_DETAIL_NAME");

                    b.Property<int>("ParamId")
                        .IsUnicode(false)
                        .HasColumnType("integer")
                        .HasColumnName("PARAM_ID");

                    b.Property<int?>("ParentDataId")
                        .IsUnicode(false)
                        .HasColumnType("integer")
                        .HasColumnName("PARENT_DATA_ID");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("character varying(1)")
                        .HasDefaultValue("E")
                        .HasColumnName("STATUS");

                    b.HasKey("Id")
                        .HasName("PARAMETER_DETAIL_PK");

                    b.HasIndex(new[] { "ParamId" }, "PARAMETER_DETAIL_X1");

                    b.ToTable("PARAMETER_DETAIL", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CrDate = new DateTime(2024, 4, 6, 0, 20, 7, 276, DateTimeKind.Local).AddTicks(4954),
                            Data = 1,
                            ModDate = new DateTime(2024, 4, 6, 0, 20, 7, 276, DateTimeKind.Local).AddTicks(4964),
                            ParamDetailName = "New Brand",
                            ParamId = 1,
                            ParentDataId = 0,
                            Status = "E"
                        },
                        new
                        {
                            Id = 2,
                            CrDate = new DateTime(2024, 4, 6, 0, 20, 7, 276, DateTimeKind.Local).AddTicks(4967),
                            Data = 2,
                            ModDate = new DateTime(2024, 4, 6, 0, 20, 7, 276, DateTimeKind.Local).AddTicks(4968),
                            ParamDetailName = "Pre Owned",
                            ParamId = 1,
                            ParentDataId = 0,
                            Status = "E"
                        });
                });

            modelBuilder.Entity("Sobis.Entities.Concrete.Parameter.ParameterEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<DateTime?>("CrDate")
                        .HasColumnType("DATE")
                        .HasColumnName("CR_DATE");

                    b.Property<int?>("CrUser")
                        .HasColumnType("integer")
                        .HasColumnName("CR_USER");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("DATE")
                        .HasColumnName("MOD_DATE");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer")
                        .HasColumnName("MOD_USER");

                    b.Property<string>("ParamName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("PARAM_NAME");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("character varying(1)")
                        .HasDefaultValue("E")
                        .HasColumnName("STATUS");

                    b.HasKey("Id")
                        .HasName("PARAMETER_PK");

                    b.ToTable("PARAMETER", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CrDate = new DateTime(2024, 4, 6, 0, 20, 7, 276, DateTimeKind.Local).AddTicks(7663),
                            ModDate = new DateTime(2024, 4, 6, 0, 20, 7, 276, DateTimeKind.Local).AddTicks(7666),
                            ParamName = "Product Type Id",
                            Status = "E"
                        });
                });

            modelBuilder.Entity("Sobis.Entities.Concrete.Product.ProductEntity", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ID");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int?>("Id"));

                    b.Property<int?>("CategoryId")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("integer")
                        .HasColumnName("CATEGORY_ID");

                    b.Property<int?>("CityId")
                        .IsUnicode(false)
                        .HasColumnType("integer")
                        .HasColumnName("CITY_ID");

                    b.Property<DateTime?>("CrDate")
                        .HasColumnType("DATE")
                        .HasColumnName("CR_DATE");

                    b.Property<int?>("CrUser")
                        .HasColumnType("integer")
                        .HasColumnName("CR_USER");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("character varying(500)")
                        .HasColumnName("DESCRIPTION");

                    b.Property<int?>("DistrictId")
                        .IsUnicode(false)
                        .HasColumnType("integer")
                        .HasColumnName("DISTRICT_ID");

                    b.Property<int?>("MaxBudget")
                        .IsUnicode(false)
                        .HasColumnType("integer")
                        .HasColumnName("MAX_BUDGET");

                    b.Property<int?>("MinBudget")
                        .IsUnicode(false)
                        .HasColumnType("integer")
                        .HasColumnName("MIN_BUDGET");

                    b.Property<DateTime?>("ModDate")
                        .HasColumnType("DATE")
                        .HasColumnName("MOD_DATE");

                    b.Property<int?>("ModUser")
                        .HasColumnType("integer")
                        .HasColumnName("MOD_USER");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("PRODUCT_NAME");

                    b.Property<int?>("ProductTypeId")
                        .IsUnicode(false)
                        .HasColumnType("integer")
                        .HasColumnName("PRODUCT_TYPE_ID");

                    b.Property<string>("Status")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(1)
                        .IsUnicode(false)
                        .HasColumnType("character varying(1)")
                        .HasDefaultValue("E")
                        .HasColumnName("STATUS");

                    b.Property<int?>("SubCategoryId")
                        .IsUnicode(false)
                        .HasColumnType("integer")
                        .HasColumnName("SUB_CATEGORY_ID");

                    b.HasKey("Id")
                        .HasName("PRODUCT_PK");

                    b.HasIndex(new[] { "CategoryId" }, "PRODUCT_X1");

                    b.HasIndex(new[] { "ProductName" }, "PRODUCT_X2");

                    b.HasIndex(new[] { "SubCategoryId" }, "PRODUCT_X3");

                    b.ToTable("PRODUCT", (string)null);
                });

            modelBuilder.Entity("Sobis.Entities.Concrete.Category.SubCategoryEntity", b =>
                {
                    b.HasOne("Sobis.Entities.Concrete.CategoryEntity", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("SUB_CATEGORY_FK1");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Sobis.Entities.Concrete.Parameter.ParameterDetailEntity", b =>
                {
                    b.HasOne("Sobis.Entities.Concrete.Parameter.ParameterEntity", "Param")
                        .WithMany("ParametreDetails")
                        .HasForeignKey("ParamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PARAMETER_DETAIL_FK1");

                    b.Navigation("Param");
                });

            modelBuilder.Entity("Sobis.Entities.Concrete.Product.ProductEntity", b =>
                {
                    b.HasOne("Sobis.Entities.Concrete.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("PRODUCT_FK1");

                    b.HasOne("Sobis.Entities.Concrete.Category.SubCategoryEntity", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryId")
                        .HasConstraintName("PRODUCT_FK2");

                    b.Navigation("Category");

                    b.Navigation("SubCategory");
                });

            modelBuilder.Entity("Sobis.Entities.Concrete.Category.SubCategoryEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Sobis.Entities.Concrete.CategoryEntity", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("Sobis.Entities.Concrete.Parameter.ParameterEntity", b =>
                {
                    b.Navigation("ParametreDetails");
                });
#pragma warning restore 612, 618
        }
    }
}

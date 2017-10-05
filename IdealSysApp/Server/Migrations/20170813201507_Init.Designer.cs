using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IdealSysApp.Data;
using IdealSysApp.Data.Enums;

namespace IdealSysApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170813201507_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IdealSysApp.Models.Entities.DynamicProperty", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("IdentityId");

                    b.Property<string>("IntegrationKey");

                    b.Property<bool>("IsMultiSelect");

                    b.Property<string>("Key");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<long?>("ProductId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.HasIndex("ProductId");

                    b.ToTable("DynamicProperties");
                });

            modelBuilder.Entity("IdealSysApp.Models.Entities.DynamicPropertyValue", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("DynamicPropertyId");

                    b.Property<bool>("IsSelected");

                    b.Property<string>("Key");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("DynamicPropertyId");

                    b.ToTable("DynamicPropertyValues");
                });

            modelBuilder.Entity("IdealSysApp.Models.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AcceptedDate");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("IdentityId");

                    b.Property<string>("IntegrationKey");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<int>("OrderStatus");

                    b.Property<DateTime?>("SendDate");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("IdealSysApp.Models.Entities.OrderItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("IdentityId");

                    b.Property<string>("IntegrationKey");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<long>("OrderId");

                    b.Property<long>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("IdealSysApp.Models.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("IdentityId");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("IntegrationKey");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<long>("ProductCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.HasIndex("ProductCategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("IdealSysApp.Models.Entities.ProductCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("IdentityId");

                    b.Property<string>("IntegrationKey");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("IdealSysApp.Models.Entities.ProductFeature", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<long>("DynamicPropertyId");

                    b.Property<string>("IdentityId");

                    b.Property<string>("IntegrationKey");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<long>("ProductId");

                    b.HasKey("Id");

                    b.HasIndex("DynamicPropertyId");

                    b.HasIndex("IdentityId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductFeatures");
                });

            modelBuilder.Entity("IdealSysApp.Models.Entities.ProductImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("DisplayName");

                    b.Property<string>("Extensions")
                        .HasMaxLength(10);

                    b.Property<string>("IdentityId");

                    b.Property<string>("IntegrationKey");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.Property<long>("ProductId");

                    b.Property<decimal>("Size");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("IdealSysApp.Models.Entities.Storage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Description");

                    b.Property<string>("IdentityId");

                    b.Property<string>("IntegrationKey");

                    b.Property<DateTime>("ModifiedDate");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("IdealSysApp.Models.Entities.AppUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<long?>("StorageId");

                    b.HasIndex("StorageId");

                    b.ToTable("AppUser");

                    b.HasDiscriminator().HasValue("AppUser");
                });

            modelBuilder.Entity("IdealSysApp.Models.Entities.DynamicProperty", b =>
                {
                    b.HasOne("IdealSysApp.Models.Entities.AppUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");

                    b.HasOne("IdealSysApp.Models.Entities.Product")
                        .WithMany("DynamicProperties")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("IdealSysApp.Models.Entities.DynamicPropertyValue", b =>
                {
                    b.HasOne("IdealSysApp.Models.Entities.DynamicProperty", "DynamicProperty")
                        .WithMany("DynamicPropertyValues")
                        .HasForeignKey("DynamicPropertyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IdealSysApp.Models.Entities.Order", b =>
                {
                    b.HasOne("IdealSysApp.Models.Entities.AppUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");
                });

            modelBuilder.Entity("IdealSysApp.Models.Entities.OrderItem", b =>
                {
                    b.HasOne("IdealSysApp.Models.Entities.AppUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");

                    b.HasOne("IdealSysApp.Models.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IdealSysApp.Models.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IdealSysApp.Models.Entities.Product", b =>
                {
                    b.HasOne("IdealSysApp.Models.Entities.AppUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");

                    b.HasOne("IdealSysApp.Models.Entities.ProductCategory", "ProductCategory")
                        .WithMany()
                        .HasForeignKey("ProductCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IdealSysApp.Models.Entities.ProductCategory", b =>
                {
                    b.HasOne("IdealSysApp.Models.Entities.AppUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");
                });

            modelBuilder.Entity("IdealSysApp.Models.Entities.ProductFeature", b =>
                {
                    b.HasOne("IdealSysApp.Models.Entities.DynamicProperty", "DynamicProperty")
                        .WithMany()
                        .HasForeignKey("DynamicPropertyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IdealSysApp.Models.Entities.AppUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");

                    b.HasOne("IdealSysApp.Models.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IdealSysApp.Models.Entities.ProductImage", b =>
                {
                    b.HasOne("IdealSysApp.Models.Entities.AppUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");

                    b.HasOne("IdealSysApp.Models.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IdealSysApp.Models.Entities.Storage", b =>
                {
                    b.HasOne("IdealSysApp.Models.Entities.AppUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IdealSysApp.Models.Entities.AppUser", b =>
                {
                    b.HasOne("IdealSysApp.Models.Entities.Storage", "Storage")
                        .WithMany("Users")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.SetNull);
                });
        }
    }
}

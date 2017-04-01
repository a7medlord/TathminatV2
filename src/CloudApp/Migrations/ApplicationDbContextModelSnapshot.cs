﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CloudApp.Data;

namespace CloudApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CloudApp.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("EmployName");

                    b.Property<string>("IdenetityPic");

                    b.Property<string>("IdentityId");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("MemberId");

                    b.Property<string>("MemberPhotoId");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("ProfilePic");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("SigImage");

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
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.AttachmentForTreament", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AttachmentId");

                    b.Property<long>("TreatmentId");

                    b.HasKey("Id");

                    b.HasIndex("TreatmentId");

                    b.ToTable("AttachmentForTreaments");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Custmer", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustmerType");

                    b.Property<string>("Email");

                    b.Property<string>("FromClint");

                    b.Property<string>("ImgId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Phone");

                    b.Property<long>("SampleId");

                    b.HasKey("Id");

                    b.HasIndex("SampleId");

                    b.ToTable("Custmer");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Flag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("FlagValue");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Flag");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Instrument", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Amount");

                    b.Property<string>("Area");

                    b.Property<string>("BDiscrib");

                    b.Property<string>("Locat");

                    b.Property<long>("QuotationId");

                    b.Property<string>("SNum");

                    b.HasKey("Id");

                    b.HasIndex("QuotationId");

                    b.ToTable("Instrument");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Quotation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Bank");

                    b.Property<string>("Complate");

                    b.Property<long>("CustmerId");

                    b.Property<string>("FBatch");

                    b.Property<DateTime>("QDate");

                    b.Property<string>("SCustmer");

                    b.Property<string>("Sign");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CustmerId");

                    b.ToTable("Quotation");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.R1Smaple", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Acce");

                    b.Property<string>("Agbuild");

                    b.Property<string>("Area");

                    b.Property<string>("CaseBuild");

                    b.Property<string>("City");

                    b.Property<long>("CustmerId");

                    b.Property<string>("DateSNum");

                    b.Property<bool>("ElictFire");

                    b.Property<string>("Gada");

                    b.Property<bool>("IsAduit");

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("IsIntered");

                    b.Property<bool>("IsThmin");

                    b.Property<string>("Local");

                    b.Property<string>("Napartment");

                    b.Property<string>("OccBuild");

                    b.Property<string>("Owner");

                    b.Property<string>("Plane");

                    b.Property<string>("ResWland");

                    b.Property<string>("SCustmer");

                    b.Property<string>("SNum");

                    b.Property<string>("Street");

                    b.Property<string>("StyleBuild");

                    b.Property<string>("Tbuild");

                    b.Property<string>("Wland");

                    b.HasKey("Id");

                    b.HasIndex("CustmerId");

                    b.ToTable("R1Smaple");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.R2Smaple", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Acce");

                    b.Property<string>("Agbuild");

                    b.Property<string>("Area");

                    b.Property<string>("CaseBuild");

                    b.Property<string>("City");

                    b.Property<long>("CustmerId");

                    b.Property<string>("DateSNum");

                    b.Property<bool>("ElictFire");

                    b.Property<string>("Gada");

                    b.Property<bool>("IsAduit");

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("IsIntered");

                    b.Property<bool>("IsThmin");

                    b.Property<string>("Local");

                    b.Property<string>("Napartment");

                    b.Property<string>("OccBuild");

                    b.Property<string>("Owner");

                    b.Property<string>("Plane");

                    b.Property<string>("PurpApp");

                    b.Property<string>("ResWland");

                    b.Property<string>("SCustmer");

                    b.Property<string>("SNum");

                    b.Property<string>("Street");

                    b.Property<string>("StyleBuild");

                    b.Property<string>("Tbuild");

                    b.Property<string>("Wland");

                    b.HasKey("Id");

                    b.HasIndex("CustmerId");

                    b.ToTable("R2Smaple");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Sample", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Samples");
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Treatment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Adutit");

                    b.Property<string>("Agbuild");

                    b.Property<string>("ApplicationUserId");

                    b.Property<string>("Approver");

                    b.Property<string>("Area");

                    b.Property<string>("CaseBuild");

                    b.Property<string>("City");

                    b.Property<long>("CustmerId");

                    b.Property<string>("DateSNum");

                    b.Property<string>("East");

                    b.Property<string>("EastTall");

                    b.Property<string>("Gada");

                    b.Property<string>("GenLoc");

                    b.Property<string>("GenralLocations");

                    b.Property<string>("Intered");

                    b.Property<bool>("IsAduit");

                    b.Property<bool>("IsApproved");

                    b.Property<bool>("IsIntered");

                    b.Property<bool>("IsThmin");

                    b.Property<string>("Latute");

                    b.Property<string>("Local");

                    b.Property<string>("Longtute");

                    b.Property<string>("MantinCost");

                    b.Property<double>("MeterPriceForBulding");

                    b.Property<double>("MeterPriceForEarth");

                    b.Property<string>("MothmnOpnin");

                    b.Property<string>("Musteh");

                    b.Property<string>("Muthmen");

                    b.Property<string>("Napartment");

                    b.Property<string>("North");

                    b.Property<string>("NorthTall");

                    b.Property<string>("NotesAndAbstracting");

                    b.Property<string>("OccBuild");

                    b.Property<string>("Owner");

                    b.Property<string>("Plane");

                    b.Property<string>("ResWland");

                    b.Property<string>("SCustmer");

                    b.Property<string>("SNum");

                    b.Property<bool>("ServicesElectrocitcs");

                    b.Property<bool>("ServicesLamp");

                    b.Property<bool>("ServicesPhone");

                    b.Property<bool>("ServicesRoad");

                    b.Property<bool>("ServicesSanitation");

                    b.Property<bool>("ServicesWater");

                    b.Property<string>("South");

                    b.Property<string>("SouthTall");

                    b.Property<bool>("SroundBank");

                    b.Property<bool>("SroundCentralSoaq");

                    b.Property<bool>("SroundComirchalCenter");

                    b.Property<bool>("SroundDispensares");

                    b.Property<bool>("SroundFeul");

                    b.Property<bool>("SroundGarden");

                    b.Property<bool>("SroundGenralSoaq");

                    b.Property<bool>("SroundGovermentDepartMent");

                    b.Property<bool>("SroundHospital");

                    b.Property<bool>("SroundHotel");

                    b.Property<bool>("SroundMosq");

                    b.Property<bool>("SroundPoilceCenter");

                    b.Property<bool>("SroundRestrant");

                    b.Property<bool>("SroundSchools");

                    b.Property<bool>("SroundSoaq");

                    b.Property<bool>("SroundciviliDenfencs");

                    b.Property<bool>("SroundmedSecurityFacilty");

                    b.Property<bool>("SroundmedicalCenter");

                    b.Property<bool>("Sroundmedicalfacilty");

                    b.Property<bool>("Sroundpartment");

                    b.Property<string>("Street");

                    b.Property<string>("StyleBuild");

                    b.Property<string>("Tbuild");

                    b.Property<string>("TotalBulding");

                    b.Property<string>("TotalForEarcth");

                    b.Property<double>("TotalPriceNumber");

                    b.Property<string>("West");

                    b.Property<string>("WestTall");

                    b.Property<string>("Wland");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CustmerId");

                    b.ToTable("Treatment");
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

            modelBuilder.Entity("CloudApp.Models.BusinessModel.AttachmentForTreament", b =>
                {
                    b.HasOne("CloudApp.Models.BusinessModel.Treatment", "Treatment")
                        .WithMany("AttachmentForTreaments")
                        .HasForeignKey("TreatmentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Custmer", b =>
                {
                    b.HasOne("CloudApp.Models.BusinessModel.Sample", "Sample")
                        .WithMany("Custmers")
                        .HasForeignKey("SampleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Instrument", b =>
                {
                    b.HasOne("CloudApp.Models.BusinessModel.Quotation", "Quotation")
                        .WithMany("Instruments")
                        .HasForeignKey("QuotationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Quotation", b =>
                {
                    b.HasOne("CloudApp.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("Quotations")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("CloudApp.Models.BusinessModel.Custmer", "Custmer")
                        .WithMany("Quotations")
                        .HasForeignKey("CustmerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.R1Smaple", b =>
                {
                    b.HasOne("CloudApp.Models.BusinessModel.Custmer", "Custmer")
                        .WithMany()
                        .HasForeignKey("CustmerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.R2Smaple", b =>
                {
                    b.HasOne("CloudApp.Models.BusinessModel.Custmer", "Custmer")
                        .WithMany()
                        .HasForeignKey("CustmerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CloudApp.Models.BusinessModel.Treatment", b =>
                {
                    b.HasOne("CloudApp.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("CloudApp.Models.BusinessModel.Custmer", "Custmer")
                        .WithMany("Treatments")
                        .HasForeignKey("CustmerId")
                        .OnDelete(DeleteBehavior.Cascade);
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
                    b.HasOne("CloudApp.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CloudApp.Models.ApplicationUser")
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

                    b.HasOne("CloudApp.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}

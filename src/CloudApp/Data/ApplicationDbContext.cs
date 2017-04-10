﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CloudApp.Models;
using CloudApp.Models.BusinessModel;

namespace CloudApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public ApplicationDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Custmer> Custmer { get; set; }

        public DbSet<Quotation> Quotation { get; set; }

        public DbSet<Instrument> Instrument { get; set; }

        public DbSet<Treatment> Treatment { get; set; }
        public DbSet<Sample> Samples { get; set; }
        public DbSet<R1Smaple> R1Smaple { get; set; }
        public DbSet<R2Smaple> R2Smaple { get; set; }
        public DbSet<Flag> Flag { get; set; }

        public DbSet<AttachmentForTreament> AttachmentForTreaments { get; set; }

        public DbSet<AttachmentForR1Sample> AttachmentForR1Samples { get; set; }

        public DbSet<AttachmentForR2Sample> AttachmentForR2Samples { get; set; }

        public DbSet<CloudApp.Models.BusinessModel.FinModel> FinModel { get; set; }


        
    }
}

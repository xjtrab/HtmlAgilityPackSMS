﻿using System;
using HtmlAgilityPackSMS.Managers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HtmlAgilityPackSMS
{
    public partial class efContext : DbContext
    {
        public efContext()
        {
           
        }

        public efContext(DbContextOptions<efContext> options)
            : base(options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(ConfigManager.DbConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public DbSet<Rent> Rents { get; set; }
        public DbSet<SMSRawData> SMSRawDatas{get;set;}
        public DbSet<SendHandListStatus> SendHandListStatuss{get;set;}
        public DbSet<Community> Communitys { get; set; }
        public DbSet<GlobalStatus> GlobalStatuses{get;set;}
        public DbSet<AcquisitionUnit> AcquisitionUnit{get;set;}
    }
}

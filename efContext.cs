using System;
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Port=3307;Database=ef;User=root;Password=wo113661;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {}

        public DbSet<Rent> Rents { get; set; }
        public DbSet<SMSRawData> SMSRawDatas{get;set;}
        public DbSet<SendHandListStatus> SendHandListStatuss{get;set;}
    }
}

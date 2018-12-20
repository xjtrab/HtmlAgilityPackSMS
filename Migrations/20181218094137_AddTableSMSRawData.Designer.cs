﻿// <auto-generated />
using System;
using HtmlAgilityPackSMS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HtmlAgilityPackSMS.Migrations
{
    [DbContext(typeof(efContext))]
    [Migration("20181218094137_AddTableSMSRawData")]
    partial class AddTableSMSRawData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("SMSRawData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Request");

                    b.Property<string>("Response");

                    b.Property<int>("ResponseCode");

                    b.Property<DateTime>("SendTime");

                    b.HasKey("Id");

                    b.ToTable("SMSRawDatas");
                });
#pragma warning restore 612, 618
        }
    }
}

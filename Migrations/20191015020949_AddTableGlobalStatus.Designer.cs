﻿// <auto-generated />
using HtmlAgilityPackSMS;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HtmlAgilityPackSMS.Migrations
{
    [DbContext(typeof(efContext))]
    [Migration("20191015020949_AddTableGlobalStatus")]
    partial class AddTableGlobalStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Community", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<long>("CreateTime");

                    b.Property<long>("ModifiedTime");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<int>("RentCount");

                    b.Property<int>("SeeCountRecentThirtyDays");

                    b.Property<int>("SellCount");

                    b.Property<string>("ThridPartyId");

                    b.Property<int>("ThridPraty");

                    b.HasKey("Id");

                    b.ToTable("Communitys");
                });

            modelBuilder.Entity("GlobalStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CreateTime");

                    b.Property<long>("ModifiedTime");

                    b.Property<string>("StatusFrom");

                    b.Property<int>("TotalCommunityCount");

                    b.HasKey("Id");

                    b.ToTable("GlobalStatuses");
                });

            modelBuilder.Entity("Rent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("SendHandListStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CreateTime");

                    b.Property<long>("ModifiedTime");

                    b.Property<int>("Total");

                    b.HasKey("Id");

                    b.ToTable("SendHandListStatuss");
                });

            modelBuilder.Entity("SMSRawData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CreateTime");

                    b.Property<long>("ModifiedTime");

                    b.Property<string>("Request");

                    b.Property<string>("Response");

                    b.Property<int>("ResponseCode");

                    b.HasKey("Id");

                    b.ToTable("SMSRawDatas");
                });
#pragma warning restore 612, 618
        }
    }
}

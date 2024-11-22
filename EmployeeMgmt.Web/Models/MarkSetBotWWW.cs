using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeeMgmt.Web.Models
{
    public partial class MarkSetBotWWW : DbContext
    {
        public MarkSetBotWWW()
        {
        }

        public MarkSetBotWWW(DbContextOptions<MarkSetBotWWW> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<Buoy> Buoys { get; set; } = null!;
        public virtual DbSet<Coursehistory> Coursehistories { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<Logbotstatus> Logbotstatuses { get; set; } = null!;
        public virtual DbSet<Logbotstatusversioninfo> Logbotstatusversioninfos { get; set; } = null!;
        public virtual DbSet<Logbotstatuswheading> Logbotstatuswheadings { get; set; } = null!;
        public virtual DbSet<Logbuoy> Logbuoys { get; set; } = null!;
        public virtual DbSet<Logorg> Logorgs { get; set; } = null!;
        public virtual DbSet<MigrationHistory> MigrationHistories { get; set; } = null!;
        public virtual DbSet<Note> Notes { get; set; } = null!;
        public virtual DbSet<Org> Orgs { get; set; } = null!;
        public virtual DbSet<Orguser> Orgusers { get; set; } = null!;
        public virtual DbSet<Version> Versions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("name=DefaultConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.Name, "RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.UserName, "UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Createdon)
                    .HasColumnType("datetime")
                    .HasColumnName("createdon");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Lat)
                    .HasMaxLength(50)
                    .HasColumnName("lat");

                entity.Property(e => e.Latlongtimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("latlongtimestamp");

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Long)
                    .HasMaxLength(50)
                    .HasColumnName("long");

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId").HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId").HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId").HasName("PK_dbo.AspNetUserRoles");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_RoleId");

                            j.HasIndex(new[] { "UserId" }, "IX_UserId");

                            j.IndexerProperty<string>("UserId").HasMaxLength(128);

                            j.IndexerProperty<string>("RoleId").HasMaxLength(128);
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId, "IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<Buoy>(entity =>
            {
                entity.ToTable("BUOY");

                entity.Property(e => e.Buoyid).HasColumnName("buoyid");

                entity.Property(e => e.Assetvalue)
                    .HasMaxLength(50)
                    .HasColumnName("assetvalue");

                entity.Property(e => e.Batteryah)
                    .HasMaxLength(50)
                    .HasColumnName("batteryah");

                entity.Property(e => e.Batterymonitorguid)
                    .HasMaxLength(50)
                    .HasColumnName("batterymonitorguid");

                entity.Property(e => e.Charging)
                    .HasMaxLength(50)
                    .HasColumnName("charging");

                entity.Property(e => e.Docklatlong)
                    .HasMaxLength(50)
                    .HasColumnName("docklatlong");

                entity.Property(e => e.Foreignsystemid)
                    .HasMaxLength(150)
                    .HasColumnName("foreignsystemid");

                entity.Property(e => e.Frameserial)
                    .HasMaxLength(50)
                    .HasColumnName("frameserial");

                entity.Property(e => e.Hardwareversion)
                    .HasMaxLength(50)
                    .HasColumnName("hardwareversion");

                entity.Property(e => e.Hull)
                    .HasMaxLength(50)
                    .HasColumnName("hull");

                entity.Property(e => e.Latlong)
                    .HasMaxLength(50)
                    .HasColumnName("latlong");

                entity.Property(e => e.Latlongtimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("latlongtimestamp");

                entity.Property(e => e.Monthlyfee)
                    .HasMaxLength(50)
                    .HasColumnName("monthlyfee");

                entity.Property(e => e.Motorfirstusagedate)
                    .HasColumnType("datetime")
                    .HasColumnName("motorfirstusagedate");

                entity.Property(e => e.Motormount)
                    .HasMaxLength(50)
                    .HasColumnName("motormount");

                entity.Property(e => e.Motorserial)
                    .HasMaxLength(50)
                    .HasColumnName("motorserial");

                entity.Property(e => e.Motortype)
                    .HasMaxLength(50)
                    .HasColumnName("motortype");

                entity.Property(e => e.Name)
                    .HasMaxLength(3)
                    .HasColumnName("name");

                entity.Property(e => e.Orgid).HasColumnName("orgid");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");

                entity.Property(e => e.Phoneimei)
                    .HasMaxLength(50)
                    .HasColumnName("phoneimei");

                entity.Property(e => e.Phonename)
                    .HasMaxLength(50)
                    .HasColumnName("phonename");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(50)
                    .HasColumnName("phonenumber");

                entity.Property(e => e.Phonepin)
                    .HasMaxLength(4)
                    .HasColumnName("phonepin");

                entity.Property(e => e.Pronavguid)
                    .HasMaxLength(50)
                    .HasColumnName("pronavguid");

                entity.Property(e => e.Pronavlower)
                    .HasMaxLength(50)
                    .HasColumnName("pronavlower");

                entity.Property(e => e.Pronavlowermount)
                    .HasMaxLength(50)
                    .HasColumnName("pronavlowermount");

                entity.Property(e => e.Pronavserial)
                    .HasMaxLength(50)
                    .HasColumnName("pronavserial");

                entity.Property(e => e.Pronavupper)
                    .HasMaxLength(50)
                    .HasColumnName("pronavupper");

                entity.Property(e => e.Pronavuppermount)
                    .HasMaxLength(50)
                    .HasColumnName("pronavuppermount");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .HasColumnName("role")
                    .HasDefaultValueSql("('Misc')");

                entity.Property(e => e.Sailbotguid)
                    .HasMaxLength(50)
                    .HasColumnName("sailbotguid");

                entity.Property(e => e.Sailtimerguid)
                    .HasMaxLength(50)
                    .HasColumnName("sailtimerguid");

                entity.Property(e => e.Spinprevention)
                    .HasMaxLength(50)
                    .HasColumnName("spinprevention");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status")
                    .HasDefaultValueSql("('Inactive')");

                entity.Property(e => e.Switch)
                    .HasMaxLength(50)
                    .HasColumnName("switch");

                entity.Property(e => e.Topside)
                    .HasMaxLength(50)
                    .HasColumnName("topside");

                entity.Property(e => e.Uniquekey)
                    .HasMaxLength(50)
                    .HasColumnName("uniquekey");

                entity.Property(e => e.Visible)
                    .HasMaxLength(10)
                    .HasColumnName("visible")
                    .HasDefaultValueSql("('True')");

                entity.Property(e => e.Warrantyenddate)
                    .HasColumnType("datetime")
                    .HasColumnName("warrantyenddate");

                entity.Property(e => e.Waterproofing)
                    .HasMaxLength(50)
                    .HasColumnName("waterproofing");
            });

            modelBuilder.Entity<Coursehistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("COURSEHISTORY");

                entity.HasIndex(e => e.Orgid, "IX_COURSEHISTORY_orgid");

                entity.HasIndex(e => new { e.Orgid, e.Timestamp }, "IX_COURSEHISTORY_orgid_timestamp");

                entity.Property(e => e.Coursedirection)
                    .HasMaxLength(50)
                    .HasColumnName("coursedirection");

                entity.Property(e => e.Coursefinishtype)
                    .HasMaxLength(50)
                    .HasColumnName("coursefinishtype");

                entity.Property(e => e.Coursehistoryid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("coursehistoryid");

                entity.Property(e => e.Courselength)
                    .HasMaxLength(50)
                    .HasColumnName("courselength");

                entity.Property(e => e.Courseoffsetlengthm)
                    .HasMaxLength(50)
                    .HasColumnName("courseoffsetlengthm");

                entity.Property(e => e.Coursestartlat)
                    .HasMaxLength(50)
                    .HasColumnName("coursestartlat");

                entity.Property(e => e.Coursestartlinelengthm)
                    .HasMaxLength(50)
                    .HasColumnName("coursestartlinelengthm");

                entity.Property(e => e.Coursestartlong)
                    .HasMaxLength(50)
                    .HasColumnName("coursestartlong");

                entity.Property(e => e.Orgid).HasColumnName("orgid");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("LOG");

                entity.HasIndex(e => e.AuthToken, "IX_LOG_AuthToken");

                entity.HasIndex(e => e.Date, "IX_LOG_Date");

                entity.HasIndex(e => new { e.Date, e.AuthToken, e.GroupName }, "IX_LOG_Date_AuthToken_GroupName");

                entity.HasIndex(e => new { e.Date, e.GroupName }, "IX_LOG_Date_GroupName");

                entity.HasIndex(e => new { e.Date, e.Userid, e.GroupName }, "IX_LOG_Date_Userid_GroupName");

                entity.HasIndex(e => e.GroupName, "IX_LOG_GroupName");

                entity.Property(e => e.AuthToken).HasMaxLength(50);

                entity.Property(e => e.BroadcastToSpecificConnectionId).HasMaxLength(100);

                entity.Property(e => e.ConnectionId).HasMaxLength(100);

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Exception)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.GroupName).HasMaxLength(50);

                entity.Property(e => e.Level)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Logger)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Message)
                    .HasMaxLength(4000)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.Routine).HasMaxLength(100);

                entity.Property(e => e.Thread)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserAgent).HasMaxLength(500);

                entity.Property(e => e.UserHostAddress).HasMaxLength(255);

                entity.Property(e => e.Userid).HasMaxLength(256);
            });

            modelBuilder.Entity<Logbotstatus>(entity =>
            {
                entity.ToTable("LOGBOTSTATUS");

                entity.HasIndex(e => e.Buoyid, "IX_LOGBOTSTATUS_buoyid");

                entity.HasIndex(e => e.Orgid, "IX_LOGBOTSTATUS_orgid");

                entity.HasIndex(e => e.Timestamp, "IX_LOGBOTSTATUS_timestamp");

                entity.Property(e => e.Logbotstatusid).HasColumnName("logbotstatusid");

                entity.Property(e => e.B1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.B2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.B3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.B4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.B5)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.B6)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.B7)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Buoyid).HasColumnName("buoyid");

                entity.Property(e => e.C1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.C2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.G1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.G2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.G3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.G4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.H1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.H2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.H3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.H4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.K)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Orgid).HasColumnName("orgid");

                entity.Property(e => e.P)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pn1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN1");

                entity.Property(e => e.Pn10)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN10");

                entity.Property(e => e.Pn11)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN11");

                entity.Property(e => e.Pn12)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PN12");

                entity.Property(e => e.Pn13)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN13");

                entity.Property(e => e.Pn14)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN14");

                entity.Property(e => e.Pn15)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN15");

                entity.Property(e => e.Pn16)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN16");

                entity.Property(e => e.Pn17)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN17");

                entity.Property(e => e.Pn18)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN18");

                entity.Property(e => e.Pn19)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN19");

                entity.Property(e => e.Pn2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN2");

                entity.Property(e => e.Pn20)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN20");

                entity.Property(e => e.Pn21)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN21");

                entity.Property(e => e.Pn22)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN22");

                entity.Property(e => e.Pn23)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PN23");

                entity.Property(e => e.Pn3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN3");

                entity.Property(e => e.Pn4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN4");

                entity.Property(e => e.Pn5)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN5");

                entity.Property(e => e.Pn6)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN6");

                entity.Property(e => e.Pn7)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN7");

                entity.Property(e => e.Pn8)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN8");

                entity.Property(e => e.Pn9)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN9");

                entity.Property(e => e.R)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.S)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.T)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Timestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("timestamp");

                entity.Property(e => e.V)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.W1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.W2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.W3)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.W4)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.W5)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.W6)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Logbotstatusversioninfo>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LOGBOTSTATUSVERSIONINFO");

                entity.Property(e => e.Buoyid).HasColumnName("buoyid");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Org)
                    .HasMaxLength(250)
                    .HasColumnName("org");

                entity.Property(e => e.Pn3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN3");

                entity.Property(e => e.V)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Logbotstatuswheading>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("LOGBOTSTATUSWHEADINGS");

                entity.Property(e => e.AppStartUtc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("App_Start_UTC");

                entity.Property(e => e.AppVer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("App_Ver");

                entity.Property(e => e.BatteryA)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Battery_A");

                entity.Property(e => e.BatteryGuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Battery_GUID");

                entity.Property(e => e.BatteryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Battery_Name");

                entity.Property(e => e.BatteryReconnect)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Battery_Reconnect");

                entity.Property(e => e.BatteryRssi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Battery_RSSI");

                entity.Property(e => e.BatteryRssiUtc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Battery_RSSI_UTC");

                entity.Property(e => e.BatterySoc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Battery_SOC");

                entity.Property(e => e.BatteryV)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Battery_V");

                entity.Property(e => e.Cellular)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HornGuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Horn_GUID");

                entity.Property(e => e.HornName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Horn_Name");

                entity.Property(e => e.HornReconnect)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Horn_Reconnect");

                entity.Property(e => e.HornRssi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Horn_RSSI");

                entity.Property(e => e.HornRssiUtc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Horn_RSSI_UTC");

                entity.Property(e => e.PnCompDir)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_Comp_Dir");

                entity.Property(e => e.PnCompHealth)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_Comp_Health");

                entity.Property(e => e.PnCompInterf)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_Comp_Interf");

                entity.Property(e => e.PnFwver)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_FWVer");

                entity.Property(e => e.PnGpsCount)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_GPS_Count");

                entity.Property(e => e.PnGpsHdop)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_GPS_HDOP");

                entity.Property(e => e.PnGpsLock)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_GPS_Lock");

                entity.Property(e => e.PnGuardUtc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_Guard_UTC");

                entity.Property(e => e.PnHwver)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_HWVer");

                entity.Property(e => e.PnLat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_Lat");

                entity.Property(e => e.PnLong)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_Long");

                entity.Property(e => e.PnMode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_Mode");

                entity.Property(e => e.PnMotor)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_Motor");

                entity.Property(e => e.PnName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_Name");

                entity.Property(e => e.PnPedalBoardReversion)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_PedalBoardReversion");

                entity.Property(e => e.PnProp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_Prop");

                entity.Property(e => e.PnReconnect)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_Reconnect");

                entity.Property(e => e.PnRssi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_RSSI");

                entity.Property(e => e.PnRssiUtc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_RSSI_UTC");

                entity.Property(e => e.PnSog)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_SOG");

                entity.Property(e => e.PnStartLUtc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_StartL_UTC");

                entity.Property(e => e.PnStartUUtc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PN_StartU_UTC");

                entity.Property(e => e.ProNavGuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ProNav_GUID");

                entity.Property(e => e.SignalRReconnect)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SignalR_Reconnect");

                entity.Property(e => e.TimestampUtc)
                    .HasColumnType("datetime")
                    .HasColumnName("Timestamp_UTC");

                entity.Property(e => e.UniqueKey)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Unique_Key");

                entity.Property(e => e.WindGuid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Wind_GUID");

                entity.Property(e => e.WindName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Wind_Name");

                entity.Property(e => e.WindReconnect)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Wind_Reconnect");

                entity.Property(e => e.WindRssi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Wind_RSSI");

                entity.Property(e => e.WindRssiUtc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Wind_RSSI_UTC");

                entity.Property(e => e.WindTwd)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Wind_TWD");

                entity.Property(e => e.WindTws)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Wind_TWS");
            });

            modelBuilder.Entity<Logbuoy>(entity =>
            {
                entity.ToTable("LOGBUOY");

                entity.HasIndex(e => e.Buoyid, "IX_LOGBUOY_buoyid");

                entity.HasIndex(e => e.Orgid, "IX_LOGBUOY_orgid");

                entity.HasIndex(e => e.Timestamp, "IX_LOGBUOY_timestamp");

                entity.Property(e => e.Logbuoyid).HasColumnName("logbuoyid");

                entity.Property(e => e.Assetvalue)
                    .HasMaxLength(50)
                    .HasColumnName("assetvalue");

                entity.Property(e => e.Batteryah)
                    .HasMaxLength(50)
                    .HasColumnName("batteryah");

                entity.Property(e => e.Batterymonitorguid)
                    .HasMaxLength(50)
                    .HasColumnName("batterymonitorguid");

                entity.Property(e => e.Buoyid).HasColumnName("buoyid");

                entity.Property(e => e.Charging)
                    .HasMaxLength(50)
                    .HasColumnName("charging");

                entity.Property(e => e.Docklatlong)
                    .HasMaxLength(50)
                    .HasColumnName("docklatlong");

                entity.Property(e => e.Foreignsystemid)
                    .HasMaxLength(150)
                    .HasColumnName("foreignsystemid");

                entity.Property(e => e.Frameserial)
                    .HasMaxLength(50)
                    .HasColumnName("frameserial");

                entity.Property(e => e.Hardwareversion)
                    .HasMaxLength(50)
                    .HasColumnName("hardwareversion");

                entity.Property(e => e.Hull)
                    .HasMaxLength(50)
                    .HasColumnName("hull");

                entity.Property(e => e.Latlong)
                    .HasMaxLength(50)
                    .HasColumnName("latlong");

                entity.Property(e => e.Latlongtimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("latlongtimestamp");

                entity.Property(e => e.Monthlyfee)
                    .HasMaxLength(50)
                    .HasColumnName("monthlyfee");

                entity.Property(e => e.Motorfirstusagedate)
                    .HasColumnType("datetime")
                    .HasColumnName("motorfirstusagedate");

                entity.Property(e => e.Motormount)
                    .HasMaxLength(50)
                    .HasColumnName("motormount");

                entity.Property(e => e.Motorserial)
                    .HasMaxLength(50)
                    .HasColumnName("motorserial");

                entity.Property(e => e.Motortype)
                    .HasMaxLength(50)
                    .HasColumnName("motortype");

                entity.Property(e => e.Name)
                    .HasMaxLength(3)
                    .HasColumnName("name");

                entity.Property(e => e.Orgid).HasColumnName("orgid");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");

                entity.Property(e => e.Phoneimei)
                    .HasMaxLength(50)
                    .HasColumnName("phoneimei");

                entity.Property(e => e.Phonename)
                    .HasMaxLength(50)
                    .HasColumnName("phonename");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(50)
                    .HasColumnName("phonenumber");

                entity.Property(e => e.Phonepin)
                    .HasMaxLength(4)
                    .HasColumnName("phonepin");

                entity.Property(e => e.Pronavguid)
                    .HasMaxLength(50)
                    .HasColumnName("pronavguid");

                entity.Property(e => e.Pronavlower)
                    .HasMaxLength(50)
                    .HasColumnName("pronavlower");

                entity.Property(e => e.Pronavlowermount)
                    .HasMaxLength(50)
                    .HasColumnName("pronavlowermount");

                entity.Property(e => e.Pronavserial)
                    .HasMaxLength(50)
                    .HasColumnName("pronavserial");

                entity.Property(e => e.Pronavupper)
                    .HasMaxLength(50)
                    .HasColumnName("pronavupper");

                entity.Property(e => e.Pronavuppermount)
                    .HasMaxLength(50)
                    .HasColumnName("pronavuppermount");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .HasColumnName("role");

                entity.Property(e => e.Sailbotguid)
                    .HasMaxLength(50)
                    .HasColumnName("sailbotguid");

                entity.Property(e => e.Sailtimerguid)
                    .HasMaxLength(50)
                    .HasColumnName("sailtimerguid");

                entity.Property(e => e.Spinprevention)
                    .HasMaxLength(50)
                    .HasColumnName("spinprevention");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .HasColumnName("status");

                entity.Property(e => e.Switch)
                    .HasMaxLength(50)
                    .HasColumnName("switch");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("timestamp");

                entity.Property(e => e.Topside)
                    .HasMaxLength(50)
                    .HasColumnName("topside");

                entity.Property(e => e.Uniquekey)
                    .HasMaxLength(50)
                    .HasColumnName("uniquekey");

                entity.Property(e => e.Visible)
                    .HasMaxLength(10)
                    .HasColumnName("visible");

                entity.Property(e => e.Warrantyenddate)
                    .HasColumnType("datetime")
                    .HasColumnName("warrantyenddate");

                entity.Property(e => e.Waterproofing)
                    .HasMaxLength(50)
                    .HasColumnName("waterproofing");
            });

            modelBuilder.Entity<Logorg>(entity =>
            {
                entity.ToTable("LOGORG");

                entity.HasIndex(e => e.Orgid, "IX_LOGORG_orgid");

                entity.HasIndex(e => e.Timestamp, "IX_LOGORG_timestamp");

                entity.Property(e => e.Logorgid).HasColumnName("logorgid");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .HasColumnName("address");

                entity.Property(e => e.Bluetoothpassword).HasColumnName("bluetoothpassword");

                entity.Property(e => e.Emaillist)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("emaillist");

                entity.Property(e => e.Foreignsystemid)
                    .HasMaxLength(500)
                    .HasColumnName("foreignsystemid");

                entity.Property(e => e.Foreignsystempassword)
                    .HasMaxLength(500)
                    .HasColumnName("foreignsystempassword");

                entity.Property(e => e.Foreignsystemuserid)
                    .HasMaxLength(100)
                    .HasColumnName("foreignsystemuserid");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name");

                entity.Property(e => e.Networkmode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("networkmode");

                entity.Property(e => e.Networkoperator)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("networkoperator");

                entity.Property(e => e.Orgid).HasColumnName("orgid");

                entity.Property(e => e.Phonelist)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("phonelist");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("shortname");

                entity.Property(e => e.Supportamountperbot)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("supportamountperbot");

                entity.Property(e => e.Supportpayer)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("supportpayer");

                entity.Property(e => e.Supportpaymentinterval)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("supportpaymentinterval");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("timestamp");
            });

            modelBuilder.Entity<MigrationHistory>(entity =>
            {
                entity.HasKey(e => new { e.MigrationId, e.ContextKey })
                    .HasName("PK_dbo.__MigrationHistory");

                entity.ToTable("__MigrationHistory");

                entity.Property(e => e.MigrationId).HasMaxLength(150);

                entity.Property(e => e.ContextKey).HasMaxLength(300);

                entity.Property(e => e.ProductVersion).HasMaxLength(32);
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.ToTable("NOTE");

                entity.HasIndex(e => e.Buoyid, "IX_NOTE_buoyid");

                entity.HasIndex(e => e.Orgid, "IX_NOTE_orgid");

                entity.HasIndex(e => e.Timestamp, "IX_NOTE_timestamp");

                entity.Property(e => e.Noteid).HasColumnName("noteid");

                entity.Property(e => e.Buoyid).HasColumnName("buoyid");

                entity.Property(e => e.Component)
                    .HasMaxLength(50)
                    .HasColumnName("component");

                entity.Property(e => e.Componentserial)
                    .HasMaxLength(50)
                    .HasColumnName("componentserial");

                entity.Property(e => e.Note1)
                    .HasMaxLength(4000)
                    .HasColumnName("note");

                entity.Property(e => e.Orgid).HasColumnName("orgid");

                entity.Property(e => e.Phonename)
                    .HasMaxLength(50)
                    .HasColumnName("phonename");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");

                entity.Property(e => e.Timestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("timestamp");

                entity.Property(e => e.Type)
                    .HasMaxLength(50)
                    .HasColumnName("type");

                entity.Property(e => e.Userid)
                    .HasMaxLength(256)
                    .HasColumnName("userid");
            });

            modelBuilder.Entity<Org>(entity =>
            {
                entity.ToTable("ORG");

                entity.Property(e => e.Orgid).HasColumnName("orgid");

                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .HasColumnName("address");

                entity.Property(e => e.Bluetoothpassword).HasColumnName("bluetoothpassword");

                entity.Property(e => e.Docklatlong)
                    .HasMaxLength(50)
                    .HasColumnName("docklatlong");

                entity.Property(e => e.Emaillist)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("emaillist");

                entity.Property(e => e.Foreignsystemid)
                    .HasMaxLength(500)
                    .HasColumnName("foreignsystemid");

                entity.Property(e => e.Foreignsystempassword)
                    .HasMaxLength(500)
                    .HasColumnName("foreignsystempassword");

                entity.Property(e => e.Foreignsystemuserid)
                    .HasMaxLength(100)
                    .HasColumnName("foreignsystemuserid");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name");

                entity.Property(e => e.Networkmode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("networkmode");

                entity.Property(e => e.Networkoperator)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("networkoperator");

                entity.Property(e => e.Networkoperators)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("networkoperators");

                entity.Property(e => e.Phonelist)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("phonelist");

                entity.Property(e => e.Shortname)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("shortname");

                entity.Property(e => e.Supportamountperbot)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("supportamountperbot");

                entity.Property(e => e.Supportpayer)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("supportpayer");

                entity.Property(e => e.Supportpaymentinterval)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("supportpaymentinterval");

                entity.Property(e => e.Waypointlist)
                    .HasColumnType("text")
                    .HasColumnName("waypointlist");
            });

            modelBuilder.Entity<Orguser>(entity =>
            {
                entity.ToTable("ORGUSER");

                entity.Property(e => e.Orguserid).HasColumnName("orguserid");

                entity.Property(e => e.Aspnetusersid)
                    .HasMaxLength(128)
                    .HasColumnName("aspnetusersid");

                entity.Property(e => e.Defaultorg)
                    .IsRequired()
                    .HasColumnName("defaultorg")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Orgid).HasColumnName("orgid");
            });

            modelBuilder.Entity<Version>(entity =>
            {
                entity.ToTable("VERSION");

                entity.Property(e => e.Versionid).HasColumnName("versionid");

                entity.Property(e => e.Parentvalue)
                    .HasMaxLength(50)
                    .HasColumnName("parentvalue");

                entity.Property(e => e.Text)
                    .HasMaxLength(150)
                    .HasColumnName("text");

                entity.Property(e => e.Value)
                    .HasMaxLength(50)
                    .HasColumnName("value");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DLS_WebAPI.Entites;

public partial class DlDbContext : DbContext
{
    public DlDbContext()
    {
    }

    public DlDbContext(DbContextOptions<DlDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CompanyInfo> CompanyInfos { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=10.11.201.76;port=3306;database=dl_db;user id=dldadm;password=Dld@Adm", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<CompanyInfo>(entity =>
        {
            entity.HasKey(e => e.CompanyCode).HasName("PRIMARY");

            entity.ToTable("company_info");

            entity.Property(e => e.CompanyCode)
                .ValueGeneratedNever()
                .HasColumnName("company_code");
            entity.Property(e => e.Address)
                .HasMaxLength(256)
                .HasColumnName("address");
            entity.Property(e => e.BinImageName)
                .HasMaxLength(256)
                .HasColumnName("bin_image_name");
            entity.Property(e => e.BinNo)
                .HasMaxLength(64)
                .HasColumnName("bin_no");
            entity.Property(e => e.CompanyInfocol)
                .HasMaxLength(45)
                .HasColumnName("company_infocol");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(256)
                .HasColumnName("company_name");
            entity.Property(e => e.CompanyType)
                .HasMaxLength(16)
                .HasColumnName("company_type");
            entity.Property(e => e.ContactPersonEmail)
                .HasMaxLength(128)
                .HasColumnName("contact_person_email");
            entity.Property(e => e.ContactPersonName)
                .HasMaxLength(128)
                .HasColumnName("contact_person_name");
            entity.Property(e => e.ContactPersonPhone)
                .HasMaxLength(16)
                .HasColumnName("contact_person_phone");
            entity.Property(e => e.Description)
                .HasMaxLength(4000)
                .HasColumnName("description");
            entity.Property(e => e.EstablishedOn).HasColumnName("established_on");
            entity.Property(e => e.GroupCode)
                .HasMaxLength(4)
                .HasColumnName("group_code");
            entity.Property(e => e.InsertBy)
                .HasMaxLength(16)
                .HasColumnName("insert_by");
            entity.Property(e => e.InsertDate).HasColumnName("insert_date");
            entity.Property(e => e.Logo)
                .HasMaxLength(128)
                .HasColumnName("logo");
            entity.Property(e => e.OfficeEmail)
                .HasMaxLength(128)
                .HasColumnName("office_email");
            entity.Property(e => e.OfficePhone)
                .HasMaxLength(16)
                .HasColumnName("office_phone");
            entity.Property(e => e.TinImageName)
                .HasMaxLength(256)
                .HasColumnName("tin_image_name");
            entity.Property(e => e.TinNo)
                .HasMaxLength(64)
                .HasColumnName("tin_no");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDate).HasColumnName("update_date");
            entity.Property(e => e.VatImageName)
                .HasMaxLength(256)
                .HasColumnName("vat_image_name");
            entity.Property(e => e.VatNo)
                .HasMaxLength(64)
                .HasColumnName("vat_no");
            entity.Property(e => e.WebsiteUrl)
                .HasMaxLength(256)
                .HasColumnName("website_url");
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("test");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("user_info", tb => tb.HasComment("users sign up info with user id and password"));

            entity.HasIndex(e => e.CompanyCode, "fk_user_info_company_info");

            entity.HasIndex(e => e.UserId, "unq_sign_up").IsUnique();

            entity.Property(e => e.Bin)
                .HasMaxLength(128)
                .HasColumnName("bin");
            entity.Property(e => e.BusinessType)
                .HasMaxLength(16)
                .HasColumnName("business_type");
            entity.Property(e => e.CompanyCode).HasColumnName("company_code");
            entity.Property(e => e.ContactPersonEmail)
                .HasMaxLength(128)
                .HasColumnName("contact_person_email");
            entity.Property(e => e.ContactPersonName)
                .HasMaxLength(256)
                .HasColumnName("contact_person_name");
            entity.Property(e => e.ContactPersonPhone)
                .HasMaxLength(16)
                .HasColumnName("contact_person_phone");
            entity.Property(e => e.Department)
                .HasMaxLength(16)
                .HasColumnName("department");
            entity.Property(e => e.Designation)
                .HasMaxLength(16)
                .HasColumnName("designation");
            entity.Property(e => e.EstablishedOn).HasColumnName("established_on");
            entity.Property(e => e.InsertBy)
                .HasMaxLength(16)
                .HasColumnName("insert_by");
            entity.Property(e => e.InsertDate)
                .HasDefaultValueSql("now()")
                .HasColumnType("datetime")
                .HasColumnName("insert_date");
            entity.Property(e => e.NoOfEmployee).HasColumnName("no_of_employee");
            entity.Property(e => e.OfficeAddress)
                .HasMaxLength(512)
                .HasColumnName("office_address");
            entity.Property(e => e.OfficeEmail)
                .HasMaxLength(128)
                .HasColumnName("office_email");
            entity.Property(e => e.OfficePhoneNumber)
                .HasMaxLength(16)
                .HasColumnName("office_phone_number");
            entity.Property(e => e.OrganisationName)
                .HasMaxLength(128)
                .HasColumnName("organisation_name");
            entity.Property(e => e.PasswordHash)
                .HasColumnType("blob")
                .HasColumnName("password_hash");
            entity.Property(e => e.PasswordSalt)
                .HasColumnType("blob")
                .HasColumnName("password_salt");
            entity.Property(e => e.Tin)
                .HasMaxLength(128)
                .HasColumnName("tin");
            entity.Property(e => e.UpdateBy)
                .HasMaxLength(16)
                .HasColumnName("update_by");
            entity.Property(e => e.UpdateDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasColumnType("datetime")
                .HasColumnName("update_date");
            entity.Property(e => e.UserId)
                .HasMaxLength(64)
                .HasColumnName("user_id");
            entity.Property(e => e.UserPermanentAdr)
                .HasMaxLength(512)
                .HasColumnName("user_permanent_adr");
            entity.Property(e => e.UserPhoneNumber)
                .HasMaxLength(16)
                .HasColumnName("user_phone_number");
            entity.Property(e => e.UserPresentAdr)
                .HasMaxLength(512)
                .HasColumnName("user_present_adr");
            entity.Property(e => e.UserType)
                .HasMaxLength(16)
                .HasColumnName("user_type");
            entity.Property(e => e.VatNumber)
                .HasMaxLength(128)
                .HasColumnName("vat_number");
            entity.Property(e => e.WebsiteAddress)
                .HasMaxLength(256)
                .HasColumnName("website_address");

            entity.HasOne(d => d.CompanyCodeNavigation).WithMany()
                .HasForeignKey(d => d.CompanyCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_user_info_company_info");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

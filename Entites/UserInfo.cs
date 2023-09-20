using System;
using System.Collections.Generic;

namespace DLS_WebAPI.Entites;

/// <summary>
/// users sign up info with user id and password
/// </summary>
public partial class UserInfo
{
    public int CompanyCode { get; set; }

    public string UserId { get; set; } = null!;

    public byte[]? PasswordHash { get; set; }

    public byte[]? PasswordSalt { get; set; }

    public string? UserType { get; set; }

    public string? UserPhoneNumber { get; set; }

    public string? Designation { get; set; }

    public string? Department { get; set; }

    public string? OrganisationName { get; set; }

    public string? OfficeAddress { get; set; }

    public DateOnly? EstablishedOn { get; set; }

    public string? OfficeEmail { get; set; }

    public string? OfficePhoneNumber { get; set; }

    public string? WebsiteAddress { get; set; }

    public string? ContactPersonName { get; set; }

    public string? ContactPersonPhone { get; set; }

    public string? ContactPersonEmail { get; set; }

    public string? Bin { get; set; }

    public string? Tin { get; set; }

    public string? VatNumber { get; set; }

    public int? NoOfEmployee { get; set; }

    public string? UserPermanentAdr { get; set; }

    public string? UserPresentAdr { get; set; }

    public string? BusinessType { get; set; }

    public string? InsertBy { get; set; }

    public DateTime? InsertDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public string? UpdateBy { get; set; }

    public virtual CompanyInfo CompanyCodeNavigation { get; set; } = null!;
}

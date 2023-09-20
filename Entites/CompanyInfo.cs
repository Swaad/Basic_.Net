using System;
using System.Collections.Generic;

namespace DLS_WebAPI.Entites;

public partial class CompanyInfo
{
    public int CompanyCode { get; set; }

    public string? CompanyName { get; set; }

    public string? GroupCode { get; set; }

    public string? CompanyType { get; set; }

    public string? Address { get; set; }

    public string? OfficeEmail { get; set; }

    public string? OfficePhone { get; set; }

    public string? ContactPersonName { get; set; }

    public string? ContactPersonPhone { get; set; }

    public string? ContactPersonEmail { get; set; }

    public string? InsertBy { get; set; }

    public DateOnly? InsertDate { get; set; }

    public string? UpdateBy { get; set; }

    public DateOnly? UpdateDate { get; set; }

    public DateOnly? EstablishedOn { get; set; }

    public string? BinNo { get; set; }

    public string? BinImageName { get; set; }

    public string? TinNo { get; set; }

    public string? TinImageName { get; set; }

    public string? VatNo { get; set; }

    public string? VatImageName { get; set; }

    public string? Description { get; set; }

    public string? WebsiteUrl { get; set; }

    public string? Logo { get; set; }

    public string? CompanyInfocol { get; set; }
}

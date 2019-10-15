using System;

public class GlobalStatus : BaseEntity, ITimeTrack
{
    public string StatusFrom  { get; set; }
    // public string ThridPartyId{get;set;}
    // public int ThridPraty{get;set;}
    // public string Address { get; set; }
    // public decimal Price { get; set; }
    // public int RentCount { get; set; }
    // public int SellCount { get; set; }
    // public int SeeCountRecentThirtyDays { get; set; }
    public int TotalCommunityCount {get;set;}
    public long CreateTime {get; set; }
    public long ModifiedTime {get; set; }
}
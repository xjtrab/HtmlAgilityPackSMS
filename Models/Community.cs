using System;


public class Community : BaseEntity, ITimeTrack
{
    public string Name { get; set; }
    public string ThridPartyId { get; set; }
    public int ThridPraty { get; set; }
    public string Address { get; set; }
    public decimal Price { get; set; }
    public int RentingCount { get; set; }
    public int SellingCount { get; set; }
    public int SelledOutLastMonth { get; set; }
    public int SeeCountRecentThirtyDays { get; set; }
    public long CreateTime { get; set; } = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
    public long ModifiedTime { get; set; }
    public int UnitId { get; set; }
}
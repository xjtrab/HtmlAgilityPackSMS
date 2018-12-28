public class Community : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public decimal Price { get; set; }
    public int RentCount { get; set; }
    public int SellCount { get; set; }
    public int SeeCountRecentThirtyDays { get; set; }
}
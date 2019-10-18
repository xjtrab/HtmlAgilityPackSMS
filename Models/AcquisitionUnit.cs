using System;
public class AcquisitionUnit : BaseEntity, ITimeTrack
{
    public EnumAcquisitionUnit Result { get; set; }
    public string Info { get; set; } 
    public long CreateTime{ get; set; } = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds(); 
    public long ModifiedTime { get; set; }
}
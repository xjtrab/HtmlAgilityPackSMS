using System;

public class SMSRawData : BaseEntity, ITimeTrack
{
    public string Request { get; set; }
    public string Response { get; set; }
    public int ResponseCode { get; set; }
    public long CreateTime { get; set; }
    public long ModifiedTime { get; set; }
}
using System;

public class SMSRawData : BaseEntity
{
    public string Request { get; set; }
    public string Response { get; set; }
    public int ResponseCode { get; set; }
    public DateTime SendTime { get; set; }

}
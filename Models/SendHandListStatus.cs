using System;

public class SendHandListStatus : BaseEntity ,ITimeTrack
{
    public int Total { get; set; }
    public long CreateTime { get; set; }
    public long ModifiedTime { get; set; }
}
using System;

public interface ITimeTrack
{
     DateTime CreateTime { get; set; }
     DateTime ModifiedTime { get; set; }
}
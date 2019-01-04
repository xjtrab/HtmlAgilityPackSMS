using System;

public interface ITimeTrack
{
     long CreateTime { get; set; }
     long ModifiedTime { get; set; }
}
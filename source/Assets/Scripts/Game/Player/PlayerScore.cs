using System;
using System.Xml.Serialization;

/// <summary>
/// A class to hold players's points.
/// </summary>
public class PlayerScore 
{
	public string Name { get; set; }

	public int Score { get; set; }

	public string Data
	{
		get
		{
			return string.Format("{0}|{1}", Name, Score);
		}
	}
}
using System;

namespace ChordAPI.Models;

public class Chord
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty; // e.g., "C Major", "G7", "D Minor"

    public string FingerPosition { get; set; } = string.Empty; //  e.g., "x32010" for C Major

    public string Tuning { get; set; } = "EADGBE"; // Default standard tuning

    public string? Notes { get; set; } // e.g., "C,E,G" for C Major
}


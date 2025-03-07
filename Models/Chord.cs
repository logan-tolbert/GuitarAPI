namespace GuitarAPI.Models;

    public class Chord
    {
    public int Id {get;set;}
    public string Name {get;set;} = string.Empty;
    public string FingerPlacement{get;set;} = string.Empty;
    public string Tuning {get;set;} = string.Empty;
    public string? Notes {get; set;}

    }

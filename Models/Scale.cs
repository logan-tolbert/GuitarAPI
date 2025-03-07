namespace GuitarAPI.Models;

    public class Scale
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Key { get; set; } = string.Empty;
        public string? Notes {get;set;}
    }

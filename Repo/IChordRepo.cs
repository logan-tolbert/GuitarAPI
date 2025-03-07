using GuitarAPI.Models;

namespace GuitarAPI.Repo;

public interface IChordRepo
{
    Task AddChordAsync(Chord chord);
    Task<IEnumerable<Chord>> GetAllAsync();
    Task<Chord?> GetChordByNameAsync(string name);
}
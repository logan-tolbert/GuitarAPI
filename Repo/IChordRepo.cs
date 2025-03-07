using GuitarAPI.Models;

namespace GuitarAPI.Repo;

public interface IChordRepo
{
    Task CreateAsync(Chord chord);
    Task<IEnumerable<Chord>> GetAllAsync();
    Task<Chord?> GetByNameAsync(string name);
}
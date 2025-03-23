using System;
using ChordAPI.Models;

namespace ChordAPI.Data.Repository;

public interface IChordRepo
{
    Task CreateAsync(Chord chord);
    Task<IEnumerable<Chord>> GetAllAsync();
    Task<Chord?> GetByNameAsync(string name);
}

using System;
using ChordAPI.Data.Repository;
using ChordAPI.Models;

namespace ChordAPI.Services;

public class ChordService
{
    private readonly IChordRepo _repo;
    public ChordService(IChordRepo repo)
    {
        _repo = repo;
    }
    public async Task CreateAsync(Chord chord)
    {
        await _repo.CreateAsync(chord);
    }
    public async Task<IEnumerable<Chord>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<Chord> GetByNameAsync(string name)
    {
        var chord = await _repo.GetByNameAsync(name);

        if (chord == null)
        {
            throw new KeyNotFoundException($"Chord with name '{name}' not found.");
        }

        return chord;
    }
}

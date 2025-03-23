using System;
using ScaleAPI.Data.Repository;
using ScaleAPI.Models;

namespace ScaleAPI.Services;

public class ScaleService(IScaleRepo repo)
{
    private readonly IScaleRepo _repo = repo;

    public async Task CreateAsync(Scale scale)
    {
        await _repo.CreateAsync(scale);
    }
    public async Task<IEnumerable<Scale>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }

    public async Task<Scale> GetByNameAsync(string name)
    {
        var chord = await _repo.GetByNameAsync(name) ??
            throw new KeyNotFoundException($"Scale with name '{name}' not found.");

        return chord;
    }
}

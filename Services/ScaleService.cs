using GuitarAPI.Models;
using GuitarAPI.Repo;

namespace GuitarAPI.Services;

public class ScaleService
{

    private readonly IScaleRepo _repo;
    public ScaleService(IScaleRepo repo)
    {
        _repo = repo;
    }
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
        var scale = await _repo.GetByNameAsync(name);

        if (scale == null)
        {
            throw new KeyNotFoundException($"Scale with name '{name}' not found.");
        }

        return scale;
    }
}

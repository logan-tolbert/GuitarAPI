using ScaleAPI.Models;

namespace ScaleAPI.Data.Repository;
public interface IScaleRepo
{
    Task CreateAsync(Scale scale);
    Task<IEnumerable<Scale>> GetAllAsync();
    Task<Scale?> GetByNameAsync(string name);
}

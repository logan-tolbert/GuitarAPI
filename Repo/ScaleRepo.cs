
using GuitarAPI.Data.Context;
using GuitarAPI.Models;

namespace GuitarAPI.Repo;

public class ScaleRepo : IScaleRepo
{
    private readonly ISqlDbContext _db;

    public ScaleRepo(ISqlDbContext db)
    {
        _db = db;
    }
    public async Task CreateAsync(Scale scale)
    {
        var sql = @"INSERT INTO Scales
                (Name, Key, Notes)
                VALUES
                (@Name, @Key, @Notes);";

        await _db.SaveDataAsync<dynamic, dynamic>(sql, scale);
    }

    public async Task<IEnumerable<Scale>> GetAllAsync()
    {
        var sql = @"SELECT * FROM Scales;";

        return await _db.LoadDataAsync<Scale, dynamic>(sql, new { });
    }

    public async Task<Scale?> GetByNameAsync(string name)
    {
        string sql = @"SELECT * FROM Scales WHERE Name = @Name;";

        var result = await _db.LoadDataAsync<Scale, dynamic>(sql, new { Name = name });

        return result.FirstOrDefault();
    }
}

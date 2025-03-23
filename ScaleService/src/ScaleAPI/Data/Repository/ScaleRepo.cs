using System;
using ScaleAPI.Data.Access;
using ScaleAPI.Models;

namespace ScaleAPI.Data.Repository;

public class ScaleRepo(IDapperDbContext db) : IScaleRepo
{
    private readonly IDapperDbContext _db = db;

    public async Task CreateAsync(Scale scale)
    {
        var sql = @"INSERT INTO Scales 
                    (Name, ScaleKey, Tuning, Notes)
                    VALUES
                    (@Name, @ScaleKey, @Tuning, @Notes);";

        await _db.SaveDataAsync<dynamic, dynamic>(sql, scale);
    }
    public async Task<IEnumerable<Scale>> GetAllAsync()
    {
        var sql = @"Select * FROM Scales;";

        return await _db.LoadDataAsync<Scale, dynamic>(sql, new { });
    }

    public async Task<Scale?> GetByNameAsync(string name)
    {
        string sql = @"SELECT * FROM Scales WHERE Name = @Name;";

        var result = await _db.LoadDataAsync<Scale, dynamic>(sql, new { Name = name });

        return result.FirstOrDefault();
    }
}

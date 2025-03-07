using GuitarAPI.Data.Context;
using GuitarAPI.Models;

namespace GuitarAPI.Repo;



public class ChordRepo : IChordRepo
{
    private readonly ISqlDbContext _db;

    public ChordRepo(ISqlDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Chord>> GetAllAsync()
    {
        var sql = @"Select * FROM Chords;";

        return await _db.LoadDataAsync<Chord, dynamic>(sql, new { });
    }

    public async Task<Chord?> GetChordByNameAsync(string name)
    {
        string sql = @"SELECT * FROM Chords WHERE Name = @Name;";
        var result = await _db.LoadDataAsync<Chord, dynamic>(sql, new { Name = name });
        return result.FirstOrDefault();
    }

    public async Task AddChordAsync(Chord chord)
    {
        string sql = @"INSERT INTO Chords 
                    (Name, FingerPlacement, Tuning, Noted)
                    VALUES
                    (@Name, @FingerPlacement, @Tuning, @Notes);";
        await _db.SaveDataAsync<dynamic, dynamic>(sql, chord);
    }
}

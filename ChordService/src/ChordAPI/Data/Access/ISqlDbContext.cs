using System;

namespace ChordAPI.Data.Access;

public interface ISqlDbContext
{
    Task<IEnumerable<T>> LoadDataAsync<T, U>(string sqlStatement, U parameters, string connectionName = "Default", bool isStoredProcedure = false);
    Task SaveDataAsync<T, U>(string sqlStatement, U parameters, string connectionName = "Default", bool isStoredProcedure = false);
}

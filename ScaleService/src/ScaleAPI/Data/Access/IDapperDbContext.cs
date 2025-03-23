using System;

namespace ScaleAPI.Data.Access;

public interface IDapperDbContext
{
    Task<IEnumerable<T>> LoadDataAsync<T, U>(string sqlStatement, U parameters, string connectionName = "Default", bool isStoredProcedure = false);
    Task SaveDataAsync<T, U>(string sqlStatement, U parameters, string connectionName = "Default", bool isStoredProcedure = false);
}

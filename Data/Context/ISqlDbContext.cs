namespace GuitarAPI.Data.Context;

public interface ISqlDbContext
{
    Task<IEnumerable<T>> LoadDataAsync<T, U>(string sqlStatement, U parameters, string connectionName = "Default", bool isStoredProcedure = false);
    IEnumerable<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionName = "Default", bool isStoredProcedure = false);
    Task SaveDataAsync<T, U>(string sqlStatement, U parameters, string connectionName = "Default", bool isStoredProcedure = false);
    void SaveData<T, U>(string sqlStatement, U parameters, string connectionName = "Default", bool isStoredProcedure = false);
}

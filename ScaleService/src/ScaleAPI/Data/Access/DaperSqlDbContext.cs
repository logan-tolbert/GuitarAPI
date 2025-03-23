using System;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;

namespace ScaleAPI.Data.Access;

public class DaperSqlDbContext(IConfiguration config) : IDapperDbContext
{
    private readonly IConfiguration _config = config;

    public async Task<IEnumerable<T>> LoadDataAsync<T, U>(string sqlStatement, U parameters, string connectionName = "Default", bool isStoredProcedure = false)
    {
        string connectionString = _config.GetConnectionString(connectionName)!;
        CommandType commandType = CommandType.Text;

        if (isStoredProcedure == true)
        {
            commandType = CommandType.StoredProcedure;
        }

        using IDbConnection connection = new SqlConnection(connectionString);

        IEnumerable<T> rows = await connection.QueryAsync<T>(sqlStatement, parameters, commandType: commandType);

        return rows;
    }

    public async Task SaveDataAsync<T, U>(string sqlStatement, U parameters, string connectionName = "Default", bool isStoredProcedure = false)
    {
        string connectionString = _config.GetConnectionString(connectionName)!;

        CommandType commandType = CommandType.Text;

        if (isStoredProcedure == true)
        {
            commandType = CommandType.StoredProcedure;
        }

        using IDbConnection connection = new SqlConnection(connectionString);

        await connection.ExecuteAsync(sqlStatement, parameters,
        commandType: commandType);
    }
}

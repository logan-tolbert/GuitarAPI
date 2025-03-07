using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Threading.Tasks;

namespace GuitarAPI.Data.Context;


public class SqlDbContext : ISqlDbContext
{
    private readonly IConfiguration _config;

    public SqlDbContext(IConfiguration config)
    {
        _config = config;
    }

    public IEnumerable<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionName = "Default", bool isStoredProcedure = false)
    {
        string connectionString = _config.GetConnectionString(connectionName)!;
        CommandType commandType = CommandType.Text;

        if (isStoredProcedure == true)
        {
            commandType = CommandType.StoredProcedure;
        }

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            IEnumerable<T> rows = connection.Query<T>(sqlStatement, parameters, commandType: commandType).ToList();
            return rows;
        }
    }

    public async Task<IEnumerable<T>> LoadDataAsync<T, U>(string sqlStatement, U parameters, string connectionName = "Default", bool isStoredProcedure = false)
    {
        string connectionString = _config.GetConnectionString(connectionName)!;
        CommandType commandType = CommandType.Text;

        if (isStoredProcedure == true)
        {
            commandType = CommandType.StoredProcedure;
        }

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            IEnumerable<T> rows = await connection.QueryAsync<T>(sqlStatement, parameters, commandType: commandType);
            return rows;
        }
    }

    public void SaveData<T, U>(string sqlStatement, U parameters, string connectionName = "Default", bool isStoredProcedure = false)
    {
        string connectionString = _config.GetConnectionString(connectionName)!;

        CommandType commandType = CommandType.Text;

        if (isStoredProcedure == true)
        {
            commandType = CommandType.StoredProcedure;
        }

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            connection.Execute(sqlStatement, parameters, commandType: commandType);
        }
    }

    public async Task SaveDataAsync<T, U>(string sqlStatement, U parameters, string connectionName = "Default", bool isStoredProcedure = false)
    {
        string connectionString = _config.GetConnectionString(connectionName)!;

        CommandType commandType = CommandType.Text;

        if (isStoredProcedure == true)
        {
            commandType = CommandType.StoredProcedure;
        }

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            await connection.ExecuteAsync(sqlStatement, parameters, commandType: commandType);
        }
    }
}
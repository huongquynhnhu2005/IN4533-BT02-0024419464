using Npgsql;

namespace EduHubApi.Data;

public static class Db
{
    public static NpgsqlDataSource CreateDataSource(string connectionString)
    {
        return NpgsqlDataSource.Create(connectionString);
    }
}
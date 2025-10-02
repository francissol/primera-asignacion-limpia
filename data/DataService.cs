using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using primeraasignacionlimpia.models;

public class DataService
{
    private readonly string _connectionString;

    public DataService(string connectionString)
    {
        _connectionString = connectionString;
    }

    private SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }

    public Persona GetPersona()
    {
        using var conn = GetConnection();
        return conn.QueryFirstOrDefault<Persona>("SELECT * FROM Persona");
    }

    public List<Hobbies> GetHobbies()
    {
        using var conn = GetConnection();
        return conn.Query<Hobbies>("SELECT * FROM Hobbies").AsList();
    }

    public List<Series> GetSeries()
    {
        using var conn = GetConnection();
        return conn.Query<Series>("SELECT * FROM Series").AsList();
    }

    public List<Familia> GetFamilia()
    {
        using var conn = GetConnection();
        return conn.Query<Familia>("SELECT * FROM Familia").AsList();
    }

    public List<youtubers> GetYoutubers()
    {
        using var conn = GetConnection();
        return conn.Query<youtubers>("SELECT * FROM Youtubers").AsList();
    }
}

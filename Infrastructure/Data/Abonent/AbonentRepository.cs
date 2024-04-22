using Dapper;
using Data.Context;
using Data.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Data.Abonent;

public class AbonentRepository : IAbonentRepository
{
    public required SqliteConnection Connection { get; init; }
    
    public AbonentRepository()
    {
        Connection = new SqliteConnection("Data Source=sample;Mode=Memory;Cache=Shared");
        Connection.Open();
    }
    
    public async Task<IEnumerable<GetAbonents>> GetAbonentList()
    {
        var result = await Connection.QueryAsync<GetAbonents>(
            "select ab.id as Id, " +
            "(ab.first_name || ' ' + ab.last_name || ' ' || ab.patronymic) as Fullname, " +
            "(ra.country || ', ' + ra.town || ', ' || ra.street || ', ' || ra.house) as Address " +
            "from re_abonents ab " +
            "join re_addresses ra on ab.id = ra.abonent_id " +
            "join re_phone_numbers rpn on ab.id = rpn.abonent_id");
        
        return result;
    }
 
    /*public async Task<Core.Model.Abonent?> GetAbonent(int id)
    {
        return await Connection.Abonents.FindAsync(id);
    }*/
}
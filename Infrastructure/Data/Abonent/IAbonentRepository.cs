using Data.Models;

namespace Data.Abonent;

public interface IAbonentRepository
{
    Task<IEnumerable<GetAbonents>> GetAbonentList();

    // Task<Core.Model.Abonent?> GetAbonent(int id);
}
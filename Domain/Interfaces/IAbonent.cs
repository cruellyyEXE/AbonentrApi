using Core.Model;

namespace Interfaces;

public interface IAbonent : IDisposable
{
    IEnumerable<Abonent> GetAbonents();

    Abonent GetAbonent(long id);
}
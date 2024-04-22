using Core.Model;
using Data.Abonent;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[AllowAnonymous]
[Route("api/abonent")]
public class AbonentController(IAbonentRepository abonent) : Controller
{
    public async Task<IEnumerable<GetAbonents?>> GetAbonents()
    {
        return await abonent.GetAbonentList();
    } 
}
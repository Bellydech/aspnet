using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mondial.DotNet.Web.Models;
using Mondial.DotNet.Library.Models;
using Mondial.DotNet.Library.Repositories.InMemory;
using Mondial.DotNet.Library.Repositories.Interfaces;
using System.Dynamic;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Mondial.DotNet.Web.Controllers.Base;

namespace Mondial.DotNet.Web.Controllers
{
    public class MapController : BaseDataController
    {
         public MapController(IContractRepository contractRepository, IPlayerRepository playerRepository, ITeamRepository teamRepository) : base(contractRepository, playerRepository, teamRepository)
        {

        }

        public IActionResult Index() => View(_teamRepository.GetAll()
                .Select(team => new { team.Name, team.Flag, team.Latitude, team.Longitude, team.Address, contracts = team.ContractCollection.OrderBy(contract => contract.YearFrom).Join(
                    _playerRepository.GetAll(), contract => contract.Signatory, player => player,
                    (contract, player) => new {yearFrom = contract.YearFrom, yearTo = contract.YearTo, lastname = player.LastName, firstname = player.FirstName}.ToExpando())
                    }.ToExpando()));
    }

    public static class Extensions
    {
        public static ExpandoObject ToExpando(this object anonymousObject)
        {
            IDictionary<string, object> anonymousDictionary = HtmlHelper.AnonymousObjectToHtmlAttributes(anonymousObject);
            IDictionary<string, object> expando = new ExpandoObject();
            foreach (var item in anonymousDictionary)
                expando.Add(item);
            return (ExpandoObject)expando;
        }
    }
}
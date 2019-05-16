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
using Mondial.DotNet.Web.Controllers.Base;
using System.Dynamic;

namespace Mondial.DotNet.Web.Controllers
{
    public class APIController : BaseDataController
    {

         public APIController(IContractRepository contractRepository, IPlayerRepository playerRepository, ITeamRepository teamRepository): base(contractRepository, playerRepository, teamRepository)
        {

        }

        [HttpGet]
        [Route("api/TeamsContractsDetails")]
        public JsonResult Test()
        {
            var allDyn = _teamRepository.GetAll()
                .Select(team => new { team.Name, team.Address, team.Latitude, team.Longitude, contracts = team.ContractCollection.OrderBy(contract => contract.YearFrom).Join(
                    _playerRepository.GetAll(), contract => contract.Signatory, player => player,
                    (contract, player) => new {contract.Id, contract.YearFrom, contract.YearTo, player = player.ToDynamic()})
                    })
                .ToList();
            return Json(allDyn);
        }

    }
}
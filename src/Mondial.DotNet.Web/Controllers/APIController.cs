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

namespace Mondial.DotNet.Web.Controllers
{
    public class APIController : Controller
    {
        protected readonly IContractRepository _contractRepository;
        protected readonly IPlayerRepository _playerRepository;
        protected readonly ITeamRepository _teamRepository;

         public APIController(IContractRepository contractRepository, IPlayerRepository playerRepository, ITeamRepository teamRepository)
        {
            _contractRepository = contractRepository;
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
        }

        [HttpGet]
        [Route("api/dev/test")]
        public virtual JsonResult Test()
        {
            var allDyn = _teamRepository.GetAll()
                .Select(team => new { team.Name, contracts = team.ContractCollection.OrderBy(contract => contract.YearFrom).Join(
                    _playerRepository.GetAll(), contract => contract.Signatory, player => player,
                    (contract, player) => new {yearfrom = contract.YearFrom, yearTo = contract.YearTo, lastname = player.LastName})
                    })
                .ToList();
            return Json(allDyn);
        }

    }
}
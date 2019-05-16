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

namespace Mondial.DotNet.Web.Controllers.Base
{
    public class BaseDataController : Controller
    {
        protected readonly IContractRepository _contractRepository;
        protected readonly IPlayerRepository _playerRepository;
        protected readonly ITeamRepository _teamRepository;

         public BaseDataController(IContractRepository contractRepository, IPlayerRepository playerRepository, ITeamRepository teamRepository)
        {
            _contractRepository = contractRepository;
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
        }
    }
}
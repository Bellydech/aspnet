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

namespace Mondial.DotNet.Web.Controllers
{
    public class TeamController : BaseController<Team, ITeamRepository>
    {

        public TeamController(ITeamRepository repository) : base(repository)
        {
            
        }

        public override IActionResult Index() => View(Repository.GetAll().OrderBy(team => team.Name));
    }
}
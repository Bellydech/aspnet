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

namespace Mondial.DotNet.Web.Controllers
{
    public class ContractController : BaseController<Contract, IContractRepository>
    {

        public ContractController(IContractRepository repository) : base(repository)
        {
            
        }
    }
}
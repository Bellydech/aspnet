using System.Linq;
using Mondial.DotNet.Library.Context;
using Mondial.DotNet.Library.Models;
using Mondial.DotNet.Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mondial.DotNet.Library.Repositories.Db
{
    public class DbContextContractRepository : BaseDbRepository<Contract>, IContractRepository
    {
        public DbContextContractRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public override IQueryable<Contract> Includes(IQueryable<Contract> includes)
        {
            var inc = base.Includes(includes);
            inc = inc
                .Include(c => c.Signatory)
                .Include(c => c.Employer);
            return inc;
        }
    }
}
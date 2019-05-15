using System.Linq;
using Mondial.DotNet.Library.Context;
using Mondial.DotNet.Library.Models;
using Mondial.DotNet.Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mondial.DotNet.Library.Repositories.Db
{
    public class DbContextTeamRepository : BaseDbRepository<Team>, ITeamRepository
    {
        public DbContextTeamRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public override IQueryable<Team> Includes(IQueryable<Team> includes)
        {
            var inc = base.Includes(includes);
            inc = inc.Include(c => c.ContractCollection);
            return inc;
        }
    }
}
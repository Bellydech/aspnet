using System.Linq;
using Mondial.DotNet.Library.Context;
using Mondial.DotNet.Library.Models;
using Mondial.DotNet.Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Mondial.DotNet.Library.Repositories.Db
{
    public class DbContextPlayerRepository : BaseDbRepository<Player>, IPlayerRepository
    {
        public DbContextPlayerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public override IQueryable<Player> Includes(IQueryable<Player> includes)
        {
            var inc = base.Includes(includes);
            inc = inc.Include(p => p.ContractCollection);
            return inc;
        }
    }
}
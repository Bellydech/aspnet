using System;
using System.Collections.Generic;
using System.Linq;
using Mondial.DotNet.Library.Models;
using Mondial.DotNet.Library.Repositories.Base;
using Mondial.DotNet.Library.Repositories.Interfaces;

namespace Mondial.DotNet.Library.Repositories.InMemory
{
    public class InMemoryContractRepository :
        BaseInMemoryRepository<Contract>,
        IContractRepository
    {      
        private readonly IPlayerRepository _playerRepository;
        private readonly ITeamRepository _teamRepository;

        public InMemoryContractRepository(
            IPlayerRepository playerRepository, ITeamRepository teamRepository
        )
        {
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
        }
        public override List<Contract> SampleData =>
            new List<Contract>()
            {
                /*new Contract(1, _playerRepository.Single(1), _teamRepository.Single(19), 2003, 2005),
                new Contract(2, _playerRepository.Single(1), _teamRepository.Single(18), 2005, 2006),
                new Contract(3, _playerRepository.Single(1), _teamRepository.Single(8), 2006, 2009),
                new Contract(4, _playerRepository.Single(1), _teamRepository.Single(1), 2009, null),
                new Contract(5, _playerRepository.Single(2), _teamRepository.Single(4), 2011, 2017),
                new Contract(6, _playerRepository.Single(2), _teamRepository.Single(2), 2017, null),
                new Contract(7, _playerRepository.Single(3), _teamRepository.Single(1), 2008, 2014),
                new Contract(8, _playerRepository.Single(3), _teamRepository.Single(20), 2014, 2015),
                new Contract(9, _playerRepository.Single(3), _teamRepository.Single(11), 2015, 2016),
                new Contract(10, _playerRepository.Single(3), _teamRepository.Single(16), 2016, 2017),
                new Contract(11, _playerRepository.Single(3), _teamRepository.Single(1), 2017, 2018),
                new Contract(12, _playerRepository.Single(3), _teamRepository.Single(3), 2018, null),
                new Contract(13, _playerRepository.Single(4), _teamRepository.Single(21), 2002, 2011),
                new Contract(14, _playerRepository.Single(4), _teamRepository.Single(7), 2011, 2012),
                new Contract(15, _playerRepository.Single(4), _teamRepository.Single(11), 2012, 2015),
                new Contract(16, _playerRepository.Single(4), _teamRepository.Single(2), 2015, null),
                new Contract(17, _playerRepository.Single(5), _teamRepository.Single(4), 2012, null),
                new Contract(18, _playerRepository.Single(6), _teamRepository.Single(1), 2010, null),
                new Contract(19, _playerRepository.Single(7), _teamRepository.Single(2), 2010, 2015),
                new Contract(20, _playerRepository.Single(7), _teamRepository.Single(1), 2015, null),
                new Contract(21, _playerRepository.Single(8), _teamRepository.Single(1), 2012, 2016),
                new Contract(22, _playerRepository.Single(8), _teamRepository.Single(5), 2012, null),
                new Contract(23, _playerRepository.Single(9), _teamRepository.Single(1), 2006, null),
                new Contract(24, _playerRepository.Single(10), _teamRepository.Single(4), 2007, null),
                new Contract(25, _playerRepository.Single(11), _teamRepository.Single(20), 2008, 2017),
                new Contract(26, _playerRepository.Single(11), _teamRepository.Single(7), 2010, 2018),
                new Contract(27, _playerRepository.Single(11), _teamRepository.Single(6), 2018, null),
                new Contract(28, _playerRepository.Single(12), _teamRepository.Single(7), 2015, null),
                new Contract(29, _playerRepository.Single(13), _teamRepository.Single(19), 2003, 2004),
                new Contract(30, _playerRepository.Single(13), _teamRepository.Single(7), 2004, 2007),
                new Contract(31, _playerRepository.Single(13), _teamRepository.Single(4), 2007, 2009),
                new Contract(32, _playerRepository.Single(13), _teamRepository.Single(5), 2009, 2012),
                new Contract(33, _playerRepository.Single(13), _teamRepository.Single(1), 2012, 2015),
                new Contract(34, _playerRepository.Single(13), _teamRepository.Single(13), 2015, 2017),
                new Contract(35, _playerRepository.Single(13), _teamRepository.Single(12), 2017, 2018),
                new Contract(36, _playerRepository.Single(13), _teamRepository.Single(8), 2018, null),
                new Contract(37, _playerRepository.Single(14), _teamRepository.Single(1), 2007, 2008),
                new Contract(38, _playerRepository.Single(14), _teamRepository.Single(11), 2008, 2017),
                new Contract(39, _playerRepository.Single(14), _teamRepository.Single(9), 2017, null),
                new Contract(40, _playerRepository.Single(15), _teamRepository.Single(5), 2014, null),
                new Contract(41, _playerRepository.Single(16), _teamRepository.Single(21), 2004, 2005),
                new Contract(42, _playerRepository.Single(16), _teamRepository.Single(19), 2005, 2007),
                new Contract(43, _playerRepository.Single(16), _teamRepository.Single(1), 2007, 2017),
                new Contract(44, _playerRepository.Single(16), _teamRepository.Single(5), 2017, 2018),
                new Contract(45, _playerRepository.Single(16), _teamRepository.Single(1), 2018, null),
                new Contract(46, _playerRepository.Single(17), _teamRepository.Single(15), 2000, 2006),
                new Contract(47, _playerRepository.Single(17), _teamRepository.Single(14), 2006, 2008),
                new Contract(48, _playerRepository.Single(17), _teamRepository.Single(7), 2008, null),
                new Contract(49, _playerRepository.Single(18), _teamRepository.Single(17), 2008, 2009),
                new Contract(50, _playerRepository.Single(18), _teamRepository.Single(4), 2009, 2016),
                new Contract(51, _playerRepository.Single(18), _teamRepository.Single(16), 2016, 2018),
                new Contract(52, _playerRepository.Single(18), _teamRepository.Single(10), 2018, null),
                new Contract(53, _playerRepository.Single(19), _teamRepository.Single(1), 2015, null),
                new Contract(54, _playerRepository.Single(20), _teamRepository.Single(7), 2010, 2017),
                new Contract(55, _playerRepository.Single(20), _teamRepository.Single(5), 2017, null),
                new Contract(56, _playerRepository.Single(21), _teamRepository.Single(18), 2011, 2014),
                new Contract(57, _playerRepository.Single(21), _teamRepository.Single(4), 2014, null),
                new Contract(58, _playerRepository.Single(22), _teamRepository.Single(4), 2013, 2016),
                new Contract(59, _playerRepository.Single(22), _teamRepository.Single(10), 2016, 2017),
                new Contract(60, _playerRepository.Single(22), _teamRepository.Single(1), 2017, 2019),
                new Contract(61, _playerRepository.Single(22), _teamRepository.Single(2), 2019, null),
                new Contract(62, _playerRepository.Single(23), _teamRepository.Single(2), 2007, 2010),
                new Contract(63, _playerRepository.Single(23), _teamRepository.Single(1), 2010, null)*/
            };
    }
}
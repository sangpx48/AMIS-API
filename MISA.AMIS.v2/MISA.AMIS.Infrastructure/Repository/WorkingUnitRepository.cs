using MISA.AMIS.Core.Models;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MISA.AMIS.Core.Interfaces;

namespace MISA.AMIS.Infrastructure
{
    public class WorkingUnitRepository : BaseRepository<WorkingUnit>, IWorkingUnitRepository
    {

    }
}

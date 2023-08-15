using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Models;
using MISA.AMIS.Core;
using MISA.AMIS.Core.Interfaces;
using MISA.AMIS.Core.Exceptions;

namespace MISA.AMIS.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class WorkingUnitsController : MISABasesController<WorkingUnit>
    {
        public WorkingUnitsController(IBaseRepository<WorkingUnit> baseRepository,
            IBaseService<WorkingUnit> baseService) : base(baseRepository, baseService)
        {
        }
    }
}

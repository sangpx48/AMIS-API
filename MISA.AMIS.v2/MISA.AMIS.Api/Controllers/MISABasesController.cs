using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.Core.Exceptions;
using MISA.AMIS.Core.Interfaces;
using MISA.AMIS.Core.Models;

namespace MISA.AMIS.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MISABasesController<T> : ControllerBase
    {
        private readonly IBaseRepository<T> baseRepository;
        private readonly IBaseService<T> baseService;

        public MISABasesController(IBaseRepository<T> baseRepository, IBaseService<T> baseService)
        {
            this.baseRepository = baseRepository;
            this.baseService = baseService;
        }


        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var dataes = baseRepository.GetAll();
                return Ok(dataes);
            }
            catch (Exception ex)
            {
                return HandleException(ex);

            }
        }



        /// <summary>
        /// GetByID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public IActionResult GetByID(Guid id)
        {
            try
            {
                var data = baseRepository.GetByID(id);
                return Ok(data);
            }
            catch (Exception ex)
            {

                return HandleException(ex);

            }
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insert(T entity)
        {
            try
            {
                var data = baseService.InsertService(entity);
                return StatusCode(201, data);
            }
            catch (Exception ex)
            {
                return HandleException(ex);

            }
        }



        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Update(T entity)
        {
            try
            {
                var data = baseService.UpdateService(entity);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }



        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var data = baseRepository.Delete(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }


        /// <summary>
        /// HandleException
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected IActionResult HandleException(Exception ex)
        {
            //Ghi log vào hệ thống
            if (ex is MISAValidateException)
            {
                var res = new
                {
                    devMsg = ex.Message,
                    data = ex.Data,
                    userMsg = ex.Message
                };

                return StatusCode(400, res);
            }
            else
            {
                var res = new
                {
                    devMsg = ex.Message,
                    data = ex.InnerException,
                    userMsg = "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp."
                };
                return StatusCode(500, res);
            }
        }

    }
}

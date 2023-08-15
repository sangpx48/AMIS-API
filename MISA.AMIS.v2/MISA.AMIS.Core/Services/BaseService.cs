using MISA.AMIS.Core.Exceptions;
using MISA.AMIS.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Services
{
    public class BaseService<T> : IBaseService<T>
    {

        IBaseRepository<T> _baseRepository;

        protected List<string> ErrorValidateMsgs;

        protected bool IsValid = true;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
            ErrorValidateMsgs = new List<string>();
        }


        public int InsertService(T entity)
        {
            var isValid = ValidateObject(entity);
            //Validate hop le
            if (isValid == true)
            {
                var res = _baseRepository.Insert(entity);
                return res;
            }
            else
            {
                throw new MISAValidateException(ErrorValidateMsgs);
            }
        }

        public int UpdateService(T entity)
        {
            var isValid = ValidateObject(entity);
            if (isValid == true)
            {
                var res = _baseRepository.Update(entity);
                return res;
            }
            else
            {
                throw new MISAValidateException(ErrorValidateMsgs);
            }
        }

        protected virtual bool ValidateObject(T entity)
        {
            return true;
        }
    }

}

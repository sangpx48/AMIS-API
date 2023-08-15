using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Exceptions
{
    public class MISAValidateException : Exception
    {

        public string ValidateErrorMsg { get; set; }

        public IDictionary Errors { get; set; }

        public MISAValidateException(string errorMsg)
        {
            ValidateErrorMsg = errorMsg;
        }


        public MISAValidateException(List<string> errorMsg)
        {
            Errors = new Dictionary<string, object>();
            Errors.Add("Errors", errorMsg);
        }

        public override string Message => this.ValidateErrorMsg;

        public override IDictionary Data => Errors;


    }
}

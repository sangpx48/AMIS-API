using System;
using System.Collections.Generic;
using System.Text;


namespace MISA.AMIS.Core.Models
{
    public class ServiceResult
    {
        #region Properties
        /// <summary>
        /// Lỗi cho dev
        /// </summary>
        public string devMsg { get; set; }

        /// <summary>
        /// Lỗi cho khách hàng
        /// </summary>
        public string userMsg { get; set; }

        /// <summary>
        /// Mã lỗi
        /// </summary>
        public MISAEnum errorCode { get; set; }

        /// <summary>
        /// Dữ liệu
        /// </summary>
        public object data { get; set; }

        /// <summary>
        /// Kết quả
        /// </summary>
        public bool Success { get; set; } = true;
        #endregion
    }
}

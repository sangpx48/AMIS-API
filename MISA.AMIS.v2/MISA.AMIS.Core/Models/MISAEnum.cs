using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.AMIS.Core.Models
{
    /// <summary>
    /// MISA để xác định lỗi
    /// </summary>
    public enum MISAEnum
    {
        /// <summary>
        /// Dữ liệu Hợp Lệ
        /// </summary>
        IsValid = 100,

        /// <summary>
        /// Dữ liệu Không Hợp Lệ
        /// </summary>
        NotIsValid = 900,

        /// <summary>
        /// Thành Công
        /// </summary>
        Success = 200

    }
}

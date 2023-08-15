namespace MISA.AMIS.Common.Models
{

    /// <summary>
    /// Đơn vị 
    /// CreateBy: SANG - 05/12/2022
    /// </summary>
    public class WorkingUnit


    {
        #region Constructor
        /*public WorkingUnit()
        {
            this.WorkingUnitID = Guid.NewGuid();
            
        }*/
        #endregion




        #region Properties
         

        /// <summary>
        /// Khóa Chính
        /// </summary>
        public Guid WorkingUnitID { get; set; }

        /// <summary>
        /// Mã Đơn vị
        /// </summary>
        public string WorkingUnitCode { get; set; }


        /// <summary>
        /// Tên Đơn Vị
        /// </summary>
        public string WorkingUnitName { get; set; }


        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Ngày sửa gần nhất
        /// </summary>
        public DateTime ModifiedDate { get; set; }

        /// <summary>
        /// Người sửa
        /// </summary>
        public string? ModifiedBy { get; set; }
        #endregion



        #region Method

        #endregion




    }
}

using MISA.AMIS.Core.Enums;


namespace MISA.AMIS.Core.Models
{
    public class Employee
    {
        public Employee()
        {
            this.EmployeeID = Guid.NewGuid();
        }

        /// <summary>
        /// ID của nhân viên
        /// </summary>
        public Guid EmployeeID { get; set; }

        /// <summary>
        /// Mã Nhân Viên
        /// </summary>
        public string EmployeeCode { get; set; }


        /// <summary>
        /// Tên Nhân Viên
        /// </summary>
        public string EmployeeName { get; set; }


        /// <summary>
        /// Ngày Sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }


        /// <summary>
        /// Giới Tính
        /// </summary>
        public Gender? Gender { get; set; }


        /// <summary>
        /// Số CCCD
        /// </summary>
        public string? IdentityNumber { get; set; }


        /// <summary>
        /// Ngày cấp
        /// </summary>
        public DateTime? IdentityIssureDate { get; set; }


        /// <summary>
        ///Nơi Cấp
        /// </summary>
        public string? IdentityIssurePlace { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string? Email { get; set; }


        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string? PhoneNumber { get; set; }


        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        public string? LandlineNumber { get; set; }


        /// <summary>
        /// Chức Danh
        /// </summary>
        public string? CareerTitle { get; set; }


        /// <summary>
        /// Địa Chỉ
        /// </summary>
        public string? Address { get; set; }


        /// <summary>
        /// Số TK Ngân Hàng
        /// </summary>
        public string? AccountBank { get; set; }


        /// <summary>
        /// Tên Ngân Hàng
        /// </summary>
        public string? NameBank { get; set; }


        /// <summary>
        /// Chi Nhánh
        /// </summary>
        public string? BranchBank { get; set; }


        /// <summary>
        /// ID của phòng ban
        /// </summary>
        public Guid WorkingUnitID { get; set; }


        /// <summary>
        /// Tên Đơn Vị
        /// </summary>
        public string? WorkingUnitName { get; set; }


        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }


        /// <summary>
        /// Người tạo
        /// </summary>
        public string? CreatedBy { get; set; }


        /// <summary>
        /// Ngày chỉnh sửa gần nhất
        /// </summary>
        public DateTime? ModifiedDate { get; set; }


        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        public string? ModifiedBy { get; set; }

        public string? GenderName
        {
            get
            {
                switch (Gender)
                {
                    case Core.Enums.Gender.Female:
                        return Core.Resources.ResourceObject.Gender_Female;
                    case Core.Enums.Gender.Male:
                        return Core.Resources.ResourceObject.Gender_Male;
                    case Core.Enums.Gender.Other:
                        return Core.Resources.ResourceObject.Gender_Other;
                    default:
                        return null;
                }
            }

        }
    }
}

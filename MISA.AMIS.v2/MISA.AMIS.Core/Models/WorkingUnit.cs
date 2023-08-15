namespace MISA.AMIS.Core.Models
{

    public class WorkingUnit
    {
        public WorkingUnit()
        {
            this.WorkingUnitID = Guid.NewGuid();
        }

        public Guid WorkingUnitID { get; set; }
        public string WorkingUnitCode { get; set; }

        public string WorkingUnitName { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

    }
}

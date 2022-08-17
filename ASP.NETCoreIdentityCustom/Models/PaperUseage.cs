using System.ComponentModel.DataAnnotations;

namespace ASP.NETCoreIdentityCustom.Models
{
    public class PaperUseage : BaseModel
    {
        [Key]
        public int PaperUseageID { get; set; }
        public int MachineId { get; set; }      
        public int CurrentUses { get; set; }
        public int TotalCounter { get; set; }
        public decimal TotalPercentage { get; set; }
        public Machine Machine{ get; set; }
    }
}

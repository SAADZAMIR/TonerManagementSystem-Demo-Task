using ASP.NETCoreIdentityCustom.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
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
        public decimal TonerPercentage { get; set; }
        public int CurrentStock{ get; set; }
        //public decimal CurrentPercentage { get; set; }
        public decimal TotalToner { get; set; }
        public Machine Machine{ get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        //public IdentityUser User { get; set; }
    }
}

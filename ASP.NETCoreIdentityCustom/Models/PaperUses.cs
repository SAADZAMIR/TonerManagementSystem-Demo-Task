using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NETCoreIdentityCustom.Models
{
    public class PaperUse
    {
        [Key]
        public int PaperID { get; set; }
        public string PreviousCounter { get; set; }
        public string CurrentCounter { get; set; }
        public string TotalCounter { get; set; }
        public string TotalPerchent { get; set; }
        public int MachineId { get; set; }

        [ForeignKey("MachineId")]
        public virtual Machine Machine { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace Pragma.AdminCore.Data.Enums
{
    public enum EnumEventTicketStatus
    {
        [Display(Name = "Aktif")]
        Active = 0,
        [Display(Name = "Pasif")]
        Passive = 1,
    }
}

using System.ComponentModel.DataAnnotations;

namespace Pragma.AdminCore.Data.Enums
{
    public enum EnumEventUrlStatus
    {
        [Display(Name = "Pasif")]
        Passive = 0,
        [Display(Name = "Aktif")]
        Active = 1,
    }
}

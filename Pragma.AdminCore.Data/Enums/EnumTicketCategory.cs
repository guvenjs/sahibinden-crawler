using System.ComponentModel.DataAnnotations;

namespace Pragma.AdminCore.Data.Enums
{
    public enum EnumTicketCategory
    {
        [Display(Name = "Oda")]
        Room = 0,
        [Display(Name = "Tekil")]
        Single = 1,
    }
}

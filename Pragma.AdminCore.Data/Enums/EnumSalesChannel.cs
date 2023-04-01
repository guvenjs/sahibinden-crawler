using System.ComponentModel.DataAnnotations;

namespace Pragma.AdminCore.Data.Enums
{
    public enum EnumSalesChannel
    {
        [Display(Name = "Biletix")]
        Biletix = 0,
        [Display(Name = "JJ Bilet")]
        JJTicket = 1,
    }
}

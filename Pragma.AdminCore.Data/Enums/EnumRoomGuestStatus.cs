using System.ComponentModel.DataAnnotations;

namespace Pragma.AdminCore.Data.Enums
{
    public enum EnumRoomGuestStatus
    {
        [Display(Name = "Status1")]
        Passive = 0,
        [Display(Name = "Status2")]
        Active = 1,
    }
}

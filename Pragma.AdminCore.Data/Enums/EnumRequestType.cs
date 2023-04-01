using System.ComponentModel.DataAnnotations;

namespace Pragma.AdminCore.Data.Enums
{
    public enum EnumRequestType
    {
        [Display(Name = "POST")]
        POST,
        [Display(Name = "GET")]
        GET,
        [Display(Name = "PUT")]
        PUT
    }
}

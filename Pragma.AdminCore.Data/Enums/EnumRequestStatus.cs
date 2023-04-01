using System.ComponentModel.DataAnnotations;

namespace Pragma.AdminCore.Data.Enums
{
    public enum EnumRequestStatus
    {
        [Display(Name = "BAŞARILI")]
        SUCCESS = 200,
        [Display(Name = "HATALI")]
        BAD_REQUEST = 400,
        UNAUTHORIZED = 401
    }
}

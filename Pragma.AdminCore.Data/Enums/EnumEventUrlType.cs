using System.ComponentModel.DataAnnotations;

namespace Pragma.AdminCore.Data.Enums
{
    public enum EnumEventUrlType
    {
        [Display(Name = "Concert")]
        Concert = 0,
        [Display(Name = "Camera A")]
        CameraA = 1,
        [Display(Name = "Camera B")]
        CameraB = 2,
        [Display(Name = "Camera C")]
        CameraC = 3,
        [Display(Name = "Backstage")]
        Backstage = 4,
        [Display(Name = "Influencer")]
        Influencer = 5,
    }
}

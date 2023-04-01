using Microsoft.AspNetCore.Identity;
using System;

namespace Pragma.AdminCore.Data.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime? DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateUpdated { get; set; }
    }
}

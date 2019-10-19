using System;
using System.ComponentModel.DataAnnotations;
namespace ACTYouthServicesWeb.Models
{
    public class ServiceMetadata
    {
        [StringLength(100)]
        public string Name;

        [Phone]
        [StringLength(10)]
        public string Phone;

        [StringLength(320)]
        [EmailAddress]
        public string Email;

        [StringLength(200)]
        public string Accessability;

        [StringLength(200)]
        public string Clientele;

        [StringLength(200)]
        public string Referral;

        [Display(Name = "Minimum Age")]
        public Nullable<int> MinAge;

        [Display(Name = "Maximum Age")]
        public Nullable<int> MaxAge;

        [StringLength(50)]
        public string Cost;
    }
}
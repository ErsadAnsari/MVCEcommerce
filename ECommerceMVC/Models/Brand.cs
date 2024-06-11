using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceMVC.Models
{
    public class Brand
    {
        [Key]
        [Display(Name ="Brand ID")]
        public long BrandID { get; set; }
        [Display(Name ="Brand Name")]
        public string BrandName { get; set; }
    }
}
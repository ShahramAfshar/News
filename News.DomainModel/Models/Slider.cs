using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DomainModel
{
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }

        [Display(Name = "نام عکس")]
        public string ImageName { get; set; }

        [Display(Name = "نمایش")]
        public bool IsShow { get; set; }

        [Display(Name = "تاریخ شروع")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        [Column(TypeName = "datetime2")]
        public DateTime StartDate { get; set; }

        [Display(Name = "تاریخ پایان")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        [Column(TypeName = "datetime2")]
        public DateTime EndDate { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public string Caption { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public string Url { get; set; }
    }
}

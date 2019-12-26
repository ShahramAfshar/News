using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DomainModel
{
    public class NewsModel
    {
        [Key]
        public int NewsId { get; set; }
        [Display(Name = "گروه خبری")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public int GroupId { get; set; }

        [Display(Name = "عنوان خبر")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        [MinLength(3, ErrorMessage = "فیلد{0} نمی تواند کمتر {1} کاراکتر باشد")]
        [MaxLength(50, ErrorMessage = "فیلد{0} نمی تواند بیشتر {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "خلاصه خبر")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        [MinLength(10, ErrorMessage = "فیلد{0} نمی تواند کمتر {1} کاراکتر باشد")]
        [MaxLength(350, ErrorMessage = "فیلد{0} نمی تواند بیشتر {1} کاراکتر باشد")]
        [DataType(DataType.MultilineText)]
        public string ShortNews { get; set; }

        [Display(Name = "متن خبر")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        [MinLength(10, ErrorMessage = "فیلد{0} نمی تواند کمتر {1} کاراکتر باشد")]
        [DataType(DataType.MultilineText)]
        public string FullNews { get; set; }

        [Display(Name = "نمایش در اسلایدر")]
        public bool IsShowSlider { get; set; }
        public string ImageName { get; set; }
        [DisplayFormat(DataFormatString ="{0:yyy/MM/dd}")]
        public DateTime CreateDate { get; set; }

        [Display(Name = "تعداد بازدید")]
        public int Visit { get; set; }



        public virtual GroupNews  GroupNews { get; set; }
        public virtual IEnumerable<Tag>  Tags { get; set; }
        public virtual IEnumerable<Comment>  Comments { get; set; }

    }
}

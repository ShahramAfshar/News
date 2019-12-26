using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DomainModel
{
    public class GroupNews
    {
        [Key]
        public int GroupId { get; set; }

        [Display(Name = "عنوان گروه")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        [MinLength(3,ErrorMessage = "فیلد{0} نمی تواند کمتر {1} کاراکتر باشد")]
        [MaxLength(30, ErrorMessage = "فیلد{0} نمی تواند بیشتر {1} کاراکتر باشد")]
        public string Title { get; set; }

        public virtual List<NewsModel>   NewsModels { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DomainModel
{
   public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public int NewsId { get; set; }

        public int ParentId { get; set; }

        [Display(Name = "نام ")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        public string Name { get; set; }

        [Display(Name = "ایمیل")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "وب سایت")]
        public string WebSite { get; set; }

        [Display(Name = "متن نظر")]
        [Required(ErrorMessage = " فیلد{0} نمی تواند خالی باشد")]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        public bool IsShow { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual NewsModel NewsModel { get; set; }

    }
}

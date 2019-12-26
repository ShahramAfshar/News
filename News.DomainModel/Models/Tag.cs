using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.DomainModel
{
  public  class Tag
    {
        public int TagId { get; set; }
        public int NewsId { get; set; }
        public string Title { get; set; }


        public virtual NewsModel   NewsModel { get; set; }
    }
}

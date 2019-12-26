using News.Data.DatabaseContext;
using News.DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Data.Repositories
{
     
    public interface INewsRepository : IRepository<NewsModel>
    {
        //------Definition Private Functions Model -------------//
      //  IEnumerable<new> Search(string q);

    }

    public class NewsRepository : Repository<NewsModel>, INewsRepository
    {

        private readonly DbContext db;
        public NewsRepository(DbContext dbContext) : base(dbContext)
        {
            this.db = (this.db ?? (MyDbContext)db);
        }

        //public IEnumerable<Product> Search(string q)
        //{
        //    var Tags = GetAll().Where(t => t.Title == q).Select(t => t.Product).ToList();
        //    return Tags;
        //}
    }
}

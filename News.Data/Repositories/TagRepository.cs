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
     
    public interface ITagRepository : IRepository<Tag>
    {
        //------Definition Private Functions Model -------------//
         IEnumerable<Tag> SingleNews(int  newsId);

    }

    public class TagRepository : Repository<Tag>, ITagRepository
    {

        private readonly DbContext db;
        public TagRepository(DbContext dbContext) : base(dbContext)
        {
            this.db = (this.db ?? (MyDbContext)db);
        }

        public IEnumerable<Tag> SingleNews(int newsId)
        {
         return  GetAll().Where(t => t.NewsId == newsId).ToList();
        }

    }
}

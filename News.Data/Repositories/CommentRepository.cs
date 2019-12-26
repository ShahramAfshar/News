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
     
    public interface ICommentRepository : IRepository<Comment>
    {


    }

    public class CommentRepository : Repository<Comment>, ICommentRepository
    {

        private readonly DbContext db;
        public CommentRepository(DbContext dbContext) : base(dbContext)
        {
            this.db = (this.db ?? (MyDbContext)db);
        }


    }
}

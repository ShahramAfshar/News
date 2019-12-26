
using News.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace News.Data
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DbContext, new()

    {

        #region Fileds
        protected readonly DbContext db;

        #endregion

        #region Ctor
        public UnitOfWork()
        {
            db = new TContext();
        }

        #endregion

        #region Implement

        public void Commit()
        {
            db.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return db.SaveChangesAsync();
        }

        #endregion

        #region Repositories

        private TagRepository tagRepository;
        public TagRepository TagRepository
        {
            get
            {
                if (tagRepository == null)
                {
                    tagRepository = new TagRepository(db);
                }

                return tagRepository;
            }
        }

        private GroupRepository groupRepository;
        public GroupRepository GroupRepository
        {
            get
            {
                if (groupRepository == null)
                {
                    groupRepository = new GroupRepository(db);
                }

                return groupRepository;
            }
        }

        private NewsRepository newsRepository;
        public NewsRepository NewsRepository
        {
            get
            {
                if (newsRepository == null)
                {
                    newsRepository = new NewsRepository(db);
                }

                return newsRepository;
            }
        }

        private CommentRepository commentRepository;
        public CommentRepository CommentRepository
        {
            get
            {
                if (commentRepository == null)
                {
                    commentRepository = new CommentRepository(db);
                }

                return commentRepository;
            }
        }


        #endregion

        #region Dispose

        private bool disposed = false;


        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        #endregion

    }
}

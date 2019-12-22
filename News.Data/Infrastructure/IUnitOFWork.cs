using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;


namespace News.Data
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        //1-Begin TransAction  2-Commit(SaveChange) 3-RollBack
      //  TagRepository TagRepository { get; }



        void Commit();
        Task<int> CommitAsync();


    }
}

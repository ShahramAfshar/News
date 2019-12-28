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
     
    public interface ISliderRepository : IRepository<Slider>
    {
        //------Definition Private Functions Model -------------//

    }

    public class SliderRepository : Repository<Slider>, ISliderRepository
    {

        private readonly DbContext db;
        public SliderRepository(DbContext dbContext) : base(dbContext)
        {
            this.db = (this.db ?? (MyDbContext)db);
        }


    }
}

using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PictureRepository : SEnglishRepository<Picture>, IRepository<Picture>
    {
        public PictureRepository(DBContext dbctx) : base(dbctx)
        {
        }
    }
}

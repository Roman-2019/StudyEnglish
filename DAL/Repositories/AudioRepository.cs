using DAL.Interfaces;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AudioRepository : SEnglishRepository<Audio>, IRepository<Audio>
    {
        public AudioRepository(DBContext dbctx) : base(dbctx)
        {
        }
    }
}

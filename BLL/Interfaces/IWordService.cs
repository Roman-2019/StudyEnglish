using BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IWordService : IService<WordModel>
    {
        WordModel GetById(int id);
    }
}

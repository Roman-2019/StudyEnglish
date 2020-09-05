using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class ColorModel
    {
        public int Id { get; set; }
        public string ColorOnRussian { get; set; }
        public string ColorOnEnglish { get; set; }

        public ICollection<WordModel> WordModels { get; set; }
    }
}

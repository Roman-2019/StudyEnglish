using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEnglish.Models
{
    public class ColorViewModel
    {
        public int Id { get; set; }
        public string ColorOnRussian { get; set; }
        public string ColorOnEnglish { get; set; }

        public ICollection<WordViewModel> WordViewModels { get; set; }
    }
}
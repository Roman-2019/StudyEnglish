using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEnglish.Models
{
    public class TopicViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Marker { get; set; }
        public ICollection<WordViewModel> WordViewModels { get; set; }
        public ICollection<AudioViewModel> AudioViewModels { get; set; }
        public ICollection<PictureViewModel> PictureViewModels { get; set; }
    }
}
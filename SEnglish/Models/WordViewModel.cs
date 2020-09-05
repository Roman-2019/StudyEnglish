using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SEnglish.Models
{
    public class WordViewModel
    {
        public int Id { get; set; }
        public string RussianWord { get; set; }
        public string EnglishWord { get; set; }

        public int TopicViewModelId { get; set; }
        public TopicViewModel TopicViewModel { get; set; }

        public ICollection<PictureViewModel> PictureViewModels { get; set; }
        public ICollection<ColorViewModel> ColorViewModels { get; set; }
        public ICollection<AudioViewModel> AudioViewModels { get; set; }
    }
}
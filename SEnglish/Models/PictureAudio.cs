using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SEnglish.Models
{
    public class PictureAudio
    {
        public IEnumerable<PictureViewModel> PictureViewModels { get; set; }
        public IEnumerable<AudioViewModel> AudioViewModels { get; set; }

        public SelectList Topics { get; set; }
        public TopicViewModel TopicViewModel { get; set; }
        public List<string> listId { get; set; }
    }
}
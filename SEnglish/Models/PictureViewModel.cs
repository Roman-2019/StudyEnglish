using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEnglish.Models
{
    public class PictureViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        [DisplayName("Upload image file")]
        public string ImagePath { get; set; }

        public int WordViewModelId { get; set; }
        public WordViewModel WordViewModel { get; set; }
        //public ICollection<WordViewModel> WordViewModels { get; set; }

        public int TopicViewModelId { get; set; }
        public TopicViewModel TopicViewModel { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }
    }
}
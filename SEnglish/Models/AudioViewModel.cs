using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace SEnglish.Models
{
    public class AudioViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Voice { get; set; }

        [DisplayName("Upload image file")]
        public string AudioPath { get; set; }


        public int WordViewModelId { get; set; }
        public WordViewModel WordViewModel { get; set; }

        public int TopicViewModelId { get; set; }
        public TopicViewModel TopicViewModel { get; set; }

        public HttpPostedFileBase AudioFile { get; set; }
    }
}
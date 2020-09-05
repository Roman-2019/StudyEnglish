using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class WordModel
    {
        public int Id { get; set; }
        public string RussianWord { get; set; }
        public string EnglishWord { get; set; }

        public int TopicModelId { get; set; }
        public TopicModel TopicModel { get; set; }

        public ICollection<PictureModel> PictureModels { get; set; }
        public ICollection<AudioModel> AudioModels { get; set; }
        public ICollection<ColorModel> ColorModels { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Word
    {
        public int Id { get; set; }
        public string RussianWord { get; set; }
        public string EnglishWord { get; set; }

        public int TopicId { get; set; }
        public Topic Topic { get; set; }

        public ICollection<Audio> Audio { get; set; }

        public ICollection<Picture> Pictures { get; set; }

        public ICollection<Color> Colors { get; set; }
    }
}

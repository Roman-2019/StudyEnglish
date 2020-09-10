using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string ImagePath { get; set; }

        public int WordId { get; set; }
        public Word Word { get; set; }

        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        //public ICollection<Word> Words { get; set; }
    }
}

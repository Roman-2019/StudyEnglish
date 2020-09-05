using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Audio
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Voice { get; set; }
        public string AudioPath { get; set; }


        public int WordId { get; set; }
        public Word Word { get; set; }

        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}

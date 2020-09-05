using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class AudioModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Voice { get; set; }
        public string AudioPath { get; set; }


        public int WordModelId { get; set; }
        public WordModel WordModel { get; set; }

        public int TopicModelId { get; set; }
        public TopicModel TopicModel { get; set; }
    }
}

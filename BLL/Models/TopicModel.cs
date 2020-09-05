using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class TopicModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Marker { get; set; }

        public ICollection<AudioModel> AudioModels { get; set; }
        public ICollection<WordModel> WordModels { get; set; }
    }
}

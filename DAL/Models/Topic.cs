using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Marker { get; set; }

        public ICollection<Audio> Audio { get; set; }
        public ICollection<Word> Words { get; set; }
    }
}

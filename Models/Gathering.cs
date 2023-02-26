using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Gathering
    {
     public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Time { get; set; }
        public string Place { get; set; }
        public string Participants { get; set; }
        public virtual Group Group { get; set; }
    }
}
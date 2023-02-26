using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class User
    {
     public int Id { get; set; }
        public string Name { get; set; }
        public string MobileNumber { get; set; }
        public virtual ICollection<Interest> Interests { get; set; }
        public virtual Group Group { get; set; }
        public virtual ICollection<Gathering> Gatherings { get; set; }
        public virtual ICollection<Friend> Friends { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class Friend
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int FriendId { get; set; }
        public User Friends { get; set; }
    }
}
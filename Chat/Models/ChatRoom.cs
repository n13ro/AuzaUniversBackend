using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Models
{
    public class ChatRoom
    {
        public string RoomId { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "";
        public string CreatorId { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<string> Users { get; set; } = new List<string>();
    }
}

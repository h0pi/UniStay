using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniStay.Domain.Common;
using UniStay.Domain.Entities.Identity;

namespace UniStay.Domain.Entities.Catalog
{
    public class Message : BaseEntity
    {
        public int SenderUserId { get; set; }
        public User SenderUser { get; set; }

        
        public int ReceiverUserId { get; set; }
        public User ReceiverUser { get; set; }

        public string Subject { get; set; }
        public string MessageText { get; set; }
        public DateTime SentAt { get; set; } = DateTime.UtcNow;
        public bool IsRead { get; set; } = false;
    }
}

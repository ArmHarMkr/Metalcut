using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalcutWeb.Domain.Entity
{
    public class MessageEntity
    {
        [Key]
        public string? MessageId { get; set; } = Guid.NewGuid().ToString();
        public AppUser Sender { get; set; }
        public AppUser Receiver { get; set; }
        [Required(ErrorMessage = "Input something")]
        public string MessageText { get; set; }
        public DateTime SentTime { get; set; } = DateTime.Now;


/*        public ChatEntity MessageSendingChat { get; set; } */

    }
}

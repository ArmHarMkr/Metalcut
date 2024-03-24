using MetalcutWeb.Domain.Entity;

namespace MetalcutWeb.ViewModels
{
    public class ChatViewModel
    {
        public MessageEntity MessageEntity { get; set; } = new();
        public ChatEntity ChatEntity { get; set; } 

    }
}

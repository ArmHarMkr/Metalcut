using MetalcutWeb.DAL.Data;
using MetalcutWeb.DAL.Repository;
using MetalcutWeb.Domain.Entity;
using MetalcutWeb.Domain.Roles;
using MetalcutWeb.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MetalcutWeb.Controllers
{
    [Authorize]
    [Route("Questions/{controller}")]
    public class ChatController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        public ChatController(AppDbContext db, IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _db = db;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }


        [HttpGet("GetEmployee")]
        public async Task<IActionResult> GetEmployee()
        {
            IEnumerable<AppUser> employeeUser = await _userManager.GetUsersInRoleAsync(SD.Role_Employee);
            return View(employeeUser);
        }


        [HttpGet("MyChats")]
        public async Task<IActionResult> MyChats()
        {
            AppUser currentUser = await _userManager.GetUserAsync(User);
            var chatWithUsers = await _db.Chats
                                        .Include(u => u.UserOne)
                                        .Include(u => u.UserTwo)
                                        .Include(u => u.Messages)
                                        .Where(m => m.UserOne == currentUser || m.UserTwo == currentUser).ToListAsync();
            return View(chatWithUsers);
        }


        [HttpGet("Messenger")]
        public async Task<IActionResult> Messenger(string? id)
        {
            AppUser currentUser = await _userManager.GetUserAsync(User);
            AppUser receiverUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (receiverUser == null)
            {
                return BadRequest();
            }
            var messages = await _db.Messages
                                .Include(u => u.Receiver)
                                .Include(u => u.Sender)
                                .Where(u => u.Sender == currentUser && u.Receiver == receiverUser || u.Sender == receiverUser && u.Receiver == currentUser)
                                .ToListAsync();


            var chatWithUsers = await _db.Chats
                                        .Include(u => u.UserOne)
                                        .Include(u => u.UserTwo)
                                        .Include(m => m.Messages)
                                        .FirstOrDefaultAsync(u => u.UserOne == currentUser && u.UserTwo == receiverUser || u.UserOne == receiverUser && u.UserTwo == currentUser);
            ChatViewModel chatVM = new ChatViewModel();
            chatVM.ChatEntity = chatWithUsers;
            chatVM.ChatEntity.Messages = messages;
            return View(chatVM);


        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string? id, ChatViewModel chatVM)
        {
            ChatEntity chat = await _db.Chats.Include(u => u.UserOne).Include(u => u.UserTwo).Include(m => m.Messages).FirstOrDefaultAsync(c => c.Id == id);
            if (chat == null)
            {
                return BadRequest();
            }

            chatVM.MessageEntity.Sender = chat.UserOne;
            chatVM.MessageEntity.Receiver = chat.UserTwo;
            chat.Messages.Add(chatVM.MessageEntity);
            _db.Messages.Add(chatVM.MessageEntity);
            _db.Chats.Update(chat);
            await _unitOfWork.Save();

            return RedirectToAction("Messenger", new { id = chat.UserTwo.Id });
        }

        [HttpPost("DeleteMsg")]
        public async Task<IActionResult> DeleteMsg(string? id)
        {
            var msgFromDb = await _db.Messages.Include(u => u.Sender).Include(u => u.Receiver).FirstOrDefaultAsync(m => m.MessageId == id);
            _db.Messages.Remove(msgFromDb);
            _unitOfWork.Save();
            return RedirectToAction("Messenger", new {id = msgFromDb.Receiver.Id });
        }
    }
}

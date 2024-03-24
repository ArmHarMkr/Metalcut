using MetalcutWeb.DAL.Data;
using MetalcutWeb.DAL.Repository;
using MetalcutWeb.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetalcutWeb.DAL.Implementations
{
    public class ChatRepository : Repository<ChatEntity>, IChatRepository
    {
        private readonly AppDbContext _db;
        public ChatRepository(AppDbContext db)
            :base(db)
        {
            _db = db;
        }
    }
}

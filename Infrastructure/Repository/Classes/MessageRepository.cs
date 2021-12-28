using Infrastructure.Persist;
using Infrastructure.Repository.Interfaces;

namespace Infrastructure.Repository.Classes
{
    public class MessageRepository : BaseRepository, IMessageRepository
    {
        public MessageRepository(DatabaseContext context) : base(context)
        {

        }

        //        /// <summary>
        //        /// دریافت تالار گفتگو
        //        /// </summary>
        //        public async Task<Conversation> GetConversationById(Guid id)
        //        {
        //            return await _context.Conversations
        //                .FirstOrDefaultAsync(x => x.Id == id);
        //        }

        //        /// <summary>
        //        /// اضافه کردن پیام
        //        /// </summary>
        //        public async Task<bool> AddMessage(Message message)
        //        {
        //            await _context.Messages
        //                .AddAsync(message);
        //            return await _context.SaveChangesAsync() > 0;
        //        }

        //        /// <summary>
        //        /// دریافت همه پیام های کاربر با شماره تلفن
        //        /// </summary>
        //        public async Task<List<Message>> GetAllUserMessagesByCellPhone(string cellphone)
        //        {
        //            return await _context.Messages
        //                .Where(x => x.UserName == cellphone && x.MessageStatus != MessageStatus.Deleted)
        //                .OrderByDescending(x => x.SubmitDate)
        //                .ToListAsync();
        //        }

        //        /// <summary>
        //        /// دریافت پیام با آیدی
        //        /// </summary>
        //        public async Task<Message> GetMessageById(Guid id)
        //        {
        //            return await _context.Messages
        //                .FirstOrDefaultAsync(x => x.Id == id && x.MessageStatus != MessageStatus.Deleted);
        //        }

        //        /// <summary>
        //        /// دریافت کاربر با آیدی
        //        /// </summary>
        //        public async Task<User> GetUserById(Guid id)
        //        {
        //            return await _context.Users
        //                .SingleOrDefaultAsync(x => x.Id == id);
        //        }

        //        /// <summary>
        //        /// جستجوی پیام ها بین کل پیام ها
        //        /// </summary>
        //        public async Task<List<Message>> SearchMessages(string searchBox)
        //        {
        //            return await _context.Messages
        //                .FromSql("Select * from dbo.messages as m where m.message like {0}", $"%{searchBox}%")
        //                .Where(x => x.MessageStatus != MessageStatus.Deleted)
        //                .OrderByDescending(x => x.SubmitDate)
        //                .ToListAsync();
        //        }

        //        /// <summary>
        //        /// جست و جوی پیام های یک کاربر
        //        /// </summary>
        //        public async Task<List<Message>> SearchUserMessages(string cellphone, string searchBox)
        //        {
        //            return await _context.Messages
        //                .FromSql("Select * from dbo.messages as m where m.message like {0}", $"%{searchBox}%")
        //                .Where(x => x.UserName == cellphone && x.MessageStatus != MessageStatus.Deleted)
        //                .OrderByDescending(x => x.SubmitDate)
        //                .ToListAsync();
        //        }

        //        /// <summary>
        //        /// ذخیره اعمال انجام شده
        //        /// </summary>
        //        public async Task<bool> UpdateMessages()
        //        {
        //            return await _context.SaveChangesAsync() > 0;
        //        }

        //        /// <summary>
        //        /// همه پیام های پاک شده
        //        /// </summary>
        //        public async Task<List<Message>> AllDeletedMessage()
        //        {
        //            return await _context.Messages
        //                .Where(x => x.MessageStatus == MessageStatus.Deleted)
        //                .OrderByDescending(x => x.SubmitDate)
        //                .ToListAsync();
        //        }

        //        /// <summary>
        //        /// همه پیام های پاک شده کاربر
        //        /// </summary>
        //        public async Task<List<Message>> AllUserDeletedMessages(string cellPhone)
        //        {
        //            return await _context.Messages
        //                .Where(x => x.UserName == cellPhone && x.MessageStatus == MessageStatus.Deleted)
        //                .OrderByDescending(x => x.SubmitDate)
        //                .ToListAsync();
        //        }

        //        /// <summary>
        //        /// دریافت تالار گفتگو باز
        //        /// </summary>
        //        public async Task<Conversation> GetOpenConversationById(Guid id)
        //        {
        //            return await _context.Conversations
        //                .FirstOrDefaultAsync(x => x.Id == id && x.State == States.Open);
        //        }
    }
}

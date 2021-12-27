using Domain.RepositoryInterfaces;
using Infrastructure.Persist;

namespace Infrastructure.Repository.RepositoryImplementation
{
    public class ConversationRepository : BaseRepository, IConversationRepository
    {
        public ConversationRepository(DatabaseContext context) : base(context)
        {

        }

        //        /// <summary>
        //        /// اضافه کردن تالار گفتگو
        //        /// </summary>
        //        public async Task<bool> AddConversation(Conversation conversation)
        //        {
        //            await _context.Conversations
        //                .AddAsync(conversation);
        //            return await _context.SaveChangesAsync() > 0;
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
        //        /// دریافت تالاز گفتگو با آیدی
        //        /// </summary>
        //        public async Task<Conversation> GetConversationById(Guid id)
        //        {
        //            return await _context.Conversations
        //                .FirstOrDefaultAsync(x => x.Id == id);
        //        }

        //        /// <summary>
        //        /// دریافت تالار گفتگوی باز با آیدی
        //        /// </summary>
        //        public async Task<Conversation> GetOpenConversationById(Guid id)
        //        {
        //            return await _context.Conversations
        //                .FirstOrDefaultAsync(x => x.Id == id && x.State == States.Open);
        //        }

        //        /// <summary>
        //        /// /دریافت تالار گفت و گوی بسته
        //        /// </summary>
        //        public async Task<Conversation> GetClosedConversationById(Guid id)
        //        {
        //            return await _context.Conversations
        //                .FirstOrDefaultAsync(x => x.Id == id && x.State == States.Closed);
        //        }

        //        /// <summary>
        //        /// دریافت پیام با آیدی
        //        /// </summary>
        //        public async Task<Message> GetMessageById(Guid id)
        //        {
        //            return await _context.Messages
        //                .FirstOrDefaultAsync(x => x.Id == id);
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
        //        /// ذخیره اعمال انجام شده
        //        /// </summary>
        //        public async Task<bool> UpdateConversation()
        //        {
        //            return await _context.SaveChangesAsync() > 0;
        //        }

        //        /// <summary>
        //        /// دریافت همه تالار گفتگوها
        //        /// </summary>
        //        public async Task<List<Conversation>> GetAllConversations()
        //        {
        //            return await _context.Conversations
        //                .OrderByDescending(x => x.LastActivity)
        //                .ToListAsync();
        //        }

        //        /// <summary>
        //        /// دریافت کل پیام های یک تالار گفتگو
        //        /// </summary>
        //        public async Task<List<Message>> GetAllConversationMessageById(Guid id)
        //        {
        //            return await _context.Messages
        //                .Where(x => x.ConversationId == id && x.MessageStatus != MessageStatus.Deleted)
        //                .OrderByDescending(x => x.SubmitDate)
        //                .ToListAsync();
        //        }

        //        /// <summary>
        //        /// دریافت کل پیام های حذف شده یک تالار گفتگو
        //        /// </summary>
        //        public async Task<List<Message>> GetAllConversationDeletedMessageById(Guid id)
        //        {
        //            return await _context.Messages
        //                .Where(x => x.ConversationId == id && x.MessageStatus == MessageStatus.Deleted)
        //                .OrderByDescending(x => x.SubmitDate)
        //                .ToListAsync();
        //        }

        //        /// <summary>
        //        /// جست و جوی پیام در یک تالار گفت و گو
        //        /// </summary>
        //        public async Task<List<Message>> SearchConversationMessage(Guid id, string searchBox)
        //        {
        //            var messages = await _context.Messages
        //                .FromSql("Select * from dbo.messages as m where m.message like {0}", $"%{searchBox}%")
        //                .Where(x => x.ConversationId == id && x.MessageStatus != MessageStatus.Deleted)
        //                .OrderByDescending(x => x.SubmitDate)
        //                .ToListAsync();
        //            if (messages == null)
        //                return null;
        //            return messages;
        //        }

        //        /// <summary>
        //        /// دریافت همه تالار گفتگوهای باز با اهمیت کم
        //        /// </summary>
        //        public async Task<List<Conversation>> GetAllOpenLessPriorityConversations()
        //        {
        //            return await _context.Conversations
        //                .Where(x => x.Priority == Priority.Less && x.State == States.Open)
        //                .OrderByDescending(x => x.LastActivity)
        //                .ToListAsync();
        //        }

        //        /// <summary>
        //        /// دریافت همه تالار گفتگوهای بسته با اهمیت کم
        //        /// </summary>
        //        public async Task<List<Conversation>> GetAllClosedLessPriorityConversations()
        //        {
        //            return await _context.Conversations
        //                .Where(x => x.Priority == Priority.Less && x.State == States.Closed)
        //                .OrderByDescending(x => x.LastActivity)
        //                .ToListAsync();
        //        }

        //        /// <summary>
        //        /// دریافت همه تالار گفتگوهای باز با اهمیت متوسط
        //        /// </summary>
        //        public async Task<List<Conversation>> GetAllOpenMediumPriorityConversations()
        //        {
        //            return await _context.Conversations
        //                 .Where(x => x.Priority == Priority.Medium && x.State == States.Open)
        //                 .OrderByDescending(x => x.LastActivity)
        //                 .ToListAsync();
        //        }

        //        /// <summary>
        //        /// دریافت همه تالار گفتگوهای بسته با اهمیت متوسط
        //        /// </summary>
        //        public async Task<List<Conversation>> GetAllClosedMediumPriorityConversations()
        //        {
        //            return await _context.Conversations
        //                 .Where(x => x.Priority == Priority.Medium && x.State == States.Closed)
        //                 .OrderByDescending(x => x.LastActivity)
        //                 .ToListAsync();
        //        }

        //        /// <summary>
        //        /// دریافت همه تالار گفتگوهای باز با اهمیت زیاد
        //        /// </summary>
        //        public async Task<List<Conversation>> GetAllOpenHighPriorityConversations()
        //        {
        //            return await _context.Conversations
        //                 .Where(x => x.Priority == Priority.High && x.State == States.Open)
        //                 .OrderByDescending(x => x.LastActivity)
        //                 .ToListAsync();
        //        }

        //        /// <summary>
        //        /// دریافت همه تالار گفتگوهای بسته با اهمیت زیاد
        //        /// </summary>
        //        public async Task<List<Conversation>> GetAllClosedHighPriorityConversations()
        //        {
        //            return await _context.Conversations
        //                 .Where(x => x.Priority == Priority.High && x.State == States.Closed)
        //                 .OrderByDescending(x => x.LastActivity)
        //                 .ToListAsync();

    }
}
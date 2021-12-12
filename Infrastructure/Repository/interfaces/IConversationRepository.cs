using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Infrastructure.Repository.interfaces
{
    public interface IConversationRepository
    {
        /// <summary>
        /// دریافت کاربر با آیدی
        /// </summary>
        Task<User> GetUserById(Guid id);
        
        /// <summary>
        /// دریافت پیام با آیدی
        /// </summary>
        Task<Message> GetMessageById(Guid id);

        /// <summary>
        /// دریافت تالاز گفتگوی باز با آیدی
        /// </summary>
        Task<Conversation> GetOpenConversationById(Guid id);

        /// <summary>
        /// /دریافت تالار گفت و گوی بسته
        /// </summary>
        Task<Conversation> GetClosedConversationById(Guid id);

        /// <summary>
        /// دریافت تالاز گفتگو با آیدی
        /// </summary>
        Task<Conversation> GetConversationById(Guid id);

        /// <summary>
        /// اضافه کردن پیام
        /// </summary>
        Task<bool> AddMessage(Message message);

        /// <summary>
        /// اضافه کردن تالار گفتگو
        /// </summary>
        Task<bool> AddConversation(Conversation conversation);

        /// <summary>
        /// دریافت همه تالار گفتگوها
        /// </summary>
        Task<List<Conversation>> GetAllConversations();

        /// <summary>
        /// دریافت همه تالار گفتگوهای باز با اهمیت کم
        /// </summary>
        Task<List<Conversation>> GetAllOpenLessPriorityConversations();

        /// <summary>
        /// دریافت همه تالار گفتگوهای بسته با اهمیت کم
        /// </summary>
        Task<List<Conversation>> GetAllClosedLessPriorityConversations();

        /// <summary>
        /// دریافت همه تالار گفتگوهای باز با اهمیت متوسط
        /// </summary>
        Task<List<Conversation>> GetAllOpenMediumPriorityConversations();

        /// <summary>
        /// دریافت همه تالار گفتگوهای بسته با اهمیت متوسط
        /// </summary>
        Task<List<Conversation>> GetAllClosedMediumPriorityConversations();

        /// <summary>
        /// دریافت همه تالار گفتگوهای باز با اهمیت زیاد
        /// </summary>
        Task<List<Conversation>> GetAllOpenHighPriorityConversations();

        /// <summary>
        /// دریافت همه تالار گفتگوهای بسته با اهمیت زیاد
        /// </summary>
        Task<List<Conversation>> GetAllClosedHighPriorityConversations();

        /// <summary>
        /// دریافت کل پیام های یک تالار گفتگو
        /// </summary>
        Task<List<Message>> GetAllConversationMessageById(Guid id);

        /// <summary>
        /// دریافت کل پیام های حذف شده یک تالار گفتگو
        /// </summary>
        Task<List<Message>> GetAllConversationDeletedMessageById(Guid id);

        /// <summary>
        /// ذخیره اعمال انجام شده
        /// </summary>
        Task<bool> UpdateConversation();

        /// <summary>
        /// جست و جوی پیام در یک تالار گفت و گو
        /// </summary>
        Task<List<Message>> SearchConversationMessage(Guid id, string searchBox);
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Models;

namespace Infrastructure.Repository.interfaces
{
    public interface IMessageRepository
    {
        /// <summary>
        /// دریافت تالار گفتگو
        /// </summary>
        Task<Conversation> GetConversationById(Guid id);

        /// <summary>
        /// دریافت تالار گفتگو باز
        /// </summary>
        Task<Conversation> GetOpenConversationById(Guid id);

        /// <summary>
        /// اضافه کردن پیام
        /// </summary>
        Task<bool> AddMessage(Message message);

        /// <summary>
        /// دریافت پیام با آیدی
        /// </summary>
        Task<Message> GetMessageById(Guid id);

        /// <summary>
        /// دریافت کاربر با آیدی
        /// </summary>
        Task<User> GetUserById(Guid id);


        /// <summary>
        /// دریافت همه پیام های کاربر با شماره تلفن
        /// </summary>
        Task<List<Message>> GetAllUserMessagesByCellPhone(string cellphone);

        /// <summary>
        /// جست و جوی پیام های یک کاربر
        /// </summary>
        Task<List<Message>> SearchUserMessages(string cellphone, string searchBox);

        /// <summary>
        /// جستجوی پیام ها بین کل پیام ها
        /// </summary>
        Task<List<Message>> SearchMessages(string searchBox);

        /// <summary>
        /// همه پیام های پاک شده
        /// </summary>
        Task<List<Message>> AllDeletedMessage();

        /// <summary>
        /// همه پیام های پاک شده کاربر
        /// </summary>
        Task<List<Message>> AllUserDeletedMessages(string cellphone);


        /// <summary>
        /// ذخیره اعمال انجام شده
        /// </summary>
        Task<bool> UpdateMessages();

    }
}

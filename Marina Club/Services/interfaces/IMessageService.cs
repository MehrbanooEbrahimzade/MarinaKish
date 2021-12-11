using Marina_Club.Commands.Message;
using Marina_Club.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Marina_Club.Services.interfaces
{
    public interface IMessageService
    {
        /// <summary>
        /// اضافه کردن پیام
        /// </summary>
        Task<Guid?> AddMessageToConversation(AddMessageCommand command);

        /// <summary>
        /// دریافت همه پیام های کاربر
        /// </summary>
        Task<List<MessageDto>> GetAllUserMessages(Guid id); //user id( users model )

        /// <summary>
        /// جست و جوی پیام های یک کاربر
        /// </summary>
        Task<List<MessageDto>> SearchUserMessages(Guid id, SearchUserMessageCommand command); //user id( users model )

        /// <summary>
        /// جستجوی پیام ها بین کل پیام ها
        /// </summary>
        Task<List<MessageDto>> SearchMessages(SearchMessageCommand command);

        /// <summary>
        /// دریافت یک پیام
        /// </summary>
        Task<MessageDto> GetOneMessage(Guid id);

        /// <summary>
        /// حذف پیام
        /// </summary>
        Task<bool?> DeleteMessage(Guid id);

        /// <summary>
        /// همه پیام های پاک شده
        /// </summary>
        Task<List<MessageDto>> AllDeletedMessage();

        /// <summary>
        /// همه پیام های پاک شده کاربر
        /// </summary>
        Task<List<MessageDto>> AllUserDeletedMessages(Guid userid);

        /// <summary>
        /// ویرایش پیام
        /// </summary>
        Task<MessageDto> EditMessage(EditMessageCommand command); 

    }
}

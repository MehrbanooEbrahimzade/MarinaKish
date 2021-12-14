using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands.Message;
using Application.Dtos;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.Models.enums;
using Infrastructure.Repository.interfaces;

namespace Application.Services.classes
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        /// <summary>
        /// اضافه کردن پیام
        /// </summary>
        public async Task<Guid?> AddMessageToConversation(AddMessageCommand command)
        {
            var conversation = await _messageRepository.GetOpenConversationById(command.ConversationID);
            var user = await _messageRepository.GetUserById(command.UserID);
            if (conversation == null || user == null)
                return null;

            command.Username = user.PhoneNumber;
            var messageObj = command.ToModel();

            conversation.ForLastActivity(DateTime.Now);
            var addAndSave = await _messageRepository.AddMessage(messageObj);
            if (!addAndSave)
                return null;
            return messageObj.Id;
        }

        /// <summary>
        /// دریافت همه پیام های کاربر
        /// </summary>
        public async Task<List<MessageDto>> GetAllUserMessages(Guid id)
        {
            var user = await _messageRepository.GetUserById(id);
            var messages = await _messageRepository.GetAllUserMessagesByCellPhone(user.PhoneNumber);
            if (user == null || messages == null)
                return null;
            return messages.ToDto();
        }

        /// <summary>
        /// جست و جوی پیام های یک کاربر
        /// </summary>
        public async Task<List<MessageDto>> SearchUserMessages(Guid id, SearchUserMessageCommand command)
        {
            var user = await _messageRepository.GetUserById(id);
            var messages = await _messageRepository.SearchUserMessages(user.PhoneNumber, command.SearchBoxUserMessage);
            if (user == null || messages == null)
                return null;
            return messages.ToDto();

        }

        /// <summary>
        /// جستجوی پیام ها بین کل پیام ها
        /// </summary>
        public async Task<List<MessageDto>> SearchMessages(SearchMessageCommand command)
        {
            var messages = await _messageRepository.SearchMessages(command.SearchBox);
            if (messages == null)
                return null;
            return messages.ToDto();
        }

        /// <summary>
        /// دریافت یک پیام
        /// </summary>
        public async Task<MessageDto> GetOneMessage(Guid id)
        {
            var message = await _messageRepository.GetMessageById(id);
            if (message == null)
                return null;
            return message.ToDto();
        }

        /// <summary>
        /// حذف پیام
        /// </summary>
        public async Task<bool?> DeleteMessage(Guid id)
        {
            var message = await _messageRepository.GetMessageById(id);
            if (message == null)
                return null;
            message.MessageStatusSet(EMessageStatus.Deleted);
            return await _messageRepository.UpdateMessages();
        }

        /// <summary>
        /// همه پیام های پاک شده
        /// </summary>
        public async Task<List<MessageDto>> AllDeletedMessage()
        {
            var messages = await _messageRepository.AllDeletedMessage();
            if (messages.Count == 0)
                return null;
            return messages.ToDto();
        }

        /// <summary>
        /// همه پیام های پاک شده کاربر
        /// </summary>
        public async Task<List<MessageDto>> AllUserDeletedMessages(Guid userid)
        {
            var user = await _messageRepository.GetUserById(userid);
            var messages = await _messageRepository.AllUserDeletedMessages(user.PhoneNumber);
            if (user == null || messages == null)
                return null;
            return messages.ToDto();
        }

        /// <summary>
        /// ویرایش پیام
        /// </summary>
        public async Task<MessageDto> EditMessage(EditMessageCommand command)
        {
            var message = await _messageRepository.GetMessageById(command.MessageID);
            if (message == null)
            {
                return null;
                command.Text = command.EditedMessage;  
            }
            var save = await _messageRepository.UpdateMessages();
            if (!save)
                return null;
            return message.ToDto();
        }
    }
}

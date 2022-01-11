using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Application.Commands.Conversation;
using Application.Dtos;
using Application.Mappers;
using Application.Services.interfaces;

namespace Application.Services.classes
{
    public class ConversationService : IConversationService
    {
        //        private readonly IConversationRepository _conversationRepository;
        //        public ConversationService(IConversationRepository conversationRepository)
        //        {
        //            _conversationRepository = conversationRepository;
        //        }

        //        /// <summary>
        //        /// اضافه کردن تالار گفتگو
        //        /// </summary>
        //        public async Task<Guid?> AddConversation(AddConversationCommand command)
        //        {

        //            var conversationObj = command.ToModel();

        //            var addAndSave = await _conversationRepository.AddConversation(conversationObj);
        //            if (!addAndSave)
        //                return null;
        //            return conversationObj.commentId;
        //        }

        //        /// <summary>
        //        /// بستن تالار گفتگو
        //        /// </summary>
        //        public async Task<States?> CloseConversation(Guid id)
        //        {
        //            var conversation = await _conversationRepository.GetOpenConversationById(id);
        //            if (conversation == null)
        //                return null;
        //              conversation.ForStates(States.Closed);


        //            var save = await _conversationRepository.UpdateConversation();
        //            if (!save)
        //                return null;
        //            conversation.ForStates(States.Open);
        //               return null;
        //        }

        //        /// <summary>
        //        /// دوباره باز کردن تالار گفتگو
        //        /// </summary>
        //        public async Task<States?> ReOpenConversation(Guid id)
        //        {
        //            var conversation = await _conversationRepository.GetClosedConversationById(id);
        //            if (conversation == null)
        //                return null;
        //            conversation.ForStates(States.Open);

        //            var save = await _conversationRepository.UpdateConversation();
        //            if (!save)
        //                return null;
        //            return conversation.State;
        //        }

        //        /// <summary>
        //        /// کم اهمیت کردن تالار گفتگو
        //        /// </summary>
        //        public async Task<Priority?> ChangeConversationToLessPriority(Guid id)
        //        {
        //            var conversation = await _conversationRepository.GetOpenConversationById(id);
        //            if (conversation == null)
        //                return null;
        //            conversation.ForPriority(Priority.Less);

        //            var save = await _conversationRepository.UpdateConversation();
        //            if (!save)
        //                return null;
        //            return conversation.Priority;
        //        }

        //        /// <summary>
        //        /// تغییر اهمیت تالار گفتگو به سطح متوسط
        //        /// </summary>
        //        public async Task<Priority?> ChangeConversationToMediumPriority(Guid id)
        //        {
        //            var conversation = await _conversationRepository.GetOpenConversationById(id);
        //            if (conversation == null)
        //                return null;
        //            conversation.ForPriority(Priority.Medium);

        //            var save = await _conversationRepository.UpdateConversation();
        //            if (!save)
        //                return null;
        //            return conversation.Priority;
        //        }

        //        /// <summary>
        //        /// تغییر اهمیت تالار گفتگو به سطح زیاد
        //        /// </summary>
        //        public async Task<Priority?> ChangeConversationToHighPriority(Guid id)
        //        {
        //            var conversation = await _conversationRepository.GetOpenConversationById(id);
        //            if (conversation == null)
        //                return null;
        //            conversation.ForPriority(Priority.High);

        //            var save = await _conversationRepository.UpdateConversation();
        //            if (!save)
        //                return null;
        //            return conversation.Priority;
        //        }

        //        /// <summary>
        //        /// دریافت یک تالار گفتگو
        //        /// </summary>
        //        public async Task<ConversationDto> GetOneConversation(Guid id)
        //        {
        //            var conversation = await _conversationRepository.GetConversationById(id);
        //            if (conversation == null)
        //                return null;
        //            var conversationDto = conversation.ToDto();
        //            var conversationMessages = await _conversationRepository.GetAllConversationMessageById(id);

        //            if (conversationMessages != null)
        //                conversationDto.RecentMessages = conversationMessages.ToDto();
        //            return conversationDto;
        //        }

        //        /// <summary>
        //        /// دریافت همه تالار گفتگوها
        //        /// </summary>
        //        public async Task<List<ConversationDto>> GetAllConversation()
        //        {
        //            var conversations = await _conversationRepository.GetAllConversations();
        //            foreach (var conversation in conversations)
        //            {
        //                var conversationMessages = await _conversationRepository.GetAllConversationMessageById(conversation.commentId);
        //                if (conversationMessages != null)
        //                    conversation.ToDto().RecentMessages = conversationMessages.ToDto();
        //            }
        //            return conversations.ToDto();
        //        }

        //        /// <summary>
        //        /// دریافت همه پیام های یک تالار گفت و گو
        //        /// </summary>
        //        public async Task<List<MessageDto>> AllConversationMessages(Guid id)
        //        {
        //            var messages = await _conversationRepository.GetAllConversationMessageById(id);
        //            if (messages == null)
        //                return null;
        //            return messages.ToDto();
        //        }

        //        /// <summary>
        //        /// جست و جوی پیام در یک تالار گفت و گو
        //        /// </summary>
        //        public async Task<List<MessageDto>> SearchConversationMessage(SearchMessageCommand command)
        //        {
        //            var messages = await _conversationRepository.SearchConversationMessage(command.ConversationId, command.SearchBox);
        //            if (messages == null)
        //                return null;
        //            return messages.ToDto();
        //        }

        //        /// <summary>
        //        /// دریافت کل پیام های حذف شده یک تالار گفتگو
        //        /// </summary>
        //        public async Task<List<MessageDto>> AllConversationDeletedMessages(Guid id)
        //        {
        //            var deletedMessages = await _conversationRepository.GetAllConversationDeletedMessageById(id);
        //            if (deletedMessages == null)
        //                return null;
        //            return deletedMessages.ToDto();
        //        }

        //        /// <summary>
        //        /// دریافت همه تالار گفتگوهای باز با اهمیت کم
        //        /// </summary>
        //        public async Task<List<ConversationDto>> GetAllOpenLessPriorityConversations()
        //        {
        //            var conversations = await _conversationRepository.GetAllOpenLessPriorityConversations();
        //            if (conversations.Count == 0)
        //                return null;
        //            return conversations.ToDto();
        //        }

        //        /// <summary>
        //        /// دریافت همه تالار گفتگوهای بسته با اهمیت کم
        //        /// </summary>
        //        public async Task<List<ConversationDto>> GetAllClosedLessPriorityConversations()
        //        {
        //            var conversations = await _conversationRepository.GetAllClosedLessPriorityConversations();
        //            if (conversations.Count == 0)
        //                return null;
        //            return conversations.ToDto();
        //        }

        //        /// <summary>
        //        /// دریافت همه تالار گفتگوهای باز با اهمیت متوسط
        //        /// </summary>
        //        public async Task<List<ConversationDto>> GetAllOpenMediumPriorityConversations()
        //        {
        //            var conversations = await _conversationRepository.GetAllOpenMediumPriorityConversations();
        //            if (conversations.Count == 0)
        //                return null;
        //            return conversations.ToDto();
        //        }

        //        /// <summary>
        //        /// دریافت همه تالار گفتگوهای بسته با اهمیت متوسط
        //        /// </summary>
        //        public async Task<List<ConversationDto>> GetAllClosedMediumPriorityConversations()
        //        {
        //            var conversations = await _conversationRepository.GetAllClosedMediumPriorityConversations();
        //            if (conversations.Count == 0)
        //                return null;
        //            return conversations.ToDto();
        //        }

        //        /// <summary>
        //        /// دریافت همه تالار گفتگوهای باز با اهمیت زیاد
        //        /// </summary>
        //        public async Task<List<ConversationDto>> GetAllOpenHighPriorityConversations()
        //        {
        //            var conversations = await _conversationRepository.GetAllOpenHighPriorityConversations();
        //            if (conversations.Count == 0)
        //                return null;
        //            return conversations.ToDto();
        //        }

        //        /// <summary>
        //        /// دریافت همه تالار گفتگوهای باز با اهمیت زیاد
        //        /// </summary>
        //        public async Task<List<ConversationDto>> GetAllClosedHighPriorityConversations()
        //        {
        //            var conversations = await _conversationRepository.GetAllClosedHighPriorityConversations();
        //            if (conversations.Count == 0)
        //                return null;
        //            return conversations.ToDto();
        //        }
    }
}

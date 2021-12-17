using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands.Conversation;
using Application.Dtos;

namespace Application.Services.interfaces
{
    public interface IConversationService
    {
        ///// <summary>
        ///// اضافه کردن تالار گفتگو
        ///// </summary>
        //Task<Guid?> AddConversation(AddConversationCommand command);

        ///// <summary>
        ///// بستن تالار گفتگو
        ///// </summary>
        //Task<States?> CloseConversation(Guid id);

        ///// <summary>
        ///// دوباره باز کردن تالار گفتگو
        ///// </summary>
        //Task<States?> ReOpenConversation(Guid id);

        ///// <summary>
        ///// کم اهمیت کردن تالار گفتگو
        ///// </summary>
        //Task<Priority?> ChangeConversationToLessPriority(Guid id);

        ///// <summary>
        ///// تغییر اهمیت تالار گفتگو به سطح متوسط
        ///// </summary>
        //Task<Priority?> ChangeConversationToMediumPriority(Guid id);

        ///// <summary>
        ///// تغییر اهمیت تالار گفتگو به سطح زیاد
        ///// </summary>
        //Task<Priority?> ChangeConversationToHighPriority(Guid id);

        ///// <summary>
        ///// دریافت یک تالار گفتگو
        ///// </summary>
        //Task<ConversationDto> GetOneConversation(Guid id);

        ///// <summary>
        ///// دریافت همه تالار گفتگوها
        ///// </summary>
        //Task<List<ConversationDto>> GetAllConversation();

        ///// <summary>
        ///// دریافت همه تالار گفتگوهای باز با اهمیت کم
        ///// </summary>
        //Task<List<ConversationDto>> GetAllOpenLessPriorityConversations();

        ///// <summary>
        ///// دریافت همه تالار گفتگوهای بسته با اهمیت کم
        ///// </summary>
        //Task<List<ConversationDto>> GetAllClosedLessPriorityConversations();

        ///// <summary>
        ///// دریافت همه تالار گفتگوهای باز با اهمیت متوسط
        ///// </summary>
        //Task<List<ConversationDto>> GetAllOpenMediumPriorityConversations();

        ///// <summary>
        ///// دریافت همه تالار گفتگوهای بسته با اهمیت متوسط
        ///// </summary>
        //Task<List<ConversationDto>> GetAllClosedMediumPriorityConversations();

        ///// <summary>
        ///// دریافت همه تالار گفتگوهای باز با اهمیت زیاد
        ///// </summary>
        //Task<List<ConversationDto>> GetAllOpenHighPriorityConversations();

        ///// <summary>
        ///// دریافت همه تالار گفتگوهای بسته با اهمیت زیاد
        ///// </summary>
        //Task<List<ConversationDto>> GetAllClosedHighPriorityConversations();

        ///// <summary>
        ///// دریافت همه پیام های یک تالار گفت و گو
        ///// </summary>
        //Task<List<MessageDto>> AllConversationMessages(Guid id);

        ///// <summary>
        ///// جست و جوی پیام در یک تالار گفت و گو
        ///// </summary>
        //Task<List<MessageDto>> SearchConversationMessage(SearchMessageCommand command);

        ///// <summary>
        ///// دریافت کل پیام های حذف شده یک تالار گفتگو
        ///// </summary>
        //Task<List<MessageDto>> AllConversationDeletedMessages(Guid id);
    }
}

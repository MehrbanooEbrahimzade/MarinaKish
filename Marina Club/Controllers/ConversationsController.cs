using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.Conversation;
using Application.Services.interfaces;

namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationsController : ApiController
    {
        private readonly IConversationService _conversationService;
        public ConversationsController(IConversationService conversationService)
        {
            _conversationService = conversationService;
        }

        /// <summary>
        /// اضافه کردن تالار گفتگو
        /// </summary>
        [HttpPost("Add")]
        public async Task<IActionResult> AddConversation(AddConversationCommand command)
        {
            if (!command.Validate())
                return BadReq(ApiMessage.EnterTitleOfConversation, new { Reason = $"enter title of conversation!" });

            var result = await _conversationService.AddConversation(command);
            if (result == null)
                return BadReq(ApiMessage.ConversationNotAdded, new { Reason = $"there is a problem when adding conversation. TryAgain!" });
            return OkResult(ApiMessage.ConversationAdded, new { ConversationID = $"{result.Value}" });
        }

        /// <summary>
        /// بستن تالار گفتگو
        /// </summary>
        [HttpPut("Close/{id}")]
        public async Task<IActionResult> CloseConversation(Guid id)
        {
            var result = await _conversationService.CloseConversation(id);
            if (result == null)
                return BadReq(ApiMessage.ConversationNotFound, new { Reason = $"1-Conversation already closed, 2-conversation not found, 3-there is a problem when saveChanges. TryAgain!" });
            return OkResult(ApiMessage.ConversationClosed, new { ConversationState = $"{result.Value} / Closed" });
        }

        /// <summary>
        /// دوباره باز کردن تالار گفتگو
        /// </summary>
        [HttpPut("ReOpen/{id}")]
        public async Task<IActionResult> ReOpenConversation(Guid id, IdCommand command)
        {
            var result = await _conversationService.ReOpenConversation(id);
            if (result == null)
                return BadReq(ApiMessage.ConversationNotFound, new { Reason = $"1-conversation already Opened, 2-Conversation not found, 3-there is a problem when saveChanges. TryAgain!" });
            return OkResult(ApiMessage.ConversationReOpened, new { ConversationState = $"{result.Value} / Opened" });
        }

        /// <summary>
        /// کم اهمیت کردن تالار گفتگو
        /// </summary>
        [HttpPut("ChangeToLessPriority/{id}")]
        public async Task<IActionResult> ChangeConversationToLessPriority(Guid id)
        {
            var result = await _conversationService.ChangeConversationToLessPriority(id);
            if (result == null)
                return BadReq(ApiMessage.ConversationNotFound, new { Reason = $"1-Conversation isn't open, 2-conversation already less priority" });
            return OkResult(ApiMessage.ConversationChangeToLessPriority, new { ConversationPriority = $"{result.Value} / Less" });
        }

        /// <summary>
        /// تغییر اهمیت تالار گفتگو به سطح متوسط
        /// </summary>
        [HttpPut("ChangeToMediumPriority/{id}")]
        public async Task<IActionResult> ChangeConversationToMediumPriority(Guid id)
        {
            var result = await _conversationService.ChangeConversationToMediumPriority(id);
            if (result == null)
                return BadReq(ApiMessage.ConversationNotFound, new { Reason = $"1-Conversation isn't open, 2-conversation already medium priority" });
            return OkResult(ApiMessage.ConversationChangeToMediumPriority, new { ConversationPriority = $"{result.Value} / Medium" });
        }

        /// <summary>
        /// تغییر اهمیت تالار گفتگو به سطح زیاد
        /// </summary>
        [HttpPut("ChangeToHighPriority/{id}")]
        public async Task<IActionResult> ChangeConversationToHighPriority(Guid id)
        {
            var result = await _conversationService.ChangeConversationToHighPriority(id);
            if (result == null)
                return BadReq(ApiMessage.ConversationNotFound, new { Reason = $"1-Conversation isn't open, 2-conversation already high priority" });
            return OkResult(ApiMessage.ConversationChangeToHighPriority, new { ConversationPriority = $"{result.Value} / High" });
        }

        /// <summary>
        /// دریافت یک تالار گفتگو
        /// </summary>
        [HttpGet("GetOne/{id}")]
        public async Task<IActionResult> GetOneConversation(Guid id)
        {
            var result = await _conversationService.GetOneConversation(id);
            if (result == null)
                return BadReq(ApiMessage.ConversationNotFound, new { Reason = $"Conversation not found" });
            return OkResult(ApiMessage.GetConversation, new { Conversation = result });
        }

        #region All Conversation Options

        #region Less Priority Options
        /// <summary>
        /// دریافت همه تالار گفتگوهای باز با اهمیت کم
        /// </summary>
        [HttpGet("AllOpenConversations-LessPriority")]
        public async Task<IActionResult> GetAllOpenLessPriorityConversation()
        {
            var result = await _conversationService.GetAllOpenLessPriorityConversations();
            if (result == null)
                return BadReq(ApiMessage.MarineNotHaveOpenLessPriorityConversations, new { OpenConversationCount = $"0 - marine not have any open less priority conversation" });
            return OkResult(ApiMessage.GetAllOpenLessPriorityConversations, new { OpenConversations = result });
        }

        /// <summary>
        /// دریافت تعداد همه تالار گفتگوهای باز با اهمیت کم
        /// </summary>
        [HttpGet("AllOpenConversations-LessPriority-Count")]
        public async Task<IActionResult> GetAllOpenLessPriorityConversationCount()
        {
            var result = await _conversationService.GetAllOpenLessPriorityConversations();
            if (result == null)
                return BadReq(ApiMessage.MarineNotHaveOpenLessPriorityConversations, new { OpenConversationCount = $"0 - marine not have any open less priority conversation" });
            return OkResult(ApiMessage.GetAllOpenLessPriorityConversations, new { OpenConversationsCount = result.Count });
        }

        /// <summary>
        /// دریافت همه تالار گفتگوهای بسته با اهمیت کم
        /// </summary>
        [HttpGet("AllClosedConversations-LessPriority")]
        public async Task<IActionResult> GetAllClosedLessPriorityConversation()
        {
            var result = await _conversationService.GetAllClosedLessPriorityConversations();
            if (result == null)
                return BadReq(ApiMessage.MarineNotHaveClosedLessPriorityConversations, new { ClosedConversationCount = $"0 - marine not have any closed less priority conversation" });
            return OkResult(ApiMessage.GetAllClosedLessPriorityConversations, new { ClosedConversations = result });
        }

        /// <summary>
        /// دریافت تعداد همه تالار گفتگوهای بسته با اهمیت کم
        /// </summary>
        [HttpGet("AllClosedConversations-LessPriority-Count")]
        public async Task<IActionResult> GetAllClosedLessPriorityConversationCount()
        {
            var result = await _conversationService.GetAllClosedLessPriorityConversations();
            if (result == null)
                return BadReq(ApiMessage.MarineNotHaveClosedLessPriorityConversations, new { ClosedConversationCount = $"0 - marine not have any closed less priority conversation" });
            return OkResult(ApiMessage.GetAllClosedLessPriorityConversations, new { ClosedConversationsCount = result.Count });
        }

        #endregion

        #region Medium Priority Options

        /// <summary>
        /// دریافت همه تالار گفتگوهای باز با اهمیت متوسط
        /// </summary>
        [HttpGet("AllOpenConversations-MediumPriority")]
        public async Task<IActionResult> GetAllOpenMediumPriorityConversation()
        {
            var result = await _conversationService.GetAllOpenMediumPriorityConversations();
            if (result == null)
                return BadReq(ApiMessage.MarineNotHaveOpenMediumPriorityConversations, new { OpenConversationCount = $"0 - marine not have any open medium priority conversation" });
            return OkResult(ApiMessage.GetAllOpenMediumPriorityConversations, new { OpenConversations = result });
        }

        /// <summary>
        /// دریافت تعداد همه تالار گفتگوهای باز با اهمیت متوسط
        /// </summary>
        [HttpGet("AllOpenConversations-MediumPriority-Count")]
        public async Task<IActionResult> GetAllOpenMediumPriorityConversationCount()
        {
            var result = await _conversationService.GetAllOpenMediumPriorityConversations();
            if (result == null)
                return BadReq(ApiMessage.MarineNotHaveOpenMediumPriorityConversations, new { OpenConversationCount = $"0 - marine not have any open medium priority conversation" });
            return OkResult(ApiMessage.GetAllOpenMediumPriorityConversations, new { OpenConversationsCount = result.Count });
        }

        /// <summary>
        /// دریافت همه تالار گفتگوهای بسته با اهمیت متوسط
        /// </summary>
        [HttpGet("AllClosedConversations-MediumPriority")]
        public async Task<IActionResult> GetAllClosedMediumPriorityConversation()
        {
            var result = await _conversationService.GetAllClosedMediumPriorityConversations();
            if (result == null)
                return BadReq(ApiMessage.MarineNotHaveClosedMediumPriorityConversations, new { ClosedConversationCount = $"0 - marine not have any closed medium priority conversation" });
            return OkResult(ApiMessage.GetAllClosedMediumPriorityConversations, new { ClosedConversations = result });
        }

        /// <summary>
        /// دریافت تعداد همه تالار گفتگوهای بسته با اهمیت متوسط
        /// </summary>
        [HttpGet("AllClosedConversations-MediumPriority-Count")]
        public async Task<IActionResult> GetAllClosedMediumPriorityConversationCount()
        {
            var result = await _conversationService.GetAllClosedMediumPriorityConversations();
            if (result == null)
                return BadReq(ApiMessage.MarineNotHaveClosedMediumPriorityConversations, new { ClosedConversationCount = $"0 - marine not have any closed medium priority conversation" });
            return OkResult(ApiMessage.GetAllClosedMediumPriorityConversations, new { ClosedConversationsCount = result.Count });
        }

        #endregion

        #region High Priority Options
        /// <summary>
        /// دریافت همه تالار گفتگوهای باز با اهمیت زیاد
        /// </summary>
        [HttpGet("AllOpenConversations-HighPriority")]
        public async Task<IActionResult> GetAllOpenHighPriorityConversation()
        {
            var result = await _conversationService.GetAllOpenHighPriorityConversations();
            if (result == null)
                return BadReq(ApiMessage.MarineNotHaveOpenHighPriorityConversations, new { OpenConversationCount = $"0 - marine not have any open High priority conversation" });
            return OkResult(ApiMessage.GetAllOpenHighPriorityConversations, new { OpenConversations = result });
        }

        /// <summary>
        /// دریافت تعداد همه تالار گفتگوهای باز با اهمیت زیاد
        /// </summary>
        [HttpGet("AllOpenConversations-HighPriority-Count")]
        public async Task<IActionResult> GetAllOpenHighPriorityConversationCount()
        {
            var result = await _conversationService.GetAllOpenHighPriorityConversations();
            if (result == null)
                return BadReq(ApiMessage.MarineNotHaveOpenHighPriorityConversations, new { OpenConversationCount = $"0 - marine not have any open High priority conversation" });
            return OkResult(ApiMessage.GetAllOpenHighPriorityConversations, new { OpenConversationsCount = result.Count });
        }

        /// <summary>
        /// دریافت همه تالار گفتگوهای بسته با اهمیت زیاد
        /// </summary>
        [HttpGet("AllClosedConversations-HighPriority")]
        public async Task<IActionResult> GetAllClosedHighPriorityConversation()
        {
            var result = await _conversationService.GetAllClosedMediumPriorityConversations();
            if (result == null)
                return BadReq(ApiMessage.MarineNotHaveClosedHighPriorityConversations, new { ClosedConversationCount = $"0 - marine not have any closed high priority conversation" });
            return OkResult(ApiMessage.GetAllClosedHighPriorityConversations, new { ClosedConversations = result });
        }

        /// <summary>
        /// دریافت تعداد همه تالار گفتگوهای بسته با اهمیت زیاد
        /// </summary>
        [HttpGet("AllClosedConversations-HighPriority-Count")]
        public async Task<IActionResult> GetAllClosedHighPriorityConversationCount()
        {
            var result = await _conversationService.GetAllClosedHighPriorityConversations();
            if (result == null)
                return BadReq(ApiMessage.MarineNotHaveClosedHighPriorityConversations, new { ClosedConversationCount = $"0 - marine not have any closed High priority conversation" });;
            return OkResult(ApiMessage.GetAllClosedHighPriorityConversations, new { ClosedConversationsCount = result.Count });
        }

        #endregion

        /// <summary>
        /// دریافت همه تالار گفتگوها
        /// </summary>
        [HttpGet("AllConversations")]
        public async Task<IActionResult> GetAllConversation()
        {
            var result = await _conversationService.GetAllConversation();
            return OkResult(ApiMessage.GetAllConversation, new { Conversations = result });
        }

        /// <summary>
        /// دریافت تعداد همه تالار گفتگوها
        /// </summary>
        [HttpGet("AllConversations-Count")] // 
        public async Task<IActionResult> GetAllConversationCount()
        {
            var result = await _conversationService.GetAllConversation();
            return OkResult(ApiMessage.GetAllConversation, new { ConversationsCount = result.Count });
        }

        #endregion
        /// <summary>
        /// دریافت همه پیام های یک تالار گفت و گو
        /// </summary>
        [HttpGet("AllMessages/{id}")]
        public async Task<IActionResult> AllConversationMessages(Guid id)
        {
            var result = await _conversationService.AllConversationMessages(id);
            if (result == null)
                return BadReq(ApiMessage.ConversationNotHaveMessages, new { Reasons = $"1-conversation not have any messsge, 2-conversation not found" });
            return OkResult(ApiMessage.GetAllConversationMessages, new { Messages = result });
        }

        /// <summary>
        /// دریافت تعداد همه پیام های یک تالار گفت و گو
        /// </summary>
        [HttpGet("AllMessages-Count/{id}")]
        public async Task<IActionResult> AllConversationMessagesCount(Guid id)
        {
            var result = await _conversationService.AllConversationMessages(id);
            if (result == null)
                return BadReq(ApiMessage.ConversationNotHaveMessages, new { Reasons = $"1-conversation not have any messsge, 2-conversation not found" });
            return OkResult(ApiMessage.GetAllConversationMessages, new { MessagesCount = result.Count });
        }

        /// <summary>
        /// دریافت کل پیام های حذف شده یک تالار گفتگو
        /// </summary>
        [HttpGet("AllDeletedMessages/{id}")]
        public async Task<IActionResult> AllConversationDeletedMessages(Guid id)
        {
            var result = await _conversationService.AllConversationDeletedMessages(id);
            if (result == null)
                return BadReq(ApiMessage.ConversationNotHaveDeletedMessages, new { Reasons = $"1-conversation not have any deleted messsge, 2-conversation not found" });
            return OkResult(ApiMessage.GetAllConversationDeletedMessages, new { Messages = result });
        }

        /// <summary>
        /// دریافت تعداد کل پیام های حذف شده یک تالار گفتگو
        /// </summary>
        [HttpGet("AllDeletedMessages-Count/{id}")]
        public async Task<IActionResult> AllConversationDeletedMessagesCount(Guid id)
        {
            var result = await _conversationService.AllConversationDeletedMessages(id);
            if (result == null)
                return BadReq(ApiMessage.ConversationNotHaveDeletedMessages, new { Reasons = $"1-conversation not have any deleted messsge, 2-conversation not found" });
            return OkResult(ApiMessage.GetAllConversationDeletedMessages, new { Messages = result.Count });
        }

        /// <summary>
        /// جست و جوی پیام در یک تالار گفت و گو
        /// </summary>
        [HttpGet("SearchMessage/{id}")]
        public async Task<IActionResult> SearchConversationMessage(Guid id, SearchMessageCommand command)
        {
            command.ConversationId = id;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongConversationID, new { Reason = $"1-pls enter conversationID, 2-enter what to search" });

            var result = await _conversationService.SearchConversationMessage(command);
            if (result == null)
                return BadReq(ApiMessage.NotFoundedConversationMessage, new { Reasons = $"1-searched message not found, 2-conversation not found. check the id and tryAgain" });
            return OkResult(ApiMessage.FoundedConversationMessage, new { Messages = result });
        }

        /// <summary>
        /// جست و جوی تعداد پیام در یک تالار گفت و گو
        /// </summary>
        [HttpGet("SearchMessage-Count/{id}")]//
        public async Task<IActionResult> SearchConversationMessageCount(Guid id, SearchMessageCommand command)
        {
            command.ConversationId = id;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongConversationID, new { Reason = $"1-pls enter conversationID, 2-enter what to search" });

            var result = await _conversationService.SearchConversationMessage(command);
            if (result == null)
                return BadReq(ApiMessage.NotFoundedConversationMessage, new { Reasons = $"1-searched message not found, 2-conversation not found. check the id and tryAgain" });
            return OkResult(ApiMessage.FoundedConversationMessage, new { FoundedMessagesCount = result.Count });
        }
    }
}

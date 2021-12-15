using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Application.Commands;
using Application.Commands.Message;
using Application.Services.interfaces;

namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ApiController
    {
        //private readonly IMessageService _messageService;
        //public MessagesController(IMessageService messageService)
        //{
        //    _messageService = messageService;
        //}

        ///// <summary>
        ///// اضافه کردن پیام
        ///// </summary>
        //[HttpPost("Add/{id}")] // conversation id
        //public async Task<IActionResult> AddMessageToConversation(Guid id, AddMessageCommand command)
        //{
        //    command.ConversationID = id;
        //    if (!command.Validate())
        //        return BadReq(ApiMessage.WrongConversationID, new { Reasons = $"1-enter conversationID pls, 2-enter userID pls, 3-enter message" });

        //    var result = await _messageService.AddMessageToConversation(command);
        //    if (result == null)
        //        return BadReq(ApiMessage.MessageNotAddedToConversation, new { Reasons = $"1-conversation closed, 2-conversation not found, 3-user not found, 3-there is a problem when add and saving message.TryAgain!" });
        //    return OkResult(ApiMessage.MessageAddedToConversation, new { MessageID = $"{result}" });
        //}

        ///// <summary>
        ///// دریافت یک پیام
        ///// </summary>
        //[HttpGet("GetOne/{id}")]
        //public async Task<IActionResult> GetOneMessage(Guid id, IdCommand command)
        //{
        //    command.ID = id;
        //    if (!command.Validate())
        //        return BadReq(ApiMessage.WrongMessageID, new { Reason = $"enter messageID" });

        //    var result = await _messageService.GetOneMessage(id);
        //    if (result == null)
        //        return BadReq(ApiMessage.MessageNotFound, new { Reasons = $"1-message is deleted, 2-wrong message id" });
        //    return OkResult(ApiMessage.GetMessage, new { Message = result });
        //}

        ///// <summary>
        ///// جستجوی پیام ها بین کل پیام ها
        ///// </summary>
        //[HttpGet("AllMessagesSearch")]
        //public async Task<IActionResult> SearchMessages(SearchMessageCommand command)
        //{
        //    if (!command.Validate())
        //        return BadReq(ApiMessage.MessageForSearchNotFound, new { Reason = $"enter your searched message" });

        //    var result = await _messageService.SearchMessages(command);
        //    if (result == null)
        //        return BadReq(ApiMessage.SearchedMessageNotFound, new { Reason = $"Searched message not found" });
        //    return OkResult(ApiMessage.SearchedMessageFound, new { Messages = result });
        //}

        ///// <summary>
        ///// حذف پیام
        ///// </summary>
        //[HttpPut("Delete/{id}")]
        //public async Task<IActionResult> DeleteMessage(Guid id, IdCommand command)
        //{
        //    command.ID = id;
        //    if (!command.Validate())
        //        return BadReq(ApiMessage.WrongMessageID, new { Reason = $"enter messageID" });

        //    var result = await _messageService.DeleteMessage(id);
        //    if (result == null)
        //        return BadReq(ApiMessage.MessageNotFound, new { Reasons = $"1-message is deleted, 2-wrong message id" });
        //    return OkResult(ApiMessage.MessageDeleted, new { IsDelete = $"{result} / Deleted" });
        //}

        ///// <summary>
        ///// همه پیام های پاک شده
        ///// </summary>
        //[HttpGet("AllDeleted")]
        //public async Task<IActionResult> AllDeletedMessage()
        //{
        //    var result = await _messageService.AllDeletedMessage();
        //    if (result == null)
        //        return BadReq(ApiMessage.MarineNotHaveDeleteMessage);
        //    return OkResult(ApiMessage.GetAllDeletedMessage, new { Messages = result });
        //}

        ///// <summary>
        ///// ویرایش پیام
        ///// </summary>
        //[HttpPut("Edit/{id}")]
        //public async Task<IActionResult> EditMessage(Guid id, EditMessageCommand command)
        //{
        //    command.MessageID = id;
        //    if (!command.Validate())
        //        return BadReq(ApiMessage.WrongMessageID, new { Reasons = $"1-enter message id, 2-enter your editing message" });

        //    var result = await _messageService.EditMessage(command);
        //    if (result == null)
        //        return OkResult(ApiMessage.MessageNotFound, new { Reasons = $"1-message is deleted, 2-message with this id not found" });
        //    return OkResult(ApiMessage.MessageEdited, new { Message = result });
        //}

        //#region UsersOptions
        ///// <summary>
        ///// دریافت همه پیام های کاربر
        ///// </summary>
        //[HttpGet("AllUserMessages/{id}")] //user id( users model )
        //public async Task<IActionResult> GetAllUserMessages(Guid id, IdCommand command)
        //{
        //    command.ID = id;
        //    if (!command.Validate())
        //        return BadReq(ApiMessage.WrongMessageID, new { Reasons = $"enter message id" });

        //    var result = await _messageService.GetAllUserMessages(id);
        //    if (result == null)
        //        return BadReq(ApiMessage.UserNotHaveMessage, new { Reasons = $"1-User not have message, 2-user with this id not found" });
        //    return OkResult(ApiMessage.GetAllUserMessage, new { UserMessages = result });//
        //}

        ///// <summary>
        ///// جست و جوی پیام های یک کاربر
        ///// </summary>
        //[HttpGet("UserMessagesSearch/{id}")] //user id( users model )
        //public async Task<IActionResult> SearchUserMessages(Guid id, SearchUserMessageCommand command)
        //{
        //    command.Userid = id;
        //    if (!command.Validate())
        //        return BadReq(ApiMessage.WrongUserID, new { Reason = $"enter user id" });

        //    var result = await _messageService.SearchUserMessages(id, command);
        //    if (result == null)
        //        return BadReq(ApiMessage.SearchedUserMessageNotFound, new { Reasons = $"1-Text not found, 2-user id is wrong " });
        //    return OkResult(ApiMessage.SearchedUserMessageFound, new { UserMessages = result });
        //}

        ///// <summary>
        ///// همه پیام های پاک شده کاربر
        ///// </summary>
        //[HttpGet("AllUserDeleted/{id}")] //user id (user models)
        //public async Task<IActionResult> AllUserDeletedMessages(Guid id, IdCommand command)
        //{
        //    command.ID = id;
        //    if (!command.Validate())
        //        return BadReq(ApiMessage.WrongUserID, new { Reason = $"enter user id" });

        //    var result = await _messageService.AllUserDeletedMessages(id);
        //    if (result == null)
        //        return BadReq(ApiMessage.UserNotHaveDeletedMessage, new { Reasons = $"1-User not have deleted messages, 2-user not found" });
        //    return OkResult(ApiMessage.GetAllUserDeletedMessage, new { UserDeletedMessages = result });
        //}
        //#endregion
    }
}

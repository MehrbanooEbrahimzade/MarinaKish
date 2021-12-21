using System;
using System.Collections.Generic;
using Application.Commands.Comment;
using Application.Commands.ContactInfo;
using Application.Commands.Conversation;
using Application.Commands.Fun;
using Application.Commands.Message;
using Application.Commands.User;
using Application.Validators.User;
using Domain.Models;

namespace Application.Mappers
{
    public static class CommandToModelMapper
    {
        public static CreditCard ToModel(this UpdateCreditCard command)
        {
            return new CreditCard(command.ShabaNumber, command.CardNumber,command.UserId);
        }
        /// <summary>
        /// تبدیل کردن کامند به کاربر
        ///// </summary>
        //public static User ToModel(this GetPhoneAndSetVerifyCodeCommand command)
        //{
        //    return new User(command.PhoneNumber,command.FullName,command.UserName,command.Password,command.NationalCode);

        //}

        ///// <summary>
        ///// تبدیل کردن کامند به تفریح
        ///// </summary>
        //public static Fun ToModel(this AddFunCommand command)
        //{
        //    return new Fun(command.FunType,  TimeSpan.Parse(command.Start),
        //        TimeSpan.Parse(command.End),
        //        command.SansDuration, command.SansTotalCapacity, command.SansGapTime, command.About);
        //}

        /// <summary>
        /// تبدیل کردن کامند به سانس
        /// </summary>
         //public static Schedule ToModel(this AddScheduleCommand command) 
         //{
         //     return new Schedule(command.SystemFunCode, command.FunType, command.ExecuteDateTime, command.Price,
         //         TimeSpan.Parse(command.Start), TimeSpan.Parse(command.End))
         //     {
         //         AvailableCapacity = command.AvailableCapacity
         //     };
         //}

        /// <summary>
        /// تبدیل کردن کامند به بلیط
        /// </summary>
        /*public static Ticket ToModel(this AddTicketCommand command)
        {
            return new Ticket(command.FunType, command.ExecuteDate, command.Start, command.End, command.NumberOfTicket)
            {
                #region Set

                FunId = command.FunId,
                ScheduleId = command.ScheduleId,
                Price = command.Price, 
                PhoneNumber = command.PhoneNumber,
                FullName = command.FullName

                #endregion
            };
        }*/

        /// <summary>
        /// تبدیل کردن کامند به کامنت
        /// </summary>
        public static Comment ToModel(this AddCommentCommand command)
        {
            return new Comment(command.Message, command.FunId, command.PhoneNumber,
                command.UserName);

        }




        public static Conversation ToModel(this AddConversationCommand command)
        {
            return new Conversation(command.Title);
        }

        public static Message ToModel(this AddMessageCommand command)
        {
            return new Message(command.Username, command.Message, command.ConversationID);
        }

   
    }
}

using System;
using System.Collections.Generic;
using Application.Commands.Comment;
using Application.Commands.ContactInfo;
using Application.Commands.Conversation;
using Application.Commands.Fun;
using Application.Commands.Message;
using Application.Commands.User;
using Domain.Models;

namespace Application.Mappers
{
    public static class CommandToModelMapper
    {
        /// <summary>
        /// تبدیل کردن کامند به کاربر
        /// </summary>
        public static User ToModel(this GetPhoneAndSetVerifyCodeCommand command)
        {
            return new User(command.CellPhone)
            {
            };
        }

        /// <summary>
        /// تبدیل کردن کامند به اطلاعات کانتکت
        /// </summary>
        public static ContactInfo ToModel(this AddContactInfoCommand command)
        {
            return new ContactInfo(command.Phone , command.Email ,command.Address);
           
        }

        /// <summary>
        /// تبدیل کردن کامند به تفریح
        /// </summary>
        public static Fun ToModel(this AddFunCommand command)
        {
            return new Fun(command.FunType, command.Price, TimeSpan.Parse(command.StartTime), TimeSpan.Parse(command.EndTime),
                command.SansDuration, command.SansTotalCapacity, command.SansGapTime,command.About)
            {
                //About=About.command
            };
        }

        /// <summary>
        /// تبدیل کردن کامند به سانس
        /// </summary>
        /* public static Schedule ToModel(this AddScheduleCommand command) 
         {
              return new Schedule(command.SystemFunCode, command.FunType, command.ExcuteDateTime, command.Price,
                  TimeSpan.Parse(command.StartTime), TimeSpan.Parse(command.EndTime))
              {
                  AvailableCapacity = command.AvailableCapacity
              };
         }*/

        /// <summary>
        /// تبدیل کردن کامند به بلیط
        /// </summary>
        /*public static Ticket ToModel(this AddTicketCommand command)
        {
            return new Ticket(command.FunType, command.ExecuteDate, command.StartTime, command.EndTime, command.NumberOfTicket)
            {
                #region Set

                FunId = command.FunId,
                ScheduleId = command.ScheduleId,
                TotalPrice = command.TotalPrice, 
                CellPhone = command.CellPhone,
                FullName = command.FullName

                #endregion
            };
        }*/

        /// <summary>
        /// تبدیل کردن کامند به کامنت
        /// </summary>
        public static Comment ToModel(this AddCommentCommand command)
        {
            return new Comment(command.Message, command.FunId, command.UserId, command.FunType, command.CellPhone,
                command.UserName);
            
        }


        public static File ToModel(this List<string> fileProps)
        {
            return new File(fileProps[0], fileProps[1])
            {
                Size = fileProps[3]
            };
        }

        public static Conversation ToModel(this AddConversationCommand command)
        {
            return new Conversation(command.Title);
        }

        public static Message ToModel(this AddMessageCommand command)
        {
            return new Message(command.Username,command.Message,command.ConversationID,command.UserID);
        }
    }
}

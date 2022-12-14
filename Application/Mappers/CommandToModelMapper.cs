using Application.Commands.Comment;
using Application.Commands.ContactInfo;
using Application.Commands.ContactUs;
using Application.Commands.Conversation;
using Application.Commands.Fun;
using Application.Commands.Message;
using Application.Commands.Schedule;
using Application.Commands.ScheduleInfo;
using Application.Commands.SliderPictureFun;
using Application.Commands.Ticket;
using Application.Commands.User;
using Domain.Models;
using System.Collections.Generic;

namespace Application.Mappers
{
    public static class CommandToModelMapper
    {
        public static CreditCard ToModel(this UpdateCreditCardCommand command)
        {
            return new CreditCard(command.ShabaNumber, command.CardNumber, command.UserId);
        }

        /// <summary>
        /// تبدیل کردن کامند به کاربر
        ///// </summary>
        //public static User ToModel(this GetPhoneAndSetVerifyCodeCommand command)
        //{
        //    return new User(command.PhoneNumber,command.FullName,command.UserName,command.Password,command.NationalCode);

        //}

        /// <summary>
        /// تبدیل کردن کامند به تفریح
        /// </summary>
        public static Fun ToModel(this AddFunCommand command)
        {
            return new Fun(
                command.Name, command.About, command.Icon,
                command.BackgroundPicture, command.Video,
                command.SliderPicture.ToModel(), command.ScheduleInfo.ToModel());
        }

        /// <summary>
        /// تبدیل کردن کامند به اطلاعات سانس
        /// </summary>
        public static ScheduleInfo ToModel(this AddScheduleInfoCommand command)
        {
            return new ScheduleInfo
                (command.StartTime, command.EndTime, command.GapTime, command.Duration, command.TotalCapacity,
                 command.PresenceCapacity, command.OnlineCapacity, command.Amount, command.FunId);
        }
        /// <summary>
        /// تبدیل کردن کامند به سلاید عکس تفریحات
        /// </summary>
        public static List<FunSliderPicture> ToModel(this List<AddSliderPictureFunCommand> commands)
        {
            var funSlider = new List<FunSliderPicture>();
            commands.ForEach(c => funSlider.Add(new FunSliderPicture(c.Attachment)));
            return funSlider;
        }



        /// <summary>
        /// تبدیل کردن کامند به سانس
        /// </summary>
        //public static Schedule ToModel(this AddScheduleCommand command) 
        //{
        //     return new Schedule(command.SystemFunCode, command.FunType, command.ExecuteDateTime, command.Price,
        //         TimeSpan.Parse(command.StartTime), TimeSpan.Parse(command.EndTime))
        //     {
        //         AvailableCapacity = command.AvailableCapacity
        //     };
        //}

        /// <summary>
        /// تبدیل کردن کامند به بلیط
        /// </summary>
        //public static Ticket ToModel(this AddTicketToBasketCommand command)
        //{
        //    return new Ticket(command.FunName, command.BoughtPlace, command.Gender, command.UserCommand.ToModel(),command.SchedulComand.ToModel());

        //}
        public static Schedule ToModel(this AddSchedulToTicketCommand schedulCommand)
        {
            return new Schedule(schedulCommand.Date, schedulCommand.StartTime, schedulCommand.EndTime, schedulCommand.Price, schedulCommand.FunId);
        }

        public static User ToModel(this AddUserToTicketcommand findUserCommand)
        {
            return new User(findUserCommand.PhoneNumber);
        }

        //    FunId = command.FunId,
        //    ScheduleId = command.ScheduleId,
        //    Price = command.Price, 
        //    PhoneNumber = command.PhoneNumber,
        //    FullName = command.FullName

        //    #endregion
        //};


        /// <summary>
        /// تبدیل کردن کامند به کامنت
        /// </summary>
        public static Comment ToModel(this AddCommentCommand command)
        {
            return new Comment(command.Message, command.FunId, command.UserId,
                command.FullName);

        }




        public static Conversation ToModel(this AddConversationCommand command)
        {
            return new Conversation(command.Title);
        }

        public static Message ToModel(this AddMessageCommand command)
        {
            return new Message(command.Username, command.Message, command.ConversationID);
        }

        /// <summary>
        /// تبدیل کردن پینشنهاد ویژه 
        /// </summary>
        public static Schedule ToModel(this AddSpecialOfferCommand command)
        {
            return new Schedule(command.Price, command.AddPercent.ToModel());

        }

        /// <summary>
        /// تبدیل کردن قدار تخفیف
        /// </summary>
        public static Percent ToModel(this AddPercentCommand command)
        {
            return new Percent(command.Value);
        }

        /// <summary>
        /// تبدیل کامند پشتیبانی به مدل
        /// </summary>
        public static ContactUs ToModel(this AddContactUsCommand command)
        {
            return new ContactUs(
                command.AboutMariana, command.Rules, command.Email,
                command.PhoneNumber, command.UrlLinkedin, command.UrlInstagram);
        }
    }
}

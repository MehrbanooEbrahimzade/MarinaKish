using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Application.Dtos;
using Domain.Models;
using MD.PersianDateTime.Core;

namespace Application.Mappers
{
    public static class ModelToDtoMapper
    {
        //vase Dto chon mikhaym be client neshon bedim bayad miladi ro to shamsi konim
        //vali vase command ke mikhaym to db zakhire konim bayad shamsi to miladi bashe chon db shamsi zakhire nimkone

        public static string PersianCalender(DateTime miladiDate)
        {
            //string.Format("{0}/{1}/{2}" good way but i wanna return date time not string
            PersianCalendar persianCalendar = new PersianCalendar();

            var PersianDate =
                persianCalendar.GetYear(miladiDate)
                + "/" + persianCalendar.GetMonth(miladiDate).ToString("00")
                + "/" + persianCalendar.GetDayOfMonth(miladiDate).ToString("00");



            return PersianDate;

        }


        public static UserDto ToDto(this User user)
        {
            PersianCalendar persianParse = new PersianCalendar();

            var persianBirthDate = string.Format("{0}/{1}/{2}",
            persianParse.GetYear(user.BirthDay), persianParse.GetMonth(user.BirthDay), persianParse.GetDayOfMonth(user.BirthDay));

            return new UserDto
            {
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                FullName = user.FullName,
                NationalCode = user.NationalCode,
                BirthDate = persianBirthDate,
                CreditCard = user.CreditCard.ToDto()

            };
        }
        public static CreditCardDto ToDto(this CreditCard creditCard)
        {
            return new CreditCardDto
            {
                Id = creditCard.Id,
                ShabaNumber = creditCard.ShabaNumber,
                CardNumber = creditCard.CardNumber
            };
        }

        /// <summary>
        /// تبدیل کردن تفریح به dto تفریح
        /// </summary>
        public static FunDto ToDto(this Fun fun)
        {
            return new FunDto()
            {
                #region Select

                Id = fun.Id,
                Name = fun.Name,
                ScheduleInfo = fun.ScheduleInfo.ToDto(),
                IsActive = fun.IsActive,

                #endregion
            };
        }

        /// <summary>
        /// تبدیل کردن لیست تفریح به dto لیست تفریح
        /// </summary>
        public static List<FunDto> ToDto(this List<Fun> funs)
        {
            return funs.Select(f => new FunDto
            {
                Id = f.Id,
                Name = f.Name,
                IsActive = f.IsActive,
                ScheduleInfo = f.ScheduleInfo.ToDto()
            }).ToList();
        }

        public static ScheduleInfoDto ToDto(this ScheduleInfo scheduleInfo)
        {
            return new ScheduleInfoDto()
            {
                Id = scheduleInfo.Id,
                StartTime = scheduleInfo.StartTime,
                EndTime = scheduleInfo.EndTime,
                GapTime = scheduleInfo.GapTime,
                Duration = scheduleInfo.Duration,
                TotalCapacity = scheduleInfo.TotalCapacity,
                PresenceCapacity = scheduleInfo.PresenceCapacity,
                Amount = scheduleInfo.Amount,
                OnlineCapacity = scheduleInfo.OnlineCapacity
            };
        }

       
        //public static TicketDto ToDto(this Ticket ticket)
        //{
        //    return new TicketDto
        //    {
        //        Id = ticket.Id,
        //        FullName = ticket.User.FullName,
        //        CellPhone = ticket.User.PhoneNumber,
        //        EFunType = ticket.FunType,
        //        ScheduleId = ticket.Schedule.Id,
        //        FunId = ticket.Schedule.FunId,
        //        TotalPrice = ticket.Schedule.Price,
        //        SubmitPersianDate = ticket.SubmitDate.ToString(),
        //        ExecutePersianDate = ticket.Schedule.Date.ToString(),
        //        UserId = ticket.User.Id,
        //        Condition = ticket.Condition,
        //        EndTime = ticket.Schedule.EndTime,
        //        StartTime = ticket.Schedule.StartTime

        /// <summary>
        /// تبدیل مدل اطلاعات پشتیبانی به dto
        /// </summary>
        public static ContactUsDto ToDto(this ContactUs contactUs)
        {
            return new ContactUsDto()
            {
                Email = contactUs.Email,
                AboutMariana = contactUs.AboutMariana,
                Id = contactUs.Id,
                PhoneNumber = contactUs.PhoneNumber,
                Rules = contactUs.Rules,
                UrlLinkedin = contactUs.UrlLinkedin,
                UrlInstagram = contactUs.UrlInstagram
            };
        }

        /// <summary>
        /// تبدیل سانس به dto سانس
        /// </summary>
        public static ScheduleDto ToDto(this Schedule schedule)
        {
            PersianCalendar PersianParse = new PersianCalendar();
            string PersianDate = string.Format("{0}/{1}/{2}",
                PersianParse.GetYear(schedule.Date), PersianParse.GetMonth(schedule.Date), PersianParse.GetDayOfMonth(schedule.Date));

            return new ScheduleDto()
            {
                #region Select

                Id = schedule.Id,
                FunId = schedule.FunId,
                Price = schedule.Price,
                Discount = schedule.Percent,
                Date = schedule.Date,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime

                #endregion
            };
        }

        /// <summary>
        /// تبدیل بلیط به dto بلیط
        /// </summary>
        public static TicketDto ToDto(this Ticket ticket)
        {

            return new TicketDto()
            {
                #region Select
                Id = ticket.Id,
                Condition = ticket.Condition,
                gender = ticket.Gender,
                FunType = ticket.FunType,
                BoughtPlace = ticket.WhereBuy,
                ScheduleDto = ticket.Schedule.ToDto(),
                UserDto = ticket.User.ToDto()
                #endregion
            };
        }

        /// <summary>
        /// تبدیل لیست بلیط به dto لیست بلیط
        /// </summary>
        public static List<TicketDto> ToDto(this List<Ticket> tickets)
        {
            var Tickets = new List<TicketDto>();
            tickets.ForEach(c => Tickets.Add(new TicketDto()
            {
                Id = c.Id,
                BoughtPlace = c.WhereBuy,
                Condition = c.Condition,
                FunType = c.FunType,
                gender = c.Gender,
                ScheduleDto = c.Schedule.ToDto(),
                UserDto = c.User.ToDto()

            }));
            return Tickets;

            //which one is correct 

            return tickets.Select(x => new TicketDto()
            {
                #region Select

                //        public static CommentDto ToDto(this Comment comment)
                //        {
                //            PersianCalendar persianParse = new PersianCalendar();
                //            string SubmitDate = string.Format("{0}/{1}/{2} {3}:{4}",
                //                 persianParse.GetYear(comment.SubmitDate), persianParse.GetMonth(comment.SubmitDate), persianParse.GetDayOfMonth(comment.SubmitDate),
                //                 persianParse.GetHour(comment.SubmitDate), persianParse.GetMinute(comment.SubmitDate));
                Id = x.Id,
                FunType = x.FunType,
                BoughtPlace = x.WhereBuy,
                Condition = x.Condition,
                gender = x.Gender,
                ScheduleDto = x.Schedule.ToDto(),
                UserDto = x.User.ToDto()

                #endregion
            }).ToList();
        }
       


        /// <summary>
        /// تبدیل کردن کاربر به dto کاربر
        /// </summary>
        //        public static UserDto ToDto(this User user)
        //        {
        //            PersianCalendar persianParse = new PersianCalendar();

        //            string persianJoinTime = string.Format("{0}/{1}/{2} {3}:{4}",
        //                persianParse.GetYear(user.DateJoin), persianParse.GetMonth(user.DateJoin), persianParse.GetDayOfMonth(user.DateJoin),
        //                persianParse.GetHour(user.DateJoin), persianParse.GetMinute(user.DateJoin));
        //            return new UserDto()
        //            {
        //                #region Select

        //                Id = user.Id,
        //                FullName = user.FullName,
        //                PhoneNumber = user.PhoneNumber,
        //                UserName = user.UserName,
        //                Gender = user.Gender,
        //                BirthDay = user.BirthDay,
        //                CardNumber = user.CreditCardCommand.CardNumber,
        //                ShabaNumber = user.CreditCardCommand.ShabaNumber,
        //                DateJoinInShamsi = persianJoinTime,

        //                #endregion
        //            };
        //        }

        //        /// <summary>
        //        /// تبدیل لیست کاربر به dto لیست کاربر
        //        /// </summary>
        //        public static List<UserDto> ToDto(this List<User> users)
        //        {
        //            return users.Select(x => new UserDto()
        //            {
        //                #region Select

        //                Id = x.Id,
        //                FullName = x.FullName,
        //                PhoneNumber = x.PhoneNumber,
        //                UserName = x.UserName,
        //                BirthDay = x.BirthDay,
        //                Gender = x.Gender,
        //                NationalCode = x.NationalCode,
        //                CardNumber = x.CreditCardCommand.CardNumber,
        //                ShabaNumber = x.CreditCardCommand.ShabaNumber,
        //                DateJoinInShamsi = x.ToDto().DateJoinInShamsi
        //                #endregion
        //            }).ToList();
        //        }







        //        /// <summary>
        //        /// تبدیل لیست سانس به dto لیست سانس
        //        /// </summary>
        //        public static List<ScheduleDto> ToDto(this List<Schedule> schedules)
        //        {
        //            //foreach (var schedule in schedules)
        //            //{
        //            //    PersianCalendar persianParse = new PersianCalendar();
        //            //    string persianDate = string.Format("{0}/{1}/{2} {3}:{4}",
        //            //        persianParse.GetYear(schedule.ExecuteDateTime), persianParse.GetMonth(schedule.ExecuteDateTime), persianParse.GetDayOfMonth(schedule.ExecuteDateTime),
        //            //        persianParse.GetHour(schedule.ExecuteDateTime), persianParse.GetMinute(schedule.ExecuteDateTime));
        //            //    schedule.ToDto().ExcutePersianDateTime = persianDate;
        //            //}

        //            return schedules.Select(x => new ScheduleDto()
        //            {
        //                #region Select

        //                Id = x.Id,
        //                ExcutePersianDateTime = x.ToDto().ExcutePersianDateTime,
        //                AvailableCapacity = x.AvailableCapacity,
        //                StartTime = x.StartTime,
        //                EndTime = x.EndTime,
        //                FunType = x.FunType,
        //                FunId = x.FunId


        //                #endregion
        //            }).ToList();
        //        }

        

        /// <summary>
        /// تبدیل لیست بلیط به dto لیست بلیط
        /// </summary>

        //        public static CommentDto ToDto(this Comment comment)
        //        {
        //            PersianCalendar persianParse = new PersianCalendar();
        //            string SubmitDate = string.Format("{0}/{1}/{2} {3}:{4}",
        //                 persianParse.GetYear(comment.SubmitDate), persianParse.GetMonth(comment.SubmitDate), persianParse.GetDayOfMonth(comment.SubmitDate),
        //                 persianParse.GetHour(comment.SubmitDate), persianParse.GetMinute(comment.SubmitDate));

        //            return new CommentDto
        //            {
        //                Id = comment.Id,
        //                Message = comment.Text,
        //                Status = comment.Status,
        //                Like = comment.Like,
        //                DisLike = comment.DisLike,
        //                SubmitDate = SubmitDate,
        //                FunId = comment.FunId,
        //                UserName = comment.UserName,
        //            };
        //        }

        //        /// <summary>
        //        /// تبدیل لیست کامنت به dto لیست کامنت
        //        /// </summary>
        //        public static List<CommentDto> ToDto(this List<Comment> comments)
        //        {
        //            return comments.Select(x => new CommentDto()
        //            {
        //                #region Select

        //                Id = x.Id,
        //                Message = x.Text,
        //                Status = x.Status,
        //                Like = x.Like,
        //                DisLike = x.DisLike,
        //                SubmitDate = x.ToDto().SubmitDate,
        //                FunId = x.FunId,
        //                UserName = x.UserName,

        //                #endregion
        //            }).ToList();
        //        }

        //        /// <summary>
        //        /// تبدیل فایل به dto فایل
        //        /// </summary>
        //        public static FilesDto ToDto(this MyFile file)
        //        {
        //            PersianCalendar persianParse = new PersianCalendar();
        //            string shamsiPlaceDate = string.Format("{0}/{1}/{2} {3}:{4}",
        //                persianParse.GetYear(file.PlaceDate), persianParse.GetMonth(file.PlaceDate), persianParse.GetDayOfMonth(file.PlaceDate),
        //                persianParse.GetHour(file.PlaceDate), persianParse.GetMinute(file.PlaceDate));

        //            return new FilesDto()
        //            {
        //                #region Select
        //                Id = file.Id,
        //                Name = file.Name,
        //                ShamsiPlaceDate = shamsiPlaceDate,
        //                isActive = file.IsActive
        //                #endregion
        //            };
        //        }

        //        /// <summary>
        //        /// تبدیل لیست فایل به dto لیست فایل
        //        /// </summary>
        //        public static List<FilesDto> ToDto(this List<MyFile> pics)
        //        {
        //            return pics.Select(x => new FilesDto
        //            {
        //                #region Select

        //                Id = x.Id,
        //                Name = x.Name,
        //                ShamsiPlaceDate = x.ToDto().ShamsiPlaceDate,
        //                isActive = x.IsActive

        //                #endregion
        //            }).ToList();
        //        }

        //        /// <summary>
        //        /// تبدیل تالار گفت و گو به dto تالار گفت و گو
        //        /// </summary>
        //        public static ConversationDto ToDto(this Conversation conversation)
        //        {
        //            PersianCalendar persianParse = new PersianCalendar();
        //            string shamsiCreatedTime = string.Format("{0}/{1}/{2} {3}:{4}",
        //                persianParse.GetYear(conversation.CreatedTime), persianParse.GetMonth(conversation.CreatedTime), persianParse.GetDayOfMonth(conversation.CreatedTime),
        //                persianParse.GetHour(conversation.CreatedTime), persianParse.GetMinute(conversation.CreatedTime));

        //            string shamsiLastActivity = string.Format("{0}/{1}/{2} {3}:{4}",
        //                persianParse.GetYear(conversation.LastActivity), persianParse.GetMonth(conversation.LastActivity), persianParse.GetDayOfMonth(conversation.LastActivity),
        //                persianParse.GetHour(conversation.LastActivity), persianParse.GetMinute(conversation.LastActivity));
        //            return new ConversationDto
        //            {
        //                #region Select

        //                Id = conversation.Id,
        //                Title = conversation.Title,
        //                Priority = conversation.Priority,
        //                ShamsiLastActivity = shamsiLastActivity,
        //                CreatedTime = shamsiCreatedTime

        //                #endregion
        //            };
        //        }

        //        /// <summary>
        //        /// تبدیل لیست تالار گفت و گو به dto لیست تالار گفت و گو
        //        /// </summary>
        //        public static List<ConversationDto> ToDto(this List<Conversation> conversations)
        //        {
        //            return conversations.Select(x => new ConversationDto
        //            {
        //                #region Select

        //                Id = x.Id,
        //                Title = x.Title,
        //                Priority = x.Priority,
        //                ShamsiLastActivity = x.ToDto().ShamsiLastActivity,
        //                CreatedTime = x.ToDto().CreatedTime

        //                #endregion
        //            }).ToList();
        //        }

        //        /// <summary>
        //        /// تبدیل پیام به dto پیام
        //        /// </summary>
        //        public static MessageDto ToDto(this Message message)
        //        {

        //            PersianCalendar persianParse = new PersianCalendar();
        //            string persianDate = string.Format("{0}/{1}/{2} {3}:{4}",
        //                persianParse.GetYear(message.SubmitDate), persianParse.GetMonth(message.SubmitDate), persianParse.GetDayOfMonth(message.SubmitDate),
        //                persianParse.GetHour(message.SubmitDate), persianParse.GetMinute(message.SubmitDate));

        //            return new MessageDto
        //            {
        //                #region Select

        //                Id = message.Id,
        //                UserName = message.UserName,
        //                ShamsiPlaceDate = persianDate,
        //                Text = message.Text,
        //                ConversationID = message.ConversationId,
        //                MessageStatus = message.MessageStatus

        //                #endregion
        //            };
        //        }

        //        /// <summary>
        //        /// تبدیل لیست پیام به dto لیست پیام
        //        /// </summary>
        //        public static List<MessageDto> ToDto(this List<Message> messages)
        //        {
        //            return messages.Select(x => new MessageDto
        //            {
        //                #region Select

        //                Id = x.Id,
        //                UserName = x.UserName,
        //                ShamsiPlaceDate = x.ToDto().ShamsiPlaceDate,
        //                Text = x.Text,
        //                ConversationID = x.ConversationId,
        //                MessageStatus = x.MessageStatus

        //                #endregion
        //            }).ToList();
        //        }

        //        public static CashTransferDto ToDto(this CashTransfer marineCoin)
        //        {
        //            PersianCalendar persianParse = new PersianCalendar();
        //            string persianDate = string.Format("{0}/{1}/{2} {3}:{4}",
        //                persianParse.GetYear(marineCoin.TransferDate), persianParse.GetMonth(marineCoin.TransferDate), persianParse.GetDayOfMonth(marineCoin.TransferDate),
        //                persianParse.GetHour(marineCoin.TransferDate), persianParse.GetMinute(marineCoin.TransferDate));

        //            return new CashTransferDto
        //            {
        //                Id = marineCoin.Id,
        //                MarineCoin = marineCoin.MarineCoin,
        //                PersianTransferDate = persianDate,
        //                TransferNumber = marineCoin.TransferNumber,
        //                UserId = marineCoin.UserId
        //            };
        //        }

        //        public static List<CashTransferDto> ToDto(this List<CashTransfer> marineCoins)
        //        {
        //            return marineCoins.Select(x => new CashTransferDto
        //            {
        //                Id = x.Id,
        //                MarineCoin = x.MarineCoin,
        //                PersianTransferDate = x.ToDto().PersianTransferDate,
        //                TransferNumber = x.TransferNumber,
        //                UserId = x.UserId
        //            }).ToList();
        //        }
    }
}
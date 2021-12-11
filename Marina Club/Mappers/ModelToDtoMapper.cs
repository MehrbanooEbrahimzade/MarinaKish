using Marina_Club.Dtos;
using Marina_Club.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Marina_Club.Mappers
{
    public static class ModelToDtoMapper
    {
        /// <summary>
        /// تبدیل کردن کاربر به dto کاربر
        /// </summary>
        public static UserDto ToDto(this User user)
        {
            PersianCalendar persianParse = new PersianCalendar();

            string persianJoinTime = string.Format("{0}/{1}/{2} {3}:{4}",
                persianParse.GetYear(user.DateJoin), persianParse.GetMonth(user.DateJoin), persianParse.GetDayOfMonth(user.DateJoin),
                persianParse.GetHour(user.DateJoin), persianParse.GetMinute(user.DateJoin));
            return new UserDto()
            {
                #region Select

                Id = user.Id,
                FullName = user.FullName,
                CellPhone = user.CellPhone,
                UserName = user.UserName,
                Provice = user.Provice,
                Gender = user.Gender,
                BirthDay = user.BirthDay,
                CardNumber = user.CardNumber,
                ShabaNumber = user.ShabaNumber,
                IsActive = user.IsActive,
                Wallet = user.Wallet,
                DateJoinInShamsi = persianJoinTime,
                ContactInfo = user.ContactInfo.ToDto()

                #endregion
            };
        }

        /// <summary>
        /// تبدیل لیست کاربر به dto لیست کاربر
        /// </summary>
        public static List<UserDto> ToDto(this List<User> users)
        {
            return users.Select(x => new UserDto()
            {
                #region Select

                Id = x.Id,
                FullName = x.FullName,
                CellPhone = x.CellPhone,
                UserName = x.UserName,
                Provice = x.Provice,
                BirthDay = x.BirthDay,
                Gender = x.Gender,
                IsActive = x.IsActive,
                Wallet = x.Wallet,
                NationalCode = x.NationalCode,
                CardNumber = x.CardNumber,
                ShabaNumber = x.ShabaNumber,
                DateJoinInShamsi = x.ToDto().DateJoinInShamsi
                #endregion
            }).ToList();
        }

        /// <summary>
        /// تبدیل کردن اطلاعات کاربر به dto اطلاعات کاربر
        /// </summary>
        public static ContactInfoDto ToDto(this ContactInfo contactInfo)
        {
            if (contactInfo != null)
            {
                return new ContactInfoDto()
                {
                    Email = contactInfo.Email,
                };
            }
            return null;
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
                FunType = fun.FunType,
                StartTime = fun.StartTime,
                EndTime = fun.EndTime,
                Price = fun.Price,
                SansDuration = fun.SansDuration,
                SansGapTime = fun.SansGapTime,
                SansTotalCapacity = fun.SansTotalCapacity,
                IsActive = fun.IsActive,
                About = fun.About,
                OnlineCapacity = fun.OnlineCapacity,
                SellerCapacity = fun.SellerCapacity,
                RealTimeCapacity = fun.RealTimeCapacity,
                BackgroundPicture = fun.BackgroundPicture,
                icon = fun.icon

                #endregion
            };
        }

        /// <summary>
        /// تبدیل کردن لیست تفریح به dto لیست تفریح
        /// </summary>
        public static List<FunDto> ToDto(this List<Fun> funs)
        {

            return funs.Select(x => new FunDto
            {
                #region Select

                Id = x.Id,
                FunType = x.FunType,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Price = x.Price,
                SansDuration = x.SansDuration,
                SansGapTime = x.SansGapTime,
                SansTotalCapacity = x.SansTotalCapacity,
                IsActive = x.IsActive,
                About = x.About,
                OnlineCapacity = x.OnlineCapacity,
                SellerCapacity = x.SellerCapacity,
                RealTimeCapacity = x.RealTimeCapacity,
                BackgroundPicture = x.BackgroundPicture,
                icon = x.icon

                #endregion
            }).ToList();
        }

        /// <summary>
        /// تبدیل سانس به dto سانس
        /// </summary>
        public static ScheduleDto ToDto(this Schedule schedule)
        {
            PersianCalendar persianParse = new PersianCalendar();
            string persianDate = string.Format("{0}/{1}/{2}",
                persianParse.GetYear(schedule.ExcuteMiladiDateTime), persianParse.GetMonth(schedule.ExcuteMiladiDateTime), persianParse.GetDayOfMonth(schedule.ExcuteMiladiDateTime));

            return new ScheduleDto()
            {
                #region Select

                Id = schedule.Id,
                ExcutePersianDateTime = persianDate,
                Price = schedule.Price,
                AvailableCapacity = schedule.AvailableCapacity,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                FunType = schedule.FunType,
                FunId = schedule.FunId

                #endregion
            };
        }

        /// <summary>
        /// تبدیل لیست سانس به dto لیست سانس
        /// </summary>
        public static List<ScheduleDto> ToDto(this List<Schedule> schedules)
        {
            //foreach (var schedule in schedules)
            //{
            //    PersianCalendar persianParse = new PersianCalendar();
            //    string persianDate = string.Format("{0}/{1}/{2} {3}:{4}",
            //        persianParse.GetYear(schedule.ExcuteMiladiDateTime), persianParse.GetMonth(schedule.ExcuteMiladiDateTime), persianParse.GetDayOfMonth(schedule.ExcuteMiladiDateTime),
            //        persianParse.GetHour(schedule.ExcuteMiladiDateTime), persianParse.GetMinute(schedule.ExcuteMiladiDateTime));
            //    schedule.ToDto().ExcutePersianDateTime = persianDate;
            //}

            return schedules.Select(x => new ScheduleDto()
            {
                #region Select

                Id = x.Id,
                ExcutePersianDateTime = x.ToDto().ExcutePersianDateTime,
                Price = x.Price,
                AvailableCapacity = x.AvailableCapacity,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                FunType = x.FunType,
                FunId = x.FunId


                #endregion
            }).ToList();
        }

        /// <summary>
        /// تبدیل بلیط به dto بلیط
        /// </summary>
        public static TicketDto ToDto(this Ticket ticket)
        {

            PersianCalendar persianParse = new PersianCalendar();
            string persianExcuteDate = string.Format("{0}/{1}/{2}",
                persianParse.GetYear(ticket.ScheduleMiladiTime), persianParse.GetMonth(ticket.ScheduleMiladiTime), persianParse.GetDayOfMonth(ticket.ScheduleMiladiTime));

            string persianSubmitDate = string.Format("{0}/{1}/{2} {3}:{4}",
                persianParse.GetYear(ticket.SubmitDate), persianParse.GetMonth(ticket.SubmitDate), persianParse.GetDayOfMonth(ticket.SubmitDate),
                persianParse.GetHour(ticket.SubmitDate), persianParse.GetMinute(ticket.SubmitDate));

            return new TicketDto()
            {
                #region Select

                Id = ticket.Id,
                FunType = ticket.FunType,
                TicketNumber = ticket.TicketNumber,
                ExecutePersianDate = persianExcuteDate,
                StartTime = ticket.StartTime,
                EndTime = ticket.EndTime,
                Condition = ticket.Condition,
                TotalPrice = ticket.TotalPrice,
                SubmitPersianDate = persianSubmitDate,
                CellPhone = ticket.CellPhone,
                FullName = ticket.FullName,
                FunId = ticket.FunId,
                ScheduleId = ticket.ScheduleId

                #endregion
            };
        }

        /// <summary>
        /// تبدیل لیست بلیط به dto لیست بلیط
        /// </summary>
        public static List<TicketDto> ToDto(this List<Ticket> tickets)
        {
            //foreach (var ticket in tickets)
            //{
            //    DateTime excuteParse = DateTime.Parse(ticket.ExecuteMiladiDate);
            //    PersianCalendar persianParse = new PersianCalendar();
            //    string persianDate = string.Format("{0}/{1}/{2} {3}:{4}",
            //        persianParse.GetYear(excuteParse), persianParse.GetMonth(excuteParse), persianParse.GetDayOfMonth(excuteParse),
            //        persianParse.GetHour(excuteParse), persianParse.GetMinute(excuteParse));
            //    ticket.ExecuteMiladiDate = persianDate;
            //}

            return tickets.Select(x => new TicketDto()
            {
                #region Select

                Id = x.Id,
                FunType = x.FunType,
                TicketNumber = x.TicketNumber,
                ExecutePersianDate = x.ToDto().ExecutePersianDate,
                StartTime = x.StartTime,
                EndTime = x.EndTime,
                Condition = x.Condition,
                TotalPrice = x.TotalPrice,
                SubmitPersianDate = x.ToDto().SubmitPersianDate,
                CellPhone = x.CellPhone,
                FullName = x.FullName,
                FunId = x.FunId,
                ScheduleId = x.ScheduleId


                #endregion
            }).ToList();
        }

        public static CommentDto ToDto(this Comment comment)
        {
            PersianCalendar persianParse = new PersianCalendar();
            string persianSubmitDate = string.Format("{0}/{1}/{2} {3}:{4}",
                 persianParse.GetYear(comment.SubmitDate), persianParse.GetMonth(comment.SubmitDate), persianParse.GetDayOfMonth(comment.SubmitDate),
                 persianParse.GetHour(comment.SubmitDate), persianParse.GetMinute(comment.SubmitDate));

            return new CommentDto
            {
                #region Select
                Id = comment.Id,
                Message = comment.Message,
                Status = comment.Status,
                Like = comment.Like,
                DisLike = comment.DisLike,
                persianSubmitDate = persianSubmitDate,
                FunType = comment.FunType,
                FunId = comment.FunId,
                UserName = comment.UserName,
                UserId = comment.UserId
                #endregion
            };
        }

        /// <summary>
        /// تبدیل لیست کامنت به dto لیست کامنت
        /// </summary>
        public static List<CommentDto> ToDto(this List<Comment> comments)
        {
            return comments.Select(x => new CommentDto()
            {
                #region Select

                Id = x.Id,
                Message = x.Message,
                Status = x.Status,
                Like = x.Like,
                DisLike = x.DisLike,
                persianSubmitDate = x.ToDto().persianSubmitDate,
                FunType = x.FunType,
                FunId = x.FunId,
                UserName = x.UserName,
                UserId = x.UserId

                #endregion
            }).ToList();
        }

        /// <summary>
        /// تبدیل فایل به dto فایل
        /// </summary>
        public static FilesDto ToDto(this Files file)
        {
            PersianCalendar persianParse = new PersianCalendar();
            string shamsiPlaceDate = string.Format("{0}/{1}/{2} {3}:{4}",
                persianParse.GetYear(file.PlaceDate), persianParse.GetMonth(file.PlaceDate), persianParse.GetDayOfMonth(file.PlaceDate),
                persianParse.GetHour(file.PlaceDate), persianParse.GetMinute(file.PlaceDate));

            return new FilesDto()
            {
                #region Select
                Id = file.Id,
                Name = file.Name,
                ShamsiPlaceDate = shamsiPlaceDate,
                isActive = file.isActive
                #endregion
            };
        }

        /// <summary>
        /// تبدیل لیست فایل به dto لیست فایل
        /// </summary>
        public static List<FilesDto> ToDto(this List<Files> pics)
        {
            return pics.Select(x => new FilesDto
            {
                #region Select

                Id = x.Id,
                Name = x.Name,
                ShamsiPlaceDate = x.ToDto().ShamsiPlaceDate,
                isActive = x.isActive

                #endregion
            }).ToList();
        }

        /// <summary>
        /// تبدیل تالار گفت و گو به dto تالار گفت و گو
        /// </summary>
        public static ConversationDto ToDto(this Conversation conversation)
        {
            PersianCalendar persianParse = new PersianCalendar();
            string shamsiCreatedTime = string.Format("{0}/{1}/{2} {3}:{4}",
                persianParse.GetYear(conversation.CreatedTime), persianParse.GetMonth(conversation.CreatedTime), persianParse.GetDayOfMonth(conversation.CreatedTime),
                persianParse.GetHour(conversation.CreatedTime), persianParse.GetMinute(conversation.CreatedTime));

            string shamsiLastActivity = string.Format("{0}/{1}/{2} {3}:{4}",
                persianParse.GetYear(conversation.LastActivity), persianParse.GetMonth(conversation.LastActivity), persianParse.GetDayOfMonth(conversation.LastActivity),
                persianParse.GetHour(conversation.LastActivity), persianParse.GetMinute(conversation.LastActivity));
            return new ConversationDto
            {
                #region Select

                Id = conversation.Id,
                Title = conversation.Title,
                Priority = conversation.Priority,
                ShamsiLastActivity = shamsiLastActivity,
                ShamsiCreatedTime = shamsiCreatedTime

                #endregion
            };
        }

        /// <summary>
        /// تبدیل لیست تالار گفت و گو به dto لیست تالار گفت و گو
        /// </summary>
        public static List<ConversationDto> ToDto(this List<Conversation> conversations)
        {
            return conversations.Select(x => new ConversationDto
            {
                #region Select

                Id = x.Id,
                Title = x.Title,
                Priority = x.Priority,
                ShamsiLastActivity = x.ToDto().ShamsiLastActivity,
                ShamsiCreatedTime = x.ToDto().ShamsiCreatedTime

                #endregion
            }).ToList();
        }

        /// <summary>
        /// تبدیل پیام به dto پیام
        /// </summary>
        public static MessageDto ToDto(this Message message)
        {

            PersianCalendar persianParse = new PersianCalendar();
            string persianDate = string.Format("{0}/{1}/{2} {3}:{4}",
                persianParse.GetYear(message.PlaceDate), persianParse.GetMonth(message.PlaceDate), persianParse.GetDayOfMonth(message.PlaceDate),
                persianParse.GetHour(message.PlaceDate), persianParse.GetMinute(message.PlaceDate));

            return new MessageDto
            {
                #region Select

                Id = message.Id,
                UserName = message.UserName,
                ShamsiPlaceDate = persianDate,
                message = message.message,
                ConversationID = message.ConversationID,
                MessageStatus = message.MessageStatus

                #endregion
            };
        }

        /// <summary>
        /// تبدیل لیست پیام به dto لیست پیام
        /// </summary>
        public static List<MessageDto> ToDto(this List<Message> messages)
        {
            return messages.Select(x => new MessageDto
            {
                #region Select

                Id = x.Id,
                UserName = x.UserName,
                ShamsiPlaceDate = x.ToDto().ShamsiPlaceDate,
                message = x.message,
                ConversationID = x.ConversationID,
                MessageStatus = x.MessageStatus

                #endregion
            }).ToList();
        }

        public static CashTransferDto ToDto(this CashTransfer marineCoin)
        {
            PersianCalendar persianParse = new PersianCalendar();
            string persianDate = string.Format("{0}/{1}/{2} {3}:{4}",
                persianParse.GetYear(marineCoin.TransferDate), persianParse.GetMonth(marineCoin.TransferDate), persianParse.GetDayOfMonth(marineCoin.TransferDate),
                persianParse.GetHour(marineCoin.TransferDate), persianParse.GetMinute(marineCoin.TransferDate));

            return new CashTransferDto
            {
                Id = marineCoin.Id,
                MarineCoin = marineCoin.MarineCoin,
                PersianTransferDate = persianDate,
                TransferNumber = marineCoin.TransferNumber,
                UserId = marineCoin.UserId
            };
        }

        public static List<CashTransferDto> ToDto(this List<CashTransfer> marineCoins)
        {
            return marineCoins.Select(x => new CashTransferDto
            {
                Id = x.Id,
                MarineCoin = x.MarineCoin,
                PersianTransferDate = x.ToDto().PersianTransferDate,
                TransferNumber = x.TransferNumber,
                UserId = x.UserId
            }).ToList();
        }
    }
}

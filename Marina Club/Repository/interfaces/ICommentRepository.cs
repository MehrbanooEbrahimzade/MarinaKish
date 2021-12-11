using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Marina_Club.Models;
using Marina_Club.Models.enums;

namespace Marina_Club.Repository.interfaces
{
    public interface ICommentRepository
    {
        /// <summary>
        /// دریافت کاربر با نام کاربری
        /// </summary>
        Task<User> GetUserByPhone(string phone);

        /// <summary>
        /// دریافت کاربر با آیدی
        /// </summary>
        Task<User> GetUserById(Guid id);

        /// <summary>
        /// دریافت کاربر فعال با آیدی
        /// </summary>
        Task<User> GetActiveUserById(Guid id);

        /// <summary>
        /// درسافت تفریح با اسم تفریح
        /// </summary>
        Task<Fun> GetFunByFunType(FunType fun);

        /// <summary>
        /// دریافت تفریح فعال با آیدی
        /// </summary>
        Task<Fun> GetActiveFunById(Guid id);

        /// <summary>
        /// دریافت تفریح با آیدی
        /// </summary>
        Task<Fun> GetFunById(Guid id);

        /// <summary>
        /// اضافه کردن کامنت به تیبل
        /// </summary>
        Task<bool> AddCommentAsync(Comment comment);

        /// <summary>
        /// دریافت کامنت با آیدی
        /// </summary>
        Task<Comment> GetCommentById(Guid id);

        /// <summary>
        /// دریافت کامنت قبول شده با آیدی
        /// </summary>
        Task<Comment> GetAcceptedCommentById(Guid id);

        /// <summary>
        /// دریافت کامنت درحال انتظار با آیدی
        /// </summary>
        Task<Comment> GetWaitingCommentById(Guid id);

        /// <summary>
        /// دریافت کامنت رد شده با آیدی
        /// </summary>
        Task<Comment> GetDeclinedCommentById(Guid id);

        /// <summary>
        /// دریافت کامنت غیر بلاک شده با آیدی
        /// </summary>
        Task<Comment> GetNotBlockedCommentById(Guid id);

        /// <summary>
        /// ذخیره کردن عملیات انجام شده
        /// </summary>
        Task<bool> SaveChangeCommentAsync();

        /// <summary>
        /// گرفتن همه کامنت های قبول شده برای یک تفریح
        /// </summary>
        Task<List<Comment>> GetAllAcceptedCommentsForFun(Guid id);

        /// <summary>
        /// دریافت کامنت های درحال انتظار یک تفریح با آیدی
        /// </summary>
        Task<List<Comment>> GetAllWaitingCommentsForFun(Guid id);

        /// <summary>
        /// دریافت کامنت های رد شده یک تفریح با آیدی
        /// </summary>
        Task<List<Comment>> GetAllDeclinedCommentsForFun(Guid id);

        /// <summary>
        /// دریافت کامنت های بلاک شده یک تفریح با آیدی
        /// </summary>
        Task<List<Comment>> GetAllBlockedCommentsForFun(Guid id);

        /// <summary>
        /// گرفتن همه کامنت های قبول شده یک کاربر
        /// </summary>
        Task<List<Comment>> GetAllAcceptedUserComments(Guid id);
    }
}

using Application.Dtos;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.IConfiguration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services.classes
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;


        public UserService(ILogger<UserService> logger, IUnitOfWork unitOfWork) : base()
        {
            _unitOfWork = unitOfWork;
            _logger = logger;

        }

        public async Task<UserDto> SearchUserById(Guid id)
        {
            var user = await _unitOfWork.Users.GetUserById(id);
            if (user == null)
                throw new ArgumentNullException();

            return user.ToDto();

        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await _unitOfWork.Users.DeleteAsync(id);
            if (!result)
                throw new Exception("عملیات ناموفق");
            return result;
        }


        /// <summary>
        /// دریافت تمام کاربران
        /// </summary>

        public async Task<List<UserDto>> GetAllUser()
        {
            var getall = await _unitOfWork.Users.GetAll();
            if (getall == null)
                throw new Exception("چنین کاربری یافت نشد");

            return getall.ToDto();

        }



        /// <summary>
        /// دریافت یک کاربر
        /// </summary>
        public async Task<UserDto> GetUser(Guid id)
        {

            var get = await _unitOfWork.Users.GetUserById(id);
            if (get == null)
                throw new Exception("چنین کاربری یافت نشد");

            return get.ToDto();
        }



        //        private readonly IUserRepository _userRepository;
        //        public UserService(IUserRepository userRepository)
        //        {
        //            _userRepository = userRepository;
        //        }

        //        /// <summary>
        //        /// وارد کردن شماره تلفن و ارسال کد تایید جدید : ثبت نام
        //        /// </summary>
        //        public async Task<List<string>> GetPhoneAndSetVerifyCode(GetPhoneAndSetVerifyCodeCommand command)
        //        {
        //            var isPhoneExist = await _userRepository.IsPhoneExist(command.PhoneNumber);
        //            List<string> ResultList = new List<string>();
        //            if (!isPhoneExist)
        //            {
        //                var newUser = command.ToModel();
        //                await _userRepository.UserSignUpAsync(newUser);

        //                ResultList.Add("Register");
        //                ResultList.Add(newUser.commentId.ToString());
        //                ResultList.Add(newUser.VerifyCode);

        //                return ResultList;
        //            }

        //            var user = await _userRepository.GetUserByPhone(command.PhoneNumber);
        //            var randomVerify = new Random().Next(1000, 9999).ToString();
        //            user.SetVerifycode(randomVerify);

        //            ResultList.Add("Login");
        //            ResultList.Add(user.commentId.ToString());
        //            ResultList.Add(user.VerifyCode);

        //            await _userRepository.SaveChanges();
        //            return ResultList;
        //        }

        //        /// <summary>
        //        /// وارد شدن کاربر :
        //        /// </summary>
        //        public async Task<UserDto> UserLoginAsync(UserLoginCommand command)
        //        {
        //            var user = await _userRepository.GetUserByPhone(command.PhoneNumber);
        //            if (user == null || user.VerifyCode != command.VerifyCode)
        //                return null;
        //            return user.ToDto();
        //        }
        //        #region NewVerionLogin
        //        //public async Task<Dtos.UserDto> UserLoginAsync(UserLoginCommand command)
        //        //{
        //        //    var user = await _userRepository.UserLoginAsync(command.UserName);

        //        //    if (user.UserName == command.UserName && user.Password == command.Password)
        //        //    {
        //        //        return user.ToDto();
        //        //    }
        //        //    else
        //        //    {
        //        //        throw new HttpResponseException(HttpStatusCode.BadRequest);
        //        //    }

        //        //}
        //        #endregion
        //        #region New VersionSignUp
        //        //public async Task<bool> UserSignUpAsync(UserSignUpCommand command)
        //        //{
        //        //    var isUsernameExist = await _userRepository.IsUserNameExist(command.UserName);

        //        //    if (!isUsernameExist)
        //        //        return await _userRepository.UserSignUpAsync(command.ToModel());
        //        //    else
        //        //        throw new HttpResponseException(HttpStatusCode.BadRequest);
        //        //}
        //        #endregion

        //        /// <summary>
        //        /// وارد شدن اعضای جدید
        //        /// </summary>
        //        public async Task<UserDto> NewMemberLogin(NewMemberLoginCommand command)
        //        {
        //            var user = await _userRepository.GetUserByPhone(command.PhoneNumber);
        //            if (user == null)
        //                return null;

        //            if (user.UserName != command.UserName)
        //            {
        //                var isUsernameExist = await _userRepository.IsUserNameExist(command.UserName);
        //                if (isUsernameExist)
        //                    return null;
        //                user.SetUserName(command.UserName);
        //            }

        //            user.SetFullName(command.FirstName + " " + command.LastName );
        //            user.SetPassword(command.Password );
        //            await _userRepository.SaveChanges();
        //            return user.ToDto();
        //        }



        //        /// <summary>
        //        /// عملیات عوض کردن رمز کاربر :
        //        /// </summary>
        //        public async Task<bool> ForgetPasswordAction(ForgetPasswordCommand command)
        //        {
        //            var user = await _userRepository.GetUserByPhone(command.PhoneNumber);

        //            if (command.NewPassword != command.RepeatNewPassword || user.VerifyCode != command.VerifyCode)
        //            {
        //                return false;
        //            }
        //            user.SetPassword(command.NewPassword );
        //            return await _userRepository.SaveChanges();
        //        }

        //        /// <summary>
        //        /// عملیات ویرایش پروفایل :
        //        /// </summary>
        //        public async Task<UserDto> UpdateProfileAsync(UpdateUserCommand command)
        //        {
        //            var user = await _userRepository.GetUserById(command.commentId);
        //            if (user == null)
        //                return null;

        //            #region Validation and Update

        //            user.SetFullName(command.FirstName + " " + command.LastName );

        //            if (user.UserName != command.Username)
        //            {
        //                var isUsernameExist = await _userRepository.IsUserNameExist(command.Username);
        //                if (isUsernameExist)
        //                    return null;

        //                user.SetUserName(command.Username);
        //            }


        //            user.SetGender(command.Gender);
        //            user.SetBirthdate(command.BirthDay);

        //            #endregion

        //            await _userRepository.SaveChanges();
        //            return user.ToDto();
        //        }

        //        /// <summary>
        //        /// عملیات جستجو کردن کاربر :
        //        /// </summary> 
        //        public async Task<List<UserDto>> SearchUser(FindUserCommand command)
        //        {
        //            var users = await _userRepository.SearchUserByNameOrUsername(command.UserNameOrFullName);
        //            if (users == null)
        //                return null;
        //            return users.ToDto();
        //        }

        //        #region Promote and Demote and Block actions

        //        /// <summary>
        //        /// ارتقا دادن کاربر به ادمین :
        //        /// </summary>
        //        public async Task<UserDto> PromoteToAdmin(Guid id)
        //        {
        //            var user = await _userRepository.GetUserById(id);
        //            if (user == null || user.RoleType==RoleType.Admin)
        //                return null;
        //            user.RoleType = RoleType.Admin;
        //            await _userRepository.SaveChanges();
        //            return user.ToDto();
        //        }

        //        /// <summary>
        //        /// ارتقا دادن کاربر به فروشنده :
        //        /// </summary>
        //        public async Task<UserDto> PromoteToSeller(Guid id)
        //        {
        //            var user = await _userRepository.GetUserById(id);

        //            if (user == null|| user.RoleType == RoleType.Seller)
        //                return null;

        //            user.RoleType = RoleType.Seller;

        //            await _userRepository.SaveChanges();

        //            return user.ToDto();
        //        }

        //        /// <summary>
        //        /// تنزل رتبه کاربر فروشنده/ادمین به خریدار
        //        /// </summary>
        //        public async Task<UserDto> DemoteToUser(Guid id)
        //        {//GetAdminOrSellerUserById
        //            var user = await _userRepository.GetUserById(id);
        //            if (user == null || user.RoleType== RoleType.Buyer)
        //                return null;
        //            user.RoleType = RoleType.Buyer;
        //            await _userRepository.SaveChanges();
        //            return user.ToDto();
        //        }

        //        #endregion


        //        public async Task<int> UserPlayingFunCount(Guid id)
        //        {
        //            var userTickets = await _userRepository.AllBuyedOrCanceledUserTickets(id);
        //            return userTickets.Count;
        //        }

    }
}

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Application.Commands.User;
using Application.Dtos;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.Models.enums;
using Infrastructure.Repository.interfaces;

namespace Application.Services.classes
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// وارد کردن شماره تلفن و ارسال کد تایید جدید : (ثبت نام)
        /// </summary>
        public async Task<List<string>> GetPhoneAndSetVerifyCode(GetPhoneAndSetVerifyCodeCommand command)
        {
            var isPhoneExist = await _userRepository.isPhoneExist(command.CellPhone);
            List<string> ResultList = new List<string>();
            if (!isPhoneExist)
            {
                var newUser = command.ToModel();
                await _userRepository.UserSignUpAsync(newUser);

                ResultList.Add("Register");
                ResultList.Add(newUser.Id.ToString());
                ResultList.Add(newUser.VerifyCode);

                return ResultList;
            }

            var user = await _userRepository.GetUserByPhone(command.CellPhone);
            var randomVerify = new Random().Next(1000, 9999).ToString();
            user.VerifyCode = randomVerify;

            ResultList.Add("Login");
            ResultList.Add(user.Id.ToString());
            ResultList.Add(user.VerifyCode);

            await _userRepository.UpdateUserAsync();
            return ResultList;
        }

        /// <summary>
        /// وارد شدن کاربر :
        /// </summary>
        public async Task<UserDto> UserLoginAsync(UserLoginCommand command)
        {
            var user = await _userRepository.GetUserByPhone(command.CellPhone);
            if (user == null || user.VerifyCode != command.VerifyCode)
                return null;
            return user.ToDto();
        }
        #region NewVerionLogin
        //public async Task<Dtos.UserDto> UserLoginAsync(UserLoginCommand command)
        //{
        //    var user = await _userRepository.UserLoginAsync(command.UserName);

        //    if (user.UserName == command.UserName && user.Password == command.Password)
        //    {
        //        return user.ToDto();
        //    }
        //    else
        //    {
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);
        //    }

        //}
        #endregion
        #region New VersionSignUp
        //public async Task<bool> UserSignUpAsync(UserSignUpCommand command)
        //{
        //    var isUsernameExist = await _userRepository.IsUserNameExist(command.UserName);

        //    if (!isUsernameExist)
        //        return await _userRepository.UserSignUpAsync(command.ToModel());
        //    else
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);
        //}
        #endregion

        /// <summary>
        /// وارد شدن اعضای جدید
        /// </summary>
        public async Task<UserDto> NewMemberLogin(NewMemberLoginCommand command)
        {
            var user = await _userRepository.GetUserByPhone(command.CellPhone);
            if (user == null)
                return null;

            if (user.UserName != command.UserName)
            {
                var isUsernameExist = await _userRepository.IsUserNameExist(command.UserName);
                if (isUsernameExist)
                    return null;
                user.UserName = command.UserName;
            }

            user.FullName = command.FirstName + " " + command.LastName;
            user.Password = command.Password;
            await _userRepository.UpdateUserAsync();
            return user.ToDto();
        }



        /// <summary>
        /// عملیات عوض کردن رمز کاربر :
        /// </summary>
        public async Task<bool> ForgetPasswordAction(ForgetPasswordCommand command)
        {
            var user = await _userRepository.GetUserByPhone(command.CellPhone);

            if (command.NewPassword != command.RepeatNewPassword || user.VerifyCode != command.VerifyCode)
            {
                return false;
            }
            user.Password = command.NewPassword;
            return await _userRepository.UpdateUserAsync();
        }

        /// <summary>
        /// عملیات ویرایش پروفایل :
        /// </summary>
        public async Task<UserDto> UpdateProfileAsync(UpdateUserCommand command)
        {
            var user = await _userRepository.GetUserById(command.ID);
            if (user == null)
                return null;

            #region Validation and Update

            user.FullName = command.FirstName + " " + command.LastName;

            if (user.UserName != command.Username)
            {
                var isUsernameExist = await _userRepository.IsUserNameExist(command.Username);
                if (isUsernameExist)
                    return null;

                user.UserName = command.Username;
            }

            user.Gender = command.Gender;
            user.BirthDay = command.BirthDay;

            #endregion

            await _userRepository.UpdateUserAsync();
            return user.ToDto();
        }

        /// <summary>
        /// عملیات جستجو کردن کاربر :
        /// </summary> 
        public async Task<List<UserDto>> SearchUser(FindUserCommand command)
        {
            var users = await _userRepository.SearchUserByNameOrUsername(command.UserNameOrFullName);
            if (users == null)
                return null;
            return users.ToDto();
        }

        #region Promote and Demote and Block actions

        /// <summary>
        /// ارتقا دادن کاربر به ادمین :
        /// </summary>
        public async Task<UserDto> PromoteToAdmin(Guid id)
        {
            var user = await _userRepository.GetNotAdminUserById(id);
            if (user == null)
                return null;
            user.RoleType = RoleType.Admin;
            await _userRepository.UpdateUserAsync();
            return user.ToDto();
        }

        /// <summary>
        /// ارتقا دادن کاربر به فروشنده :
        /// </summary>
        public async Task<UserDto> PromoteToSeller(Guid id)
        {
            var user = await _userRepository.GetNotSellerUserById(id);
            if (user == null)
                return null;
            user.RoleType = RoleType.Seller;
            await _userRepository.UpdateUserAsync();
            return user.ToDto();
        }

        /// <summary>
        /// تنزل رتبه کاربر فروشنده/ادمین به خریدار
        /// </summary>
        public async Task<UserDto> DemoteToUser(Guid id)
        {
            var user = await _userRepository.GetAdminOrSellerUserById(id);
            if (user == null)
                return null;
            user.RoleType = RoleType.Buyer;
            await _userRepository.UpdateUserAsync();
            return user.ToDto();
        }

        #endregion

        /// <summary>
        /// اضافه کردن پول به کیف پول کاربر
        /// </summary>
        //public async Task<string> IncreaseUserWallet(Guid userid, IncreaseUserWalletCommand command)
        //{
        //    var user = await _userRepository.GetActiveUserById(userid);
        //    if (user == null)
        //        return null;
        //    user.Wallet += command.Cash;
        //    await _userRepository.UpdateUserAsync();
        //    return user.Wallet.ToString();
        //}

        /// <summary>
        /// بلاک کردن کاربر :
        /// </summary>
        public async Task<bool> BlockUserAsync(Guid id)
        {
            var user = await _userRepository.GetActiveUserById(id);
            if (user == null)
                return false;
            user.IsActive = false;
            return await _userRepository.UpdateUserAsync();
        }

        /// <summary>
        /// فعال کردن کاربر :
        /// </summary>
        public async Task<bool> UnBlockUserAsync(Guid id)
        {
            var user = await _userRepository.GetBlockedUser(id);
            if (user == null)
                return false;
            user.IsActive = true;
            return await _userRepository.UpdateUserAsync();
        }

        /// <summary>
        /// همه کاربر های فعال
        /// </summary>
        public async Task<List<UserDto>> AllActiveUsers()
        {
            var activeUsers = await _userRepository.AllActiveUsers();
            if (activeUsers.Count == 0)
                return null;
            return activeUsers.ToDto();
        }

        /// <summary>
        /// تعداد همه کاربر های فعال
        /// </summary>
        public async Task<int> AllActiveUsersCount()
        {
            var activeUsersCount = await _userRepository.AllActiveUsersCount();
            return activeUsersCount;
        }

        /// <summary>
        ///  همه کاربر های بلاک شده
        /// </summary>
        public async Task<List<UserDto>> AllBlockedUsers()
        {
            var blockedUsers = await _userRepository.AllBlockedUsers();
            if (blockedUsers.Count == 0)
                return null;
            return blockedUsers.ToDto();
        }

        /// <summary>
        /// تعداد همه کاربر های بلاک شده
        /// </summary>
        public async Task<int> AllBlockedUsersCount()
        {
            var blockedUsersCount = await _userRepository.AllBlockedUsersCount();
            return blockedUsersCount;
        }

        /// <summary>
        /// ریست کردن کد تایید همه کاربران فعال
        /// </summary>
        public async Task<bool> RestartAllActiveUsersVerifyCode()
        {
            var activeUsers = await _userRepository.AllActiveUsers();
            if (activeUsers.Count == 0)
                return false;
            foreach (var user in activeUsers)
            {
                var rand1 = new Random().Next(100, 999).ToString();
                var rand2 = new Random().Next(100, 999).ToString();
                user.VerifyCode = rand1 + "-" + rand2;
            }
            return await _userRepository.UpdateUserAsync();
        }

        /// <summary>
        /// آنبلاک کردن همه کاربر های بلاک شده
        /// </summary>
        public async Task<bool> UnBlockAllBlockedUsers()
        {
            var blockedUsers = await _userRepository.AllBlockedUsers();
            if (blockedUsers.Count == 0)
                return false;
            foreach (var user in blockedUsers)
            {
                user.IsActive = true;
            }
            return await _userRepository.UpdateUserAsync();
        }

        /// <summary>
        /// دریافت تعداد تفریح کردن کاربر
        /// </summary>
        public async Task<int> UserPlayingFunCount(Guid id)
        {
            var userTickets = await _userRepository.AllBuyedOrCanceledUserTickets(id);
            return userTickets.Count;
        }
    }
}

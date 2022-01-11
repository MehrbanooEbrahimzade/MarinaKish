using System;
using Infrastructure.Helper;
using Marina_Club.Activator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Marina_Club.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ApiController : ControllerBase
    {
        protected ApiController() { }

        protected UserInfo CurrentUser => (User.Identity as ClaimsIdentity).GetUserClaim();

        /// <summary>
        /// نتیجه ی عملیات موفق
        /// </summary>
        [NonAction]
        public IActionResult OkResult(string message)
        {
            return Ok(new ResponseMessage(message, null));
        }


        /// <summary>
        /// نتیجه ی عملیات موفق همراه با محتوا 
        /// </summary>
        [NonAction]
        public IActionResult OkResult(string message, object content)
        {
            return Ok(new ResponseMessage(message, content));
        }

        /// <summary>
        /// کد 400 همراه با پیام مورد نظر
        /// </summary>
        [NonAction]
        public IActionResult BadReq(string message)
        {
            return BadRequest(new ResponseMessage(message, null));
        }

        /// <summary>
        /// کد 400 همراه با پیام و محتوا 
        /// </summary>
        [NonAction]
        public IActionResult BadReq(string message, object content)
        {
            return BadRequest(new ResponseMessage(message, content));
        }

        public class ResponseMessage
        {
            public string Message { get; set; }

            public object Content { get; set; }

            public ResponseMessage(string message, object content)
            {
                Message = message;
                Content = content;
            }

        }

        public static class ApiMessage
        {
            public const string Ok = "عملیات با موفقیت انجام شد ";
            public const string BadRequest = "عملیات با خطا مواجه شد";
            public const string ServiceUnAvailable = "سرویس سرور دردسترس نمیباشد";
            public const string AnyTicketForChangingNotFound = " بلیطی برای ثبت تغییرات یافت نشد";
            public const string PerformedTicketChangedToPlayed = " بلیط های انجام شده به بازی شده تغییر وضعیت یافتند";
            public const string WrongID = "آیدی وارد شده اشتباه است";
            public const string WrongUserID = "آیدی کاربر وارد شده اشتباه است";
            public const string WrongScheduleID = "آیدی سانس وارد شده اشتباه است";
            public const string WrongFunID = "آیدی تفریح وارد شده اشتباه است";
            public const string WrongFunIDOrFileID = "آیدی تفریح یا آیدی فایل وارد شده اشتباه است";
            public const string WrongUserIDOrFileID = "آیدی کاربر یا آیدی فایل وارد شده اشتباه است";
            public const string WrongScheduleIDOrFileID = "آیدی تفریح یا آیدی فایل وارد شده اشتباه است";
            public const string WrongFunType = "اسم تفریح وارد شده اشتباه است";
            public const string WrongTicketID = "آیدی بلیط وارد شده اشتباه است";
            public const string WrongMessageID = "آیدی پیام وارد شده اشتباه است";
            public const string WrongFileID = "آیدی فایل/عکس وارد شده اشتباه است";
            public const string WrongDate = "تاریخ وارد شده تاریخ اشتباهی است";
            public const string WrongInformation = "اطلاعات نامعتبراست";
            public const string WrongFunInformation = "مشخصات تفریح را کامل وارد کنید";

            #region Users
            public const string WrongCellPhone = "شماره تلفن اشتباه وارد شده است";
            public const string WrongCellPhoneorcode = "شماره تلفن یا کد اشتباه وارد شده است";

            public const string verifyCodeSent = "کد تایید ارسال شد";
            public const string userLoggedInAndVerifyCodeSent = "ورود کاربر . کد تایید ارسال شد";
            public const string userRegisterAndVerifyCodeSent = "ورود کاربر جدید . کد تایید ارسال شد";
            public const string WrongVerifyCode = "کد تایید کاربر اشتباه وارد شده است";
            public const string WrongVerifyCodeOrCellphone = "کد تایید یا شماره کاربر اشتباه وارد شده است";
            public const string UserLoggedIn = "کاربر وارد سایت شد";
            public const string UsernameIsExist = "این نام کاربری وجود دارد";
            public const string UsernameIsExistOrNotNewUser = "این نام کاربری وجود دارد یا کاربر مورد نظر کاربر جدید نیست";
            public const string NewUserLoggedIn = "مشخصات کاربر جدید اضافه شد";
            public const string ProfileUpdated = "پروفایل آپدیت شد";
            public const string ProfileNotUpdated = "پروفایل آپدیت نشد";
            public const string UserPasswordChangeFail = "رمز عبور کاربر عوض نشد";
            public const string UserPasswordChanged = "رمز عبور کاربر تغییر کرد";
            public const string UserBlocked = "کاربر بلاک شد";
            public const string UserNotBlocked = "کاربر بلاک نشد";
            public const string UserUnBlocked = "کاربر دوباره فعال شد";
            public const string UserNotUnBlocked = "کاربر دوباره فعال نشد";
            public const string DemoteUser = "ادمین/فروشنده به کاربر تبدیل شد";
            public const string NotDemoteUser = "عملیات تبدیل کردن ادمین/فروشنده به کاربر شکست خورد";
            public const string PromoteSeller = "کاربر به فروشنده تبدیل شد";
            public const string NotPromoteSeller = "عملیات تبدیل کردن کاربر به فروشنده شکست خورد";
            public const string PromoteAdmin = "کاربر به ادمین تبدیل شد";
            public const string NotPromoteAdmin = "عملیات تبدیل کردن کاربر به ادمین شکست خورد";
            public const string EnterUsername = "لطفا نام کاربری مورد نظر خودرا وارد کنید";
            public const string UserFound = "کاربر پیدا شد";
            public const string UsersActiveFound = "کاربر های فعال یافت شدند";
            public const string UsersBlockedFound = "کاربر های بلاک شده یافت شدند";
            public const string WalletNotIncreased = "پول به کیف پول کاربر اضافه نشد";
            public const string UserNotFound = "کاربری پیدا نشد";
            public const string AllActiveUsersVerifyCodeRestarted = "کد تایید همه کاربران فعال عوض شد ";
            public const string AllActiveUsersVerifyCodeNotRestarted = "عملیات  عوض کردن کد تایید همه کاربران فعال با خطا مواجه شد ";
            public const string AnyActiveUserNotFount = "کاربر فعالی پیدا نشد";
            public const string AnyBlockedUserNotFound = "کاربر بلاک شده ای پیدا نشد";
            public const string AllBlockedUsersUnBlocked = "همه کاربر های بلاک شده دوباره آنبلاک(فعال) شدند";
            public const string UserNotHavePlayAnyFunYet = "کاربر مورد نظر هنو تفریحی را انجام نداده است";
            public const string AllUserPlayingFunCount = "تعداد تفریح کردن کاربر مورد نظر دریافت شد";

            #endregion

            #region Sellers
            public const string AllSellersAvailable = "همه فروشندگان در دسترس هستند";
            public const string AllSellerTicketsAvailable = "همه بلیط های فروشنده در دسترس است";
            public const string AllSellersTicketsAvailable = "همه بلیط های فروشندگان در دسترس است";
            public const string MarineNoHaveSeller = "درحال حاضر فروشنده ای برای مارینا ثبت نشده است";
            public const string WrongSellerId = "آیدی مورد نظر برای فروشنده نیست . ایدی را دوباره بررسی کنید";
            public const string SellerNotHaveAnyTickets = "هیچ بلیطی برای فروشنده مورد نظر جود ندارد";
            public const string TransferNotYet = "هنوز هیچ انتقالاتی انجام نشده است";
            public const string SellerTicketsBuyedAndGetted = "بلیط های فروشنده خریده شد و دریافت شد";
            public const string SellerProfileUpdated = " اطلاعات فروشنده اضافه شد - پروفایل فروشنده اپدیت شد";
            public const string SellerProfileUpdateFail = "عملیات اپدیت کردن پروفایل فروشنده با خطا مواجه شد";
            #endregion

            #region Funs
            public const string FunAdded = "تفریح اضافه شد";
            public const string FunNotAdded = "تفریح اضافه نشد";
            public const string FunEdited = "تفریح ویرایش شد";
            public const string NotFunEdited = "تفریح ویرایش نشد";
            public const string FunDeleted = "تفریح پاک شد";
            public const string FunGetted = "مشخصات تفریح دریافت شد";
            public const string FunsByFunTypeGetted = " تفریحات با اسم تفریح دریافت شدند";
            public const string AllFunGetted = "همه تفریح ها دریافت شدند";
            public const string AllActiveFunGetted = "همه تفریح ها دریافت شدند";
            public const string AllDisActiveFunGetted = "همه تفریح ها دریافت شدند";
            public const string BackgroundPictureAdded = "عکس پس زمینه اضافه شد";
            public const string NotBackgroundPictureAdded = "عکس پس زمینه اضافه نشد";
            public const string iconAdded = "آیکون اضافه شد";
            public const string NoticonAdded = "عکس پس زمینه اضافه نشد";
            public const string FunDisActived = "تفریح غیرفعال شد";
            public const string FunNotDisActive = "تفریح غیرفعال نشد";
            public const string FunReActived = "تفریح دوباره فعال شد";
            public const string FunNotReActive = "تفریح دوباره فعال نشد";
            public const string FunAllreadyReActive = "تفریح قبلا قعال شده است";
            public const string ExistFun = "تفریح مورد نظر وجود دارد";
            public const string NotExistFunId = "تفریح مورد نظر با این آیدی وجود ندارد";
            public const string NotExistFunType = "تفریحی با این اسم تفریح وجود ندارد";
            public const string BadFunReq = "تفریح موردنظر پیدا نشد";
            public const string MarineNotHaveActiveFunYet = "مارینا هنوز هیچ تفریح فعالی ندارد";
            public const string MarineNotHaveDisActiveFun = "مارینا تفریح غیرفعالی ندارد";
            #endregion

            #region ScheduleMaker
            public const string SchedulesCreated = "سانس ها اضافه شدند";
            public const string SchedulesNotExist = "سانس در دسترس نیست";
            public const string CancelOrReExistScheduleOk = "سانس لغو شد/برگشت";
            public const string ReExistSchedule = "سانس فعال است";
            public const string ReExistSchedules = "سانس ها فعال شدند";
            public const string CancelSchedule = "سانس لغو شد";
            public const string CancelSchedules = "سانس ها لغو شدند";
            public const string ScheduleListCORE = "سانس ها لغو شدند/برگشتند";
            public const string GetAllScheduleForFun = "همه سانس های تفریح دریافت شد";
            public const string GetAllScheduleForFunAtThisTime = "همه سانس های تفریح با تاریخ داده شده دریافت شد";
            public const string NoScheduleAtThisTime = "سانسی در تاریخ مورد نظر در دسترس نیست";
            public const string ScheduleFound = "سانس پیدا شد";
            public const string ListIncreasePricePercent = "درصد افزایشی قیمت روی سانس های مورد نظر اعمال شد";
            public const string FunIncreasePricePercent = "درصد افزایشی قیمت روی سانس های تفریح مورد نظر اعمال شد";
            public const string ListIncreasePrice = "قیمت افزایشی روی سانس های مورد نظر اعمال شد";
            public const string FunIncreasePrice = "قیمت افزایشی روی سانس های تفریح مورد نظر اعمال شد";
            public const string ListDiscountPricePercent = "درصد تخفیف روی سانس های مورد نظر اعمال شد";
            public const string FunDiscountPricePercent = "درصد تخفیف روی سانس های تفریح مورد نظر اعمال شد";
            public const string ListDiscountPrice = "قیمت تخفیف روی سانس های مورد نظر اعمال شد";
            public const string FunDiscountPrice = "قیمت تخفیف روی سانس های تفریح مورد نظر اعمال شد";
            public const string BadReqScheduleCORE = "آی دی اشتباه وارد شده است یا وجود داشتن سانس وارد نشده است";
            public const string AnyScheduleForDiscountNotFound = "سانسی برای کاهش قیمت پیدا نشد";
            public const string AnyScheduleForIncreaseNotFound = "سانسی برای افزایش قیمت پیدا نشد";
            public const string InvalidFunId = "تفریح مورد نظر پیدا نشد . ایدی تفریح اشتباه است";
            public const string ExpiredActiveSchedulesDisActived = "سانس های تاریخ گذشته فعال ، غیر فعال شدند";
            public const string NotHaveAnyExpiredActiveScheduleYet = "هنوز هیچ سانس فعال و تاریخ گذشته ای وجود ندارد";
            public const string ScheduleCapacityIncreased = "فضای سانس مورد نظر بیشتر شد";
            public const string ScheduleCapacityReduced = "فضای سانس مورد نظر کمتر شد";

            #endregion

            #region MyFile
            public const string nullFile = "فایل یافت نشد!";
            public const string OkPicAdd = "عکس مورد نظر با موفقیت اضافه شد";
            public const string OkFileAdd = "فایل مورد نظر با موفقیت اضافه شد";
            public const string PicNotAdd = "اضافه کردن عکس مورد نظر با شکست مواجه شد";
            public const string OkPicExist = "عکس وجود دارد";
            public const string PicNotExist = "عکس وجود ندارد";
            public const string FileDisActived = "فایل مورد نظر با موفقیت غیرفعال شد ";
            public const string FileReActived = "فایل مورد نظر با موفقیت دوباره فعال شد ";
            public const string FileDeleted = "فایل مورد نظر با موفقیت پاک شد ";
            public const string BadReqPicNotExist = "عکس وجود ندارد";
            public const string FunProfileAdded = "عکس پروفایل تفریح اضافه شد";
            public const string FunProfileNotAdded = "پروفایل تفریح اضافه نشد";
            public const string GetAllFunProfiles = "همه عکس های تفریح مورد نظر دردسترس است";
            public const string FunNotHavePic = "عکسی برای تفریح مورد نظر وجود ندارد";
            public const string UserProfileAdded = "عکس پروفایل کاربر اضافه شد";
            public const string UserProfileNotAdded = "پروفایل کاربر اضافه نشد";
            public const string GetAllUserProfiles = "همه عکس های کاربر مورد نظر در دسترس است";
            public const string UserNotHavePic = "برای کاربر مورد نظر عکسی وجود ندارد";
            public const string ScheduleProfileAdded = "عکس پروفایل سانس اضافه شد";
            public const string ScheduleProfileNotAdded = "پروفایل سانس اضافه نشد";
            public const string GetAllScheduleProfiles = "عکس سانس دردسترس است";
            public const string ScheduleNotHavePic = "برای سانس مورد نظر عکسی وجود ندارد";
            #endregion

            #region MarineCoinTransfers
            public const string WalletIncreased = "پول به کیف پول کاربر اضافه شد";
            public const string WalletDecreased = "پول از کیف پول کاربر کم شد";
            public const string WalletNotDecreased = "پول از کیف پول کاربر کم نشد";
            public const string GetUserRecentTransfer = "اخرین انتقالات کاربر دریافت شد";
            public const string UserNotHaveAnyTransfer = "کاربر مورد نظر هیچ نقل و انتقالاتی انجام نداده است";
            public const string GetUserCoinTransfersSum = "جمع مبلغ تراکنش های کاربر دریافت شد - گردش مالی";
            public const string GetUsersCoinTransfersSum = "جمع مبلغ تراکنش های کاربران دریافت شد - گردش مالی";
            public const string GetCoinTransfersSum = "جمع مبلغ تراکنش ها دریافت شد - گردش مالی";
            public const string GetMarineCoinTransfer = "تراکنش مالی دریایی دریافت شد";
            public const string GetMarineCoinTransferFail = "دریافت تراکنش مالی دریایی با شکست مواجه شد";
            public const string GetMarineCoinTransfers = "تراکنش های مالی دریایی دریافت شد";
            public const string NotHaveAnyCoinTransfers = "تراکنش های مالی دریایی ای وجود ندارد";
            public const string GetTotalUsersWallet = "جمع کیف پول کل کاربران دریافت شد";

            #endregion

            #region Conversations
            public const string EnterTitleOfConversation = "عنوان تالار گفت و گو را وارد کنید";
            public const string WrongConversationID = "آیدی تالار گفت و گو وارد کنید";
            public const string ConversationNotAdded = "تالار گفت و گو ساخته نشد. دوباره امتحان کنید";
            public const string ConversationAdded = "تالار گفت و گو ساخته شد";
            public const string ConversationClosed = "تالار گفت و گو بسته شد";
            public const string ConversationReOpened = "تالار گفت و گو دوباره باز شد";
            public const string ConversationChangeToLessPriority = "تالار گفت و گو دوباره کم اهمیت شد";
            public const string ConversationChangeToMediumPriority = "اهمیت تالار گفت و گو متوسط شد";
            public const string ConversationChangeToHighPriority = "اهمیت تالار گفت و گو زیاد شد";
            public const string GetConversation = "تالار گفت و گو در دسترس است";
            public const string ConversationNotFound = "تالار گفت و گو پیدا نشد";
            public const string GetAllOpenLessPriorityConversations = "همه تالار گفت و گو های باز با اهمیت کم در دسترس هستند";
            public const string GetAllClosedLessPriorityConversations = "همه تالار گفت و گو های بسته با اهمیت کم در دسترس هستند";
            public const string GetAllOpenMediumPriorityConversations = "همه تالار گفت و گو های باز با اهمیت متوسط در دسترس هستند";
            public const string GetAllClosedMediumPriorityConversations = "همه تالار گفت و گو های بسته با اهمیت متوسط در دسترس هستند";
            public const string GetAllOpenHighPriorityConversations = "همه تالار گفت و گو های باز با اهمیت زیاد در دسترس هستند";
            public const string GetAllClosedHighPriorityConversations = "همه تالار گفت و گو های بسته با اهمیت زیاد در دسترس هستند";
            public const string MarineNotHaveOpenLessPriorityConversations = "تالار گفت و گوی باز با اهمیت کم در مارینا وجود ندارد";
            public const string MarineNotHaveClosedLessPriorityConversations = "تالار گفت و گوی بسته با اهمیت کم در مارینا وجود ندارد";
            public const string MarineNotHaveOpenMediumPriorityConversations = "تالار گفت و گوی باز با اهمیت متوسط در مارینا وجود ندارد";
            public const string MarineNotHaveClosedMediumPriorityConversations = "تالار گفت و گوی بسته با اهمیت متوسط در مارینا وجود ندارد";
            public const string MarineNotHaveOpenHighPriorityConversations = "تالار گفت و گوی باز با اهمیت زیاد در مارینا وجود ندارد";
            public const string MarineNotHaveClosedHighPriorityConversations = "تالار گفت و گوی بسته با اهمیت زیاد در مارینا وجود ندارد";
            public const string GetAllConversation = "همه تالار گفت و گو ها در دسترس است";
            public const string GetAllConversationMessages = "همه پیام های تالار گفت و گو در دسترس است";
            public const string ConversationNotHaveMessages = "پیامی برای تالار گفت و گوی مورد نظر وجود ندارد";
            public const string GetAllConversationDeletedMessages = "همه پیام های حذف شده تالار گفت و گو در دسترس است";
            public const string ConversationNotHaveDeletedMessages = "تالار گفت و گو پیام پاک شده ندارد";
            public const string FoundedConversationMessage = "پیام جستجو شده برای تالار گفت و گو پیدا شد";
            public const string NotFoundedConversationMessage = "پیام جستجو شده برای تالار گفت و گو پیدا نشد";

            #endregion

            #region Messages
            public const string MessageAddedToConversation = "پیام به تالار گفت و گو اضافه شد";
            public const string MessageNotAddedToConversation = "پیام به تالار گفت و گو اضافه نشد";
            public const string GetMessage = "پیام در دسترس است";
            public const string GetAllUserMessage = "همه پیام های کاربر در دسترس هستند";
            public const string GetAllUserDeletedMessage = "همه پیام های پاک شده کاربر در دسترس هستند";
            public const string UserNotHaveMessage = "پیامی برای کاربر مورد نظر وجود ندارد";
            public const string MarineNotHaveDeleteMessage = "پیام پاک شده ای برای مارینا وجود ندارد";
            public const string UserNotHaveDeletedMessage = "پیام پاک شده ای برای کاربر مورد نظر وجود ندارد";
            public const string GetAllDeletedMessage = "همه پیام های پاک شده در دسترس هستند";
            public const string Message = "پیام در دسترس است";
            public const string SearchedMessageFound = "پیام جستجو شده در دسترس است";
            public const string SearchedUserMessageFound = "پیام جستجو شده کاربر در دسترس است";
            public const string SearchedUserMessageNotFound = "پیام جستجو شده کاربر پیدا نشد";
            public const string MessageForSearchNotFound = "پیامی برای جست و جو کردن یافت نشد";
            public const string SearchedMessageNotFound = "پیام جستجو شده پیدا نشد";
            public const string MessageDeleted = "پیام مورد نظر پاک شد";
            public const string MessageNotFound = "پیام مورد نظر پیدا نشد";
            public const string MessageEdited = "پیام مورد نظر ویرایش شد";

            #endregion

            #region Tickets
            public const string EnterNumOfTicket = "تعداد بلیط درخواستی را وارد کنید";
            public const string TicketBuyed = "بلیط خریده شد - رزرو شد";
            public const string TicketNotBuys = "بلیط خریده نمیشود";
            public const string TicketAddedToBasketBuy = "بلیط وارد سبد خرید شد";
            public const string TicketNotAddToBasketBuy = "بلیط وارد سبد خرید نمیشود";
            public const string TicketCanceled = "بلیط با موفقیت لغو شد";
            public const string TicketNotCanceled = "بلیط لغو نشد";
            public const string TicketReserved = "بلیط ثبت خرید شد - رزرو شد";
            public const string TicketNotReserved = "بلیط رزرو نشد";
            public const string TicketChangedCondition = "وضعیت بلیط تغییر کرد";
            public const string TicketNotChangedCondition = "وضعیت بلیط تغییر نکرد";
            public const string TicketGetted = "بلیط در دسترس است";
            public const string TicketNotGetted = "بلیط در دسترس نیست";
            public const string TicketReservedSearchedDateGetted = "بلیط رزرو شده با تاریخ داده شده در دسترس است";
            public const string TicketReservedSearchedDateCountGetted = "تعداد بلیط رزرو شده با تاریخ داده شده در دسترس است";
            public const string TicketInActivedSearchedDateCountGetted = "تعداد بلیط غیرفعال با تاریخ داده شده در دسترس است";
            public const string TicketCanceledSearchedDateCountGetted = "تعداد بلیط لغو شده با تاریخ داده شده در دسترس است";
            public const string TicketDeleted = "بلیط با موفقیت پاک شد";
            public const string TicketNotDeleted = "بلیط پاک نشد";
            public const string AllScheduleTicketsGetted = "همه بلیط های سانس در دسترس است";
            public const string AllFunTicketsGetted = "همه بلیط های تفریح در دسترس است";
            public const string AllUserTicketsGetted = "همه بلیط های کاربر در دسترس است";
            public const string AllScheduleTicketsCountGetted = "تعداد همه بلیط های سانس در دسترس است";
            public const string AllFunTicketsCountGetted = "تعداد همه بلیط های تفریح در دسترس است";
            public const string AllUserTicketsCountGetted = "تعداد همه بلیط های کاربر در دسترس است";
            public const string AllScheduleInActiveTicketsGetted = "همه بلیط های غیرفعال (تو سبد خرید) سانس در دسترس است";
            public const string AllFunInActiveTicketsGetted = "همه بلیط های غیرفعال (تو سبد خرید) تفریح در دسترس است";
            public const string AllUserInActiveTicketsGetted = "همه بلیط های غیرفعال (تو سبد خرید) کاربر در دسترس است";
            public const string AllScheduleInActiveTicketsCountGetted = "تعداد همه بلیط های غیرفعال (تو سبد خرید) سانس در دسترس است";
            public const string AllFunInActiveTicketsCountGetted = "تعداد همه بلیط های غیرفعال (تو سبد خرید) تفریح در دسترس است";
            public const string AllUserInActiveTicketsCountGetted = "تعداد همه بلیط های غیرفعال (تو سبد خرید) کاربر در دسترس است";
            public const string AllScheduleReservedTicketsGetted = "همه بلیط های رزرو شده سانس در دسترس است";
            public const string AllFunReservedTicketsGetted = "همه بلیط های رزرو شده تفریح در دسترس است";
            public const string AllUserReservedTicketsGetted = "همه بلیط های رزرو شده کاربر در دسترس است";
            public const string AllScheduleReservedTicketsCountGetted = "تعداد همه بلیط های رزرو شده سانس در دسترس است";
            public const string AllFunReservedTicketsCountGetted = "تعداد همه بلیط های رزرو شده تفریح در دسترس است";
            public const string AllUserReservedTicketsCountGetted = "تعداد همه بلیط های رزرو شده کاربر در دسترس است";
            public const string AllScheduleReservedTicketsTotalPriceGetted = "مقدار پول کل بلیط های فروخته شده(رزرو شده) یک سانس در دسترس است";
            public const string AllScheduleCanceledTicketsGetted = "همه بلیط های لغو شده سانس در دسترس است";
            public const string AllFunCanceledTicketsGetted = "همه بلیط های لغو شده تفریح در دسترس است";
            public const string AllUserCanceledTicketsGetted = "همه بلیط های لغو شده کاربر در دسترس است";
            public const string AllScheduleCanceledTicketsCountGetted = "تعداد همه بلیط های لغو شده سانس در دسترس است";
            public const string AllFunCanceledTicketsCountGetted = "تعداد همه بلیط های لغو شده تفریح در دسترس است";
            public const string AllUserCanceledTicketsCountGetted = "تعداد همه بلیط های لغو شده کاربر در دسترس است";
            public const string ScheduleNotHaveTickets = "بلیطی برای سانس مورد نظر وجود ندارد";
            public const string FunNotHaveTickets = "بلیطی برای تفریح مورد نظر وجود ندارد";
            public const string UserNotHaveTickets = "بلیطی برای کاربر مورد نظر وجود ندارد";
            public const string ScheduleNotHaveInActiveTickets = "بلیط غیر فعالی برای سانس مورد نظر وجود ندارد";
            public const string FunNotHaveInActiveTickets = "بلیط غیر فعالی برای تفریح مورد نظر وجود ندارد";
            public const string UserNotHaveInActiveTickets = "بلیط غیر فعالی برای کاربر مورد نظر وجود ندارد";
            public const string ScheduleNotHaveActiveTickets = "بلیط فعالی برای سانس مورد نظر وجود ندارد";
            public const string FunNotHaveActiveTickets = "بلیط فعالی برای تفریح مورد نظر وجود ندارد";
            public const string UserNotHaveActiveTickets = "بلیط فعالی برای کاربر مورد نظر وجود ندارد";
            public const string ScheduleNotHaveCanceledTickets = "بلیط لغو شده ای برای سانس مورد نظر وجود ندارد";
            public const string FunNotHaveCanceledTickets = "بلیط لغو شده ای برای تفریح مورد نظر وجود ندارد";
            public const string UserNotHaveCanceledTickets = "بلیط لغو شده ای برای کاربر مورد نظر وجود ندارد";
            public const string AllTicketsGeted = "همه بلیط های مارینا دریافت شد";
            public const string AllSiteResevationTicketsGeted = "همه بلیط های خریده شده از سایت دریافت شد";
            public const string AllPrecentReservationTicketsGeted = "همه بلیط های خریده شده بصورت حضوری دریافت شد";
            public const string AllTicketsCountGeted = "تعداد همه بلیط های مارینا دریافت شد";
            public const string AllInActiveTicketsDeletedSuccessfully = "همه بلیط های در سبد خرید پاک شد";
            public const string AllInActiveTicketsDeletedFaild = "پاک کردن بعضی بلیط های در سبد خرید با شکست مواجه شد";
            public const string AllInActiveTicketsGeted = "همه بلیط های غیر فعال مارینا دریافت شد";
            public const string AllInActiveTicketsCountGeted = "تعداد همه بلیط های غیر فعال مارینا دریافت شد";
            public const string AllReservedTicketsGeted = "همه بلیط های رزرو شده مارینا دریافت شد";
            public const string AllReservedTicketsCountGeted = "تعداد همه بلیط های رزرو شده مارینا دریافت شد";
            public const string AllCanceledTicketsGeted = "همه بلیط های لغو شده مارینا دریافت شد";
            public const string AllCanceledTicketsCountGeted = "تعداد همه بلیط های لغو شده مارینا دریافت شد";
            public const string NoAllTicket = "درحال حاضر بلیطی برای مارینا وجود ندارد";
            public const string NoAllSiteReservationTicket = "درحال حاضر بلیط خریده شده از سایتی وجود ندارد";
            public const string NoAllPrecentReservationTicket = "درحال حاضر بلیط خریده شده بصورت حضوری ای وجود ندارد";
            public const string NoAllInActiveTicket = "درحال حاضر هیچ بلیط غیرفعالی برای مارینا وجود ندارد";
            public const string NoAllReservedTicket = "درحال حاضر هیچ بلیط رزرو شده ای برای مارینا وجود ندارد";
            public const string NoAllCanceledTicket = "درحال حاضر هیچ بلیط لغو شده ای برای مارینا وجود ندارد";
            public const string NotHaveActiveTicketsAtThisTime = "بلیط فعالی در تاریخ مورد نظر یافت نشد - بلیطی وجود ندارد";
            public const string NotHaveInActiveTicketsAtThisTime = "بلیط غیرفعالی در تاریخ مورد نظر یافت نشد - بلیطی وجود ندارد";
            public const string NotHaveCanceledTicketsAtThisTime = "بلیط لغو شده ای در تاریخ مورد نظر یافت نشد - بلیطی وجود ندارد";
            public const string ActiveTicketsPriceDateSumGetted = "جمع مبلغ بلیط های فعال در تاریخ مورد نظر دریافت شد";


            #endregion

            #region Comments
            public const string IncreaseLikeFaild = "افزایش لایک کامنت مورد نظر با شکست مواجه شد";
            public const string DecreaseLikeFaild = "کاهش لایک کامنت مورد نظر با شکست مواجه شد";
            public const string WrongCommentId = "آیدی کامنت مورد نظر اشتباه است";
            public const string CommentStatusNotChanged = "وضعیت کامنت مورد نظر عوض نشد";
            public const string CommentsStatusNotChanged = "وضعیت کامنت های مورد نظر عوض نشد";
            public const string FunNotHaveAnyAcceptedComment = "تفریح مورد نظر کامنت قبول شده ای ندارد";
            public const string FunAcceptedCommentGetted = "کامنت های قبول شده ی تفریح مورد نظر دریافت شد";
            public const string CommentStatusChanged = "وضعیت کامنت مورد نظر عوض شد";
            public const string CommentsStatusChanged = "وضعیت کامنت های مورد نظر عوض شد";
            public const string CommentAddedPlsWait = "کامنت مورد نظر اضافه شد . منتظر بمانید تا کامنت شما قبول شود";
            public const string IncreasedLike = "افزایش لایک کامنت مورد نظر با موفقیت انجام شد";
            public const string DecreasedLike = "کاهش لایک کامنت مورد نظر با موفقیت انجام شد";
            public const string AllUserCommentsBlocked = "همه کامنت های یک کاربر دریافت شد";
            public const string CommentNotFound = "کامنت مورد نظر پیدا نشد";
            public const string FunCommentsNotFound = "کامنت های تفریح مورد نظر پیدا نشد";
            public const string CommentAccepted = "کامنت مورد نظر قبول شد";
            public const string CommentDeclined = "کامنت مورد نظر رد شد";
            public const string CommentBlocked = "کامنت مورد نظر بلاک شد";
            public const string WaitingFunCommentsGetted = "کامنت های درحال انتظار تفریح مورد نظر دریافت شد";
            public const string AcceptedFunCommentsGetted = "کامنت های قبول شده تفریح مورد نظر دریافت شد";
            public const string DeclinedFunCommentsGetted = "کامنت های رد شده تفریح مورد نظر دریافت شد";
            public const string BlockedFunCommentsGetted = "کامنت های بلاک شده تفریح مورد نظر دریافت شد";
            #endregion

            #region ContactUs
            public const string ContactUsAdded = "اضافه شد";
            public const string ContactUsWrongInformation = " اطلاعات وارد شده درست می باشد";
            public const string ContactUsNotExisted = "یافت نشد";
            public const string ContactUsGet = "مشخصلت دریافت شذ";
            public const string ContactUsAboutMarianaUpdated = "با موفقیت ویرایش شد";
            public const string ContactUsRulesUpdated = "قوانین با موفقیت ویرایش شد";
            public const string ContactUsEmailUpdated = "ایمیل با موفقیت ویرایش شد";
            public const string ContactUsPhoneNumberUpdated = "شماره تلفن با موفقیت ویرایش شد";
            public const string ContactUsUrlLinkedinUpdated = "آدرس لیندین با موفقیت ویرایش شد";
            public const string ContactUsUrlInstagramUpdated = "آدرس اینستگرام با موفقیت ویرایش شد";
            #endregion
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Globalization;
using Application.Commands;
using Application.Commands.Ticket;
using Application.Services.interfaces;

namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ApiController
    {
        private readonly ITicketService _ticketService;
        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        /// <summary>
        /// اضافه کردن بلیط خریده شده در سایت - به سبد خرید 
        /// </summary>
        [HttpPost("AddTicketBasket")] // be sabade kharid ezaf mishe -user id-
        public async Task<IActionResult> AddTicketForBasket(AddTicketToBasketCommand command)
        {
            if (!command.Validate())
                return BadReq(ApiMessage.EnterNumOfTicket, new { Reasons = $"1-enter schedule id, 2-enter user id, 3-number of ticket must at least 1 and max 10" });

            var result = await _ticketService.AddTicketToSite(command);
            if (result == null)
                return BadReq(ApiMessage.TicketNotAddToBasketBuy, new { Reasons = $"1-number of ticket greater than schedule available ticket, 2-schedule is not active, 3-user is blocked, 4-schedule not found, 5-user not found" });
            return OkResult(ApiMessage.TicketAddedToBasketBuy, new { TicketID = result.Value });
        }



        #region Schedule Options

        /// <summary>
        /// دریافت تمام بلیط های یک سانس
        /// </summary>
        [HttpGet("{id}/GetAllScheduleTickets")] // ScheduleId ( schedules model )
        public async Task<IActionResult> GetAllScheduleTickets(Guid id)
        {
            var result = await _ticketService.GetAllScheduleTickets(id);
            if (result == null)
                return BadReq(ApiMessage.ScheduleNotHaveTickets, new { Reasons = $"1-Schedule not have any ticket, 2-schedule id is wrong" });
            return OkResult(ApiMessage.AllScheduleTicketsGetted, new { ScheduleTickets = result });
        }

        /// <summary>
        /// دریافت کل بلیط های غیرفعال یک سانس
        /// </summary>
        [HttpGet("{id}/AllInActiveScheduleTickets")] // ScheduleId ( schedules model )
        public async Task<IActionResult> AllInActiveScheduleTickets(Guid id)
        {
            var result = await _ticketService.AllInActiveScheduleTickets(id);
            if (result == null)
                return BadReq(ApiMessage.ScheduleNotHaveInActiveTickets, new { Reasons = $"1-Schedule not have any active ticket, 2-schedule id is wrong" });
            return OkResult(ApiMessage.AllScheduleInActiveTicketsGetted, new { AllInActiveScheduleTickets = result });
        }

        /// <summary>
        /// دریافت کل بلیط های غیرفعال یک سانس
        /// </summary>
        [HttpGet("getCatchallscenarios")]
        public async Task<IActionResult> GetByCatchAllScenarios(GetAllTicketByAllModesCommand command)
        {
            if (!command.Validate())
                return BadReq(ApiMessage.EnterNumOfTicket, new { Reasons = $"1-مقدار وضقیت نباید بیشتر از 3 باشد 2- مقدار محل خرید نباید بیشتر از 3 باشد" });


            var result = await _ticketService.GetAll(command);
            return OkResult(ApiMessage.AllScheduleInActiveTicketsGetted, new { AllInActiveScheduleTickets = result });
        }







        //        /// <summary>
        //        /// دریافت همه بلیط های فعال یک سانس با آیدی سانس
        //        /// </summary>
        //        [HttpGet("GetAll-ScheduleActiveTickets-ScheduleID/{id}")] // ScheduleId ( schedules model )
        //        public async Task<IActionResult> GetAllScheduleActiveTickets(Guid id)
        //        {
        //            var result = await _ticketService.GetAllScheduleActiveTickets(id);
        //            if (result == null)
        //                return BadReq(ApiMessage.ScheduleNotHaveActiveTickets, new { Reasons = $"1-Schedule not have any reserved ticket, 2-schedule id is wrong" });
        //            return OkResult(ApiMessage.AllScheduleReservedTicketsGetted, new { ScheduleActiveTickets = result });
        //        }

        //        /// <summary>
        //        /// دریافت همه بلیط های لغو شده یک سانس
        //        /// </summary>
        //        [HttpGet("GetAll-ScheduleCanceledTickets-ScheduleID/{id}")] // ScheduleId ( schedules model )
        //        public async Task<IActionResult> GetAllScheduleCanceledTickets(Guid id)
        //        {
        //            var result = await _ticketService.GetAllScheduleCanceledTickets(id);
        //            if (result == null)
        //                return BadReq(ApiMessage.ScheduleNotHaveCanceledTickets, new { Reasons = $"1-Schedule not have any canceled ticket, 2-schedule id is wrong" });
        //            return OkResult(ApiMessage.AllScheduleCanceledTicketsGetted, new { ScheduleActiveTickets = result });
        //        }

        //        /// <summary>
        //        /// دریافت تعداد کل بلیط های غیرفعال یک سانس
        //        /// </summary>
        //        [HttpGet("InActiveSchedule-Count/{id}")] // scheduleId ( schedules model )
        //        public async Task<IActionResult> InActiveScheduleTicketsCount(Guid id)
        //        {
        //            var result = await _ticketService.AllInActiveScheduleTickets(id);
        //            if (result == null)
        //                return OkResult(ApiMessage.AllScheduleInActiveTicketsCountGetted, new { InActiveScheduleTicketsCount = $"0 - Schedule not have any inActive ticket" });
        //            return OkResult(ApiMessage.AllScheduleInActiveTicketsCountGetted, new { InActiveScheduleTicketsCount = result.Count });
        //        }

        //        /// <summary>
        //        /// دریافت تعداد کل بلیط های رزرو شده یک سانس
        //        /// </summary>
        //        [HttpGet("AllReservationSchedule-Count/{id}")] // scheduleId ( schedules model )
        //        public async Task<IActionResult> ReservationScheduleTicketsCount(Guid id)
        //        {
        //            var result = await _ticketService.GetAllScheduleActiveTickets(id);
        //            if (result == null)
        //                return OkResult(ApiMessage.AllScheduleReservedTicketsCountGetted, new { Reason = $"0 - Schedule not have any reserved ticket" });
        //            return OkResult(ApiMessage.AllScheduleReservedTicketsCountGetted, new { ReservationScheduleTicketsCount = result.Count });
        //        }

        //        /// <summary>
        //        /// دریافت تعداد کل بلیط های لغو شده یک سانس
        //        /// </summary>
        //        [HttpGet("CanceledSchedule-Count/{id}")] // scheduleId ( schedules model )
        //        public async Task<IActionResult> CanceledScheduleTicketsCount(Guid id)
        //        {
        //            var result = await _ticketService.GetAllScheduleCanceledTickets(id);
        //            if (result == null)
        //                return OkResult(ApiMessage.AllScheduleCanceledTicketsCountGetted, new { CanceledScheduleTicketsCount = $"0 - Schedule not have any canceled ticket" });
        //            return OkResult(ApiMessage.AllScheduleCanceledTicketsCountGetted, new { CanceledScheduleTicketsCount = result.Count });
        //        }

        //        /// <summary>
        //        /// دریافت تعداد بلیط ها برای یک سانس
        //        /// </summary>
        //        [HttpGet("{id}/ScheduleTickets-Count")] // ScheduleId ( schedules model )
        //        public async Task<IActionResult> ScheduleTicketsCount(Guid id)
        //        {
        //            var result = await _ticketService.GetAllScheduleTickets(id);
        //            if (result == null)
        //                return BadReq(ApiMessage.AllScheduleTicketsCountGetted, new { ScheduleTicketsCount = $"0 - Schedule not have any ticket" });
        //            return OkResult(ApiMessage.AllScheduleTicketsCountGetted, new { ScheduleTicketsCount = result.Count });
        //        }

        /// <summary>
        ///  دریافت مقدار پول کل بلیط های فروخته شده یک سانس با ایدی سانس
        /// </summary>
        [HttpGet("{id}/ScheduleTicketsPrice")] 
        public async Task<IActionResult> ScheduleTicketsTotalPrice(Guid schedulId)
        {
            var result = await _ticketService.ScheduleTicketsPrice(schedulId);
            return OkResult(ApiMessage.AllScheduleReservedTicketsTotalPriceGetted, new { ScheduleTicketsTotalPrice = result });
        }

        //        #endregion

        //        #region Fun Options

        //        /// <summary>
        //        /// دریافت همه بلیط های یک تفریح با آیدی تفریح
        //        /// </summary>
        //        [HttpGet("GetAll-FunTickets-FunID/{id}")] // FunId ( funs model )
        //        public async Task<IActionResult> GetAllFunTicketsWithFunID(Guid id)
        //        {
        //            var result = await _ticketService.GetAllFunTicketsWithFunID(id);
        //            if (result == null)
        //                return BadReq(ApiMessage.FunNotHaveTickets, new { Reasons = $"1-eFun not have any ticket, 2-eFun id is wrong" });
        //            return OkResult(ApiMessage.AllFunTicketsGetted, new { FunTickets = result });
        //        }


        //        /// <summary>
        //        /// دریافت کل بلیط های غیرفعال یک تفریح با آیدی تفریح
        //        /// </summary>
        //        [HttpGet("GetAll-FunInActiveTickets-FunID/{id}")] // funId ( funs model )
        //        public async Task<IActionResult> AllFunInActiveTickets(Guid id)
        //        {
        //            var result = await _ticketService.AllFunInActiveTickets(id);
        //            if (result == null)
        //                return BadReq(ApiMessage.FunNotHaveInActiveTickets, new { Reasons = $"1-eFun not have any inActive ticket, 2-eFun id is wrong" });
        //            return OkResult(ApiMessage.AllFunInActiveTicketsGetted, new { AllFunInActiveTickets = result });
        //        }

        /// <summary>
        /// دریافت همه بلیط های رزرو شده یک تفریح با نام تفریح
        /// </summary>
        [HttpGet("GetAll-FunActiveTickets-FunID/{id}")]
        public async Task<IActionResult> GetAllFunActiveTicketsWithFunName(string funName)
        {
            var result = await _ticketService.GetAllFunActiveTicketsWithFunName(funName);
            if (result == null)
                return BadReq(ApiMessage.FunNotHaveActiveTickets, new { Reasons = $"1-eFun not have any reserved ticket, 2-eFun id is wrong" });
            return OkResult(ApiMessage.AllFunReservedTicketsGetted, new { FunTickets = result });
        }

        //        /// <summary>
        //        /// دریافت همه بلیط های لغو شده یک تفریح با آیدی تفریح
        //        /// </summary>
        //        [HttpGet("GetAll-FunCanceledTickets-FunID/{id}")] // FunId ( funs model )
        //        public async Task<IActionResult> GetAllFunCanceledTicketsWithFunID(Guid id)
        //        {
        //            var result = await _ticketService.GetAllFunCanceledTicketsWithFunID(id);
        //            if (result == null)
        //                return BadReq(ApiMessage.FunNotHaveCanceledTickets, new { Reasons = $"1-eFun not have any canceled ticket, 2-eFun id is wrong" });
        //            return OkResult(ApiMessage.AllFunCanceledTicketsGetted, new { FunTickets = result });
        //        }

        //        /// <summary>
        //        /// دریافت تعداد کل بلیط های غیرفعال یک تفریح با آیدی تفریح
        //        /// </summary>
        //        [HttpGet("AllInActiveFun-Count/{id}")] // funId ( funs model )
        //        public async Task<IActionResult> AllFunInActiveTicketsCount(Guid id)
        //        {
        //            var result = await _ticketService.AllFunInActiveTickets(id);
        //            if (result == null)
        //                return OkResult(ApiMessage.AllFunInActiveTicketsCountGetted, new { AllFunInActiveTicketsCount = $"0 - eFun not have any inActive ticket" });
        //            return OkResult(ApiMessage.AllFunInActiveTicketsCountGetted, new { AllFunInActiveTicketsCount = result.Count });
        //        }

        //        /// <summary>
        //        /// دریافت تعداد کل بلیط های رزرو شده یک تفریح
        //        /// </summary>
        //        [HttpGet("AllReservationFun-Count/{id}")] // funId ( funs model )
        //        public async Task<IActionResult> ReservationFunTicketsCount(Guid id)
        //        {
        //            var result = await _ticketService.GetAllFunActiveTicketsWithFunID(id);
        //            if (result == null)
        //                return OkResult(ApiMessage.AllFunReservedTicketsCountGetted, new { ReservationFunTicketsCount = $"0 - eFun not have any reserved ticket" });
        //            return OkResult(ApiMessage.AllFunReservedTicketsCountGetted, new { ReservationFunTicketsCount = result.Count });
        //        }

        //        /// <summary>
        //        /// دریافت تعداد کل بلیط های لغو شده یک تفریح با آیدی تفریح
        //        /// </summary>
        //        [HttpGet("AllCanceledFun-Count/{id}")] // funId ( funs model )
        //        public async Task<IActionResult> CanceledFunTicketsCount(Guid id)
        //        {
        //            var result = await _ticketService.GetAllFunCanceledTicketsWithFunID(id);
        //            if (result == null)
        //                return OkResult(ApiMessage.AllFunCanceledTicketsCountGetted, new { CanceledFunTicketsCount = $"0 - eFun not have any canceled ticket" });
        //            return OkResult(ApiMessage.AllFunCanceledTicketsCountGetted, new { CanceledFunTicketsCount = result.Count });
        //        }

        #endregion


        //        #region User Options


        //        /// <summary>
        //        /// دریافت کل بلیط های غیرفعال یک کاربر - سبد خرید
        //        /// </summary>
        //        [HttpGet("GetAll-UserInActiveTickets-UserID/{id}")] // sabade kharid - userId (users model)
        //        public async Task<IActionResult> AllUserInActiveTickets(Guid id)
        //        {
        //            var result = await _ticketService.AllUserInActiveTickets(id);
        //            if (result == null)
        //                return BadReq(ApiMessage.UserNotHaveInActiveTickets, new { Reason = $"user not have any InActive ticket ( in banketBuy )" });
        //            return OkResult(ApiMessage.AllUserInActiveTicketsGetted, new { AllUserInActiveTickets = result });
        //        }

        //        /// <summary>
        //        /// دریافت همه بلیط های یک کاربر با آیدی کاربر
        //        /// </summary>
        //        [HttpGet("GetAll-UserTickets-UserID/{id}")] // UserId ( users model )
        //        public async Task<IActionResult> GetAllUserTikcetsWithUserID(Guid id)
        //        {
        //            var result = await _ticketService.GetAllUserTikcetsWithUserID(id);
        //            if (result == null)
        //                return BadReq(ApiMessage.AllUserTicketsGetted, new { Reason = $"user not have any ticket" });
        //            return OkResult(ApiMessage.AllUserTicketsGetted, new { UserTickets = result });
        //        }

        //        /// <summary>
        //        /// دریافت همه بلیط های رزرو شده یک کاربر با آیدی کاربر
        //        /// </summary>
        //        [HttpGet("GetAll-UserActiveTickets-UserID/{id}")] // UserId ( users model )
        //        public async Task<IActionResult> GetAllUserActiveTikcetsWithUserID(Guid id)
        //        {
        //            var result = await _ticketService.GetAllUserActiveTikcetsWithUserID(id);
        //            if (result == null)
        //                return BadReq(ApiMessage.UserNotHaveActiveTickets, new { Reason = $"user not have any reserved ticket" });
        //            return OkResult(ApiMessage.AllUserReservedTicketsGetted, new { UserTickets = result });
        //        }

        //        /// <summary>
        //        /// دریافت همه بلیط های لغو شده یک کاربر با آیدی کاربر
        //        /// </summary>
        //        [HttpGet("GetAll-UserCanceledTickets-UserID/{id}")] // UserId ( users model )
        //        public async Task<IActionResult> GetAllUserCanceledTikcetsWithUserID(Guid id)
        //        {
        //            var result = await _ticketService.GetAllUserCanceledTikcetsWithUserID(id);
        //            if (result == null)
        //                return BadReq(ApiMessage.UserNotHaveCanceledTickets, new { Reason = $"user not have any ticket" });
        //            return OkResult(ApiMessage.AllUserCanceledTicketsGetted, new { UserTickets = result });
        //        }

        //        /// <summary>
        //        /// دریافت تعداد کل بلیط های غیرفعال یک کاربر
        //        /// </summary>
        //        [HttpGet("AllInActiveUser-Count/{id}")] //userId (users model)
        //        public async Task<IActionResult> InActiveUserTicketsCount(Guid id)
        //        {
        //            var result = await _ticketService.AllUserInActiveTickets(id);
        //            if (result == null)
        //                return OkResult(ApiMessage.AllUserInActiveTicketsCountGetted, new { InActiveUserTicketsCount = $"0 - user not have any InActive ticket" });
        //            return OkResult(ApiMessage.AllUserInActiveTicketsCountGetted, new { InActiveUserTicketsCount = result.Count });
        //        }

        //        /// <summary>
        //        /// دریافت تعداد کل بلیط های رزرو یک کاربر
        //        /// </summary>
        //        [HttpGet("AllReservationUser-Count/{id}")] //userId (users model)
        //        public async Task<IActionResult> ReservationUserTicketsCount(Guid id)
        //        {
        //            var result = await _ticketService.GetAllUserActiveTikcetsWithUserID(id);
        //            if (result == null)
        //                return OkResult(ApiMessage.AllUserReservedTicketsCountGetted, new { ReservationUserTicketsCount = $"0 - user not have any reserved ticket" });
        //            return OkResult(ApiMessage.AllUserReservedTicketsCountGetted, new { ReservationUserTicketsCount = result.Count });
        //        }

        //        /// <summary>
        //        /// دریافت تعداد کل بلیط های لغو شده یک کاربر
        //        /// </summary>
        //        [HttpGet("AllCanceledUser-Count/{id}")] //userId (users model)
        //        public async Task<IActionResult> CanceledUserTicketsCount(Guid id)
        //        {
        //            var result = await _ticketService.GetAllUserCanceledTikcetsWithUserID(id);
        //            if (result == null)
        //                return OkResult(ApiMessage.AllUserCanceledTicketsCountGetted, new { CanceledUserTicketsCount = $"0 - user not have any canceled ticket" });
        //            return OkResult(ApiMessage.AllUserCanceledTicketsCountGetted, new { CanceledUserTicketsCount = result.Count });
        //        }

        //        #endregion

        //        #region All Options

        //        /// <summary>
        //        /// دریافت همه بلیط ها
        //        /// </summary>
        //        [HttpGet("All")]
        //        public async Task<IActionResult> AllTickets()
        //        {
        //            var result = await _ticketService.AllTickets();
        //            if (result == null)
        //                return BadReq(ApiMessage.NoAllTicket, new { Reason = "any ticket not found" });
        //            return OkResult(ApiMessage.AllTicketsGeted, new { AllTickets = result });
        //        }

        //        /// <summary>
        //        /// دریافت همه بلیط های رزرو شده
        //        /// </summary>
        //        [HttpGet("AllReservation")]
        //        public async Task<IActionResult> AllReservationTickets()
        //        {
        //            var result = await _ticketService.AllReservationTickets();
        //            if (result == null)
        //                return BadReq(ApiMessage.NoAllReservedTicket, new { Reason = "any reserved ticket not found" });
        //            return OkResult(ApiMessage.AllReservedTicketsGeted, new { AllTickets = result });
        //        }

        //        /// <summary>
        //        /// دریافت همه بلیط های رزروی خریده شده از سایت
        //        /// </summary>
        //        [HttpGet("AllSiteReservation")]
        //        public async Task<IActionResult> AllSiteReservationTickets()
        //        {
        //            var result = await _ticketService.AllSiteReservationTickets();
        //            if (result == null)
        //                return BadReq(ApiMessage.NoAllSiteReservationTicket, new { Reason = "any site buyed ticket not found" });
        //            return OkResult(ApiMessage.AllSiteResevationTicketsGeted, new { AllSiteReservationTickets = result });
        //        }

        //        /// <summary>
        //        /// دریافت همه بلیط های رزروی خریده شده بصورت حضوری
        //        /// </summary>
        //        [HttpGet("AllPresenceReservation")]
        //        public async Task<IActionResult> AllPresenceReservationTickets()
        //        {
        //            var result = await _ticketService.AllPresenceReservationTickets();
        //            if (result == null)
        //                return BadReq(ApiMessage.NoAllPrecentReservationTicket, new { Reason = "any presence buyed ticket not found" });
        //            return OkResult(ApiMessage.AllPrecentReservationTicketsGeted, new { AllPresenceReservationTickets = result });
        //        }

        //        /// <summary>
        //        /// دریافت همه بلیط های لغو شده
        //        /// </summary>
        //        [HttpGet("AllCanceled")]
        //        public async Task<IActionResult> AllCanceledTickets()
        //        {
        //            var result = await _ticketService.AllCanceledTickets();
        //            if (result == null)
        //                return BadReq(ApiMessage.NoAllCanceledTicket, new { Reason = "any canceled ticket not found" });
        //            return OkResult(ApiMessage.AllCanceledTicketsGeted, new { AllCanceledTickets = result });
        //        }

        //        /// <summary>
        //        /// دریافت تعداد کل بلیط ها
        //        /// </summary>
        //        [HttpGet("All-Count")]
        //        public async Task<IActionResult> AllTicketsCount()
        //        {
        //            var result = await _ticketService.AllTickets();
        //            if (result == null)
        //                return OkResult(ApiMessage.AllTicketsCountGeted, new { AllTicketsCount = $"0 - any ticket not found" });
        //            return OkResult(ApiMessage.AllTicketsCountGeted, new { AllTicketsCount = result.Count });
        //        }


        //        /// <summary>
        //        /// دریافت تعداد کل بلیط های رزرو شده
        //        /// </summary>
        //        [HttpGet("AllReservation-Count")]
        //        public async Task<IActionResult> AllReservationTicketsCount()
        //        {
        //            var result = await _ticketService.AllReservationTickets();
        //            if (result == null)
        //                return OkResult(ApiMessage.AllReservedTicketsCountGeted, new { AllReservationTicketsCount = $"0 - any reserved ticket not found" });
        //            return OkResult(ApiMessage.AllReservedTicketsCountGeted, new { AllReservationTicketsCount = result.Count });
        //        }

        //        /// <summary>
        //        /// دریافت تعداد کل بلیط های لغو شده
        //        /// </summary>
        //        [HttpGet("AllCanceled-Count")]
        //        public async Task<IActionResult> AllCanceledTicketsCount()
        //        {
        //            var result = await _ticketService.AllCanceledTickets();
        //            if (result == null)
        //                return OkResult(ApiMessage.AllCanceledTicketsCountGeted, new { AllReservationTicketsCount = $"0 - any canceled ticket not found" });
        //            return OkResult(ApiMessage.AllCanceledTicketsCountGeted, new { AllCanceledTicketsCount = result.Count });
        //        }

        //        #endregion

        //        #region Search Options

        //        [HttpGet("SearchReservedByDate-oneDate")]
        //        public async Task<IActionResult> SearchReservedTicketsByOneDate(OneDateSearchCommand command)
        //        {
        //            if (!command.PersianDate.Validate())
        //                return BadReq(ApiMessage.WrongDate, new { Reason = $"Year between 1368 and 1411, Month 1 to 12, Day 1 to 31" });

        //            PersianCalendar persianCalendar = new PersianCalendar();
        //            DateTime firstMiadiParse = new DateTime(command.PersianDate.Year, command.PersianDate.Month, command.PersianDate.Day, persianCalendar);
        //            var result = await _ticketService.SearchReservedTicketsByDate(firstMiadiParse);
        //            if (result == null)
        //                return OkResult(ApiMessage.NotHaveActiveTicketsAtThisTime, new { ReservedTicketsCount = $"0 - any reserved ticket not found in this time" });
        //            return OkResult(ApiMessage.TicketReservedSearchedDateGetted, new { ReservedTicketsFounded = result });
        //        }

        //        [HttpGet("SearchReservedByDate-oneDate-Count")]
        //        public async Task<IActionResult> SearchReservedTicketsByOneDateCount(OneDateSearchCommand command)
        //        {
        //            if (!command.PersianDate.Validate())
        //                return BadReq(ApiMessage.WrongDate, new { Reason = $"Year between 1368 and 1411, Month 1 to 12, Day 1 to 31" });

        //            PersianCalendar persianCalendar = new PersianCalendar();
        //            DateTime firstMiadiParse = new DateTime(command.PersianDate.Year, command.PersianDate.Month, command.PersianDate.Day, persianCalendar);
        //            var result = await _ticketService.SearchReservedTicketsByDate(firstMiadiParse);
        //            if (result == null)
        //                return OkResult(ApiMessage.NotHaveActiveTicketsAtThisTime, new { ReservedTicketsCount = $"0 - any reserved ticket not found in this time" });
        //            return OkResult(ApiMessage.TicketReservedSearchedDateCountGetted, new { ReservedTicketsFoundedCount = result.Count });
        //        }

        //        /// <summary>
        //        /// جست و جوی بلیط رزرو شده با دو تاریخ
        //        /// </summary>
        //        [HttpGet("SearchReservedByDate-twoDate")]
        //        public async Task<IActionResult> SearchReservedTicketsByTwoDate(TwoDateSearchCommand command)
        //        {
        //            if (!command.FirstPersianDate.Validate() || !command.SecondPersianDate.Validate())
        //                return BadReq(ApiMessage.WrongDate, new { Reason = $"Year between 1368 and 1411, Month 1 to 12, Day 1 to 31" });

        //            PersianCalendar persianCalendar = new PersianCalendar();
        //            DateTime firstMiadiParse = new DateTime(command.FirstPersianDate.Year, command.FirstPersianDate.Month, command.FirstPersianDate.Day, persianCalendar);
        //            DateTime secondMiladiParse = new DateTime(command.SecondPersianDate.Year, command.SecondPersianDate.Month, command.SecondPersianDate.Day, persianCalendar);
        //            var result = await _ticketService.SearchReservedTicketsByDate(firstMiadiParse, secondMiladiParse);
        //            if (result == null)
        //                return OkResult(ApiMessage.NotHaveActiveTicketsAtThisTime, new { ReservedTicketsCount = $"0 - any reserved ticket not found in this time" });
        //            return OkResult(ApiMessage.TicketReservedSearchedDateGetted, new { ReservedTicketsFounded = result });
        //        }

        //        /// <summary>
        //        /// جست و جوی تعداد بلیط رزرو شده با دو تاریخ
        //        /// </summary>
        //        [HttpGet("SearchReservedByDate-twoDate-Count")]
        //        public async Task<IActionResult> SearchReservedTicketsByTwoDateCount(TwoDateSearchCommand command)
        //        {
        //            if (!command.FirstPersianDate.Validate() || !command.SecondPersianDate.Validate())
        //                return BadReq(ApiMessage.WrongDate, new { Reason = $"Year between 1368 and 1411, Month 1 to 12, Day 1 to 31" });

        //            PersianCalendar persianCalendar = new PersianCalendar();
        //            DateTime firstMiadiParse = new DateTime(command.FirstPersianDate.Year, command.FirstPersianDate.Month, command.FirstPersianDate.Day, persianCalendar);
        //            DateTime secondMiladiParse = new DateTime(command.SecondPersianDate.Year, command.SecondPersianDate.Month, command.SecondPersianDate.Day, persianCalendar);
        //            var result = await _ticketService.SearchReservedTicketsByDate(firstMiadiParse, secondMiladiParse);
        //            if (result == null)
        //                return OkResult(ApiMessage.NotHaveActiveTicketsAtThisTime, new { ReservedTicketsCount = $"0 - any reserved ticket not found in this time" });
        //            return OkResult(ApiMessage.TicketReservedSearchedDateCountGetted, new { ReservedTicketsCount = result.Count });
        //        }

        /// <summary>
        ///  جست و جوی یک تاریخه برای جمع مبلغ بلیط های فعال
        /// </summary>
        [HttpGet("SearchReservedTicketsPriceoneDateSum")]
        public async Task<IActionResult> SearchReservedTicketsPriceByOneDateSum(OneDateSearchCommand command)
        {
            if (!command.PersianDate.Validate())
                return BadReq(ApiMessage.WrongDate, new { Reason = $"Year between 1368 and 1411, Month 1 to 12, Day 1 to 31" });

            PersianCalendar persianCalendar = new PersianCalendar();
            DateTime firstMiadiParse = new DateTime(command.PersianDate.Year, command.PersianDate.Month, command.PersianDate.Day, persianCalendar);
            var result = await _ticketService.SearchReservedTicketsPriceByDateSum(firstMiadiParse);
            if (result == 0)
                return OkResult(ApiMessage.NotHaveActiveTicketsAtThisTime, new { ReservedTicketsPriceSum = result });
            return OkResult(ApiMessage.ActiveTicketsPriceDateSumGetted, new { ReservedTicketsPriceSum = result });
        }

        ///// <summary>
        /////  جست و جوی دو تاریخه برای جمع مبلغ بلیط های فعال
        ///// </summary>
        //[HttpGet("SearchReservedTicketsPrice-twoDate-Sum")]
        //public async Task<IActionResult> SearchReservedTicketsPriceByTwoDateSum(TwoDateSearchCommand command)
        //{
        //    if (!command.FirstPersianDate.Validate() || !command.SecondPersianDate.Validate())
        //        return BadReq(ApiMessage.WrongDate, new { Reason = $"Year between 1368 and 1411, Month 1 to 12, Day 1 to 31" });

        //    PersianCalendar persianCalendar = new PersianCalendar();
        //    DateTime firstMiadiParse = new DateTime(command.FirstPersianDate.Year, command.FirstPersianDate.Month, command.FirstPersianDate.Day, persianCalendar);
        //    DateTime secondMiladiParse = new DateTime(command.SecondPersianDate.Year, command.SecondPersianDate.Month, command.SecondPersianDate.Day, persianCalendar);
        //    var result = await _ticketService.SearchReservedTicketsPriceByDateSum(firstMiadiParse, secondMiladiParse);
        //    if (result == 0)
        //        return OkResult(ApiMessage.NotHaveActiveTicketsAtThisTime, new { ReservedTicketsPriceSum = result });
        //    return OkResult(ApiMessage.ActiveTicketsPriceDateSumGetted, new { ReservedTicketsPriceSum = result });
        //}

        //        /// <summary>
        //        /// جست و جوی بلیط غیرفعال با یک تاریخ
        //        /// </summary>
        //        [HttpGet("SearchInActivedByDate-oneDate")]
        //        public async Task<IActionResult> SearchInActiveTicketsByOneDate(OneDateSearchCommand command)
        //        {
        //            if (!command.PersianDate.Validate())
        //                return BadReq(ApiMessage.WrongDate, new { Reason = $"Year between 1368 and 1411, Month 1 to 12, Day 1 to 31" });

        //            PersianCalendar persianCalendar = new PersianCalendar();
        //            DateTime firstMiadiParse = new DateTime(command.PersianDate.Year, command.PersianDate.Month, command.PersianDate.Day, persianCalendar);
        //            var result = await _ticketService.SearchInActivedTicketsByDate(firstMiadiParse);
        //            if (result == null)
        //                return OkResult(ApiMessage.NotHaveInActiveTicketsAtThisTime, new { InActiveTicketsCount = $"0 - any reserved ticket not found in this time" });
        //            return OkResult(ApiMessage.TicketInActivedSearchedDateCountGetted, new { InActiveTicketsFounded = result });
        //        }

        //        /// <summary>
        //        /// جست و جوی تعداد بلیط غیرفعال با یک تاریخ
        //        /// </summary>
        //        [HttpGet("SearchInActivedByDate-oneDate-Count")]
        //        public async Task<IActionResult> SearchInActiveTicketsByOneDateCount(OneDateSearchCommand command)
        //        {
        //            if (!command.PersianDate.Validate())
        //                return BadReq(ApiMessage.WrongDate, new { Reason = $"Year between 1368 and 1411, Month 1 to 12, Day 1 to 31" });

        //            PersianCalendar persianCalendar = new PersianCalendar();
        //            DateTime firstMiadiParse = new DateTime(command.PersianDate.Year, command.PersianDate.Month, command.PersianDate.Day, persianCalendar);
        //            var result = await _ticketService.SearchInActivedTicketsByDate(firstMiadiParse);
        //            if (result == null)
        //                return OkResult(ApiMessage.NotHaveInActiveTicketsAtThisTime, new { InActiveTicketsCount = $"0 - any inActive ticket not found in this time" });
        //            return OkResult(ApiMessage.TicketInActivedSearchedDateCountGetted, new { InActiveTicketsFoundedCount = result.Count });
        //        }

        //        /// <summary>
        //        /// جست و جوی تعداد بلیط غیرفعال با دو تاریخ
        //        /// </summary>
        //        [HttpGet("SearchInActivedByDate-twoDate")]
        //        public async Task<IActionResult> SearchInActiveTicketsByTwoDate(TwoDateSearchCommand command)
        //        {
        //            if (!command.FirstPersianDate.Validate() || !command.SecondPersianDate.Validate())
        //                return BadReq(ApiMessage.WrongDate, new { Reason = $"Year between 1368 and 1411, Month 1 to 12, Day 1 to 31" });

        //            PersianCalendar persianCalendar = new PersianCalendar();
        //            DateTime firstMiadiParse = new DateTime(command.FirstPersianDate.Year, command.FirstPersianDate.Month, command.FirstPersianDate.Day, persianCalendar);
        //            DateTime secondMiladiParse = new DateTime(command.SecondPersianDate.Year, command.SecondPersianDate.Month, command.SecondPersianDate.Day, persianCalendar);
        //            var result = await _ticketService.SearchInActivedTicketsByDate(firstMiadiParse, secondMiladiParse);
        //            if (result == null)
        //                return OkResult(ApiMessage.NotHaveInActiveTicketsAtThisTime, new { InActiveTicketsCount = $"0 - any inActive ticket not found in this time" });
        //            return OkResult(ApiMessage.TicketInActivedSearchedDateCountGetted, new { InActiveTickets = result });
        //        }

        //        /// <summary>
        //        /// جست و جوی تعداد بلیط غیرفعال با دو تاریخ
        //        /// </summary>
        //        [HttpGet("SearchInActivedByDate-twoDate-Count")]
        //        public async Task<IActionResult> SearchInActiveTicketsByTwoDateCount(TwoDateSearchCommand command)
        //        {
        //            if (!command.FirstPersianDate.Validate() || !command.SecondPersianDate.Validate())
        //                return BadReq(ApiMessage.WrongDate, new { Reason = $"Year between 1368 and 1411, Month 1 to 12, Day 1 to 31" });

        //            PersianCalendar persianCalendar = new PersianCalendar();
        //            DateTime firstMiadiParse = new DateTime(command.FirstPersianDate.Year, command.FirstPersianDate.Month, command.FirstPersianDate.Day, persianCalendar);
        //            DateTime secondMiladiParse = new DateTime(command.SecondPersianDate.Year, command.SecondPersianDate.Month, command.SecondPersianDate.Day, persianCalendar);
        //            var result = await _ticketService.SearchInActivedTicketsByDate(firstMiadiParse, secondMiladiParse);
        //            if (result == null)
        //                return OkResult(ApiMessage.NotHaveInActiveTicketsAtThisTime, new { InActiveTicketsCount = $"0 - any inActive ticket not found in this time" });
        //            return OkResult(ApiMessage.TicketInActivedSearchedDateCountGetted, new { InActiveTicketsCount = result.Count });
        //        }

        //        /// <summary>
        //        /// جست و جوی تعداد بلیط لغو شده با یک تاریخ
        //        /// </summary>
        //        [HttpGet("SearchCanceledByDate-oneDate")]
        //        public async Task<IActionResult> SearchCanceledTicketsByOneDate(OneDateSearchCommand command)
        //        {
        //            if (!command.PersianDate.Validate())
        //                return BadReq(ApiMessage.WrongDate, new { Reason = $"Year between 1368 and 1411, Month 1 to 12, Day 1 to 31" });

        //            PersianCalendar persianCalendar = new PersianCalendar();
        //            DateTime firstMiadiParse = new DateTime(command.PersianDate.Year, command.PersianDate.Month, command.PersianDate.Day, persianCalendar);
        //            var result = await _ticketService.SearchCanceledTicketsByDate(firstMiadiParse);
        //            if (result == null)
        //                return OkResult(ApiMessage.NotHaveCanceledTicketsAtThisTime, new { CanceledTicketsCount = $"0 - any Canceled ticket not found in this time" });
        //            return OkResult(ApiMessage.TicketCanceledSearchedDateCountGetted, new { CanceledTicketsFounded = result });
        //        }

        //        /// <summary>
        //        /// جست و جوی تعداد بلیط لغو شده با یک تاریخ
        //        /// </summary>
        //        [HttpGet("SearchCanceledByDate-oneDate-Count")]
        //        public async Task<IActionResult> SearchCanceledTicketsByOneDateCount(OneDateSearchCommand command)
        //        {
        //            if (!command.PersianDate.Validate())
        //                return BadReq(ApiMessage.WrongDate, new { Reason = $"Year between 1368 and 1411, Month 1 to 12, Day 1 to 31" });

        //            PersianCalendar persianCalendar = new PersianCalendar();
        //            DateTime firstMiadiParse = new DateTime(command.PersianDate.Year, command.PersianDate.Month, command.PersianDate.Day, persianCalendar);
        //            var result = await _ticketService.SearchCanceledTicketsByDate(firstMiadiParse);
        //            if (result == null)
        //                return OkResult(ApiMessage.NotHaveCanceledTicketsAtThisTime, new { CanceledTicketsCount = $"0 - any Canceled ticket not found in this time" });
        //            return OkResult(ApiMessage.TicketCanceledSearchedDateCountGetted, new { CanceledTicketsFoundedCount = result.Count });
        //        }

        //        /// <summary>
        //        /// جست و جوی تعداد بلیط لغو شده با دو تاریخ
        //        /// </summary>
        //        [HttpGet("SearchCanceledByDate-twoDate")]
        //        public async Task<IActionResult> SearchCanceledTicketsByTwoDate(TwoDateSearchCommand command)
        //        {
        //            if (!command.FirstPersianDate.Validate() || !command.SecondPersianDate.Validate())
        //                return BadReq(ApiMessage.WrongDate, new { Reason = $"Year between 1368 and 1411, Month 1 to 12, Day 1 to 31" });

        //            PersianCalendar persianCalendar = new PersianCalendar();
        //            DateTime firstMiadiParse = new DateTime(command.FirstPersianDate.Year, command.FirstPersianDate.Month, command.FirstPersianDate.Day, persianCalendar);
        //            DateTime secondMiladiParse = new DateTime(command.SecondPersianDate.Year, command.SecondPersianDate.Month, command.SecondPersianDate.Day, persianCalendar);
        //            var result = await _ticketService.SearchCanceledTicketsByDate(firstMiadiParse, secondMiladiParse);
        //            if (result == null)
        //                return OkResult(ApiMessage.NotHaveCanceledTicketsAtThisTime, new { CanceledTicketsCount = $"0 - any Canceled ticket not found in this time" });
        //            return OkResult(ApiMessage.TicketCanceledSearchedDateCountGetted, new { CanceledTickets = result });
        //        }

        //        /// <summary>
        //        /// جست و جوی تعداد بلیط لغو شده با دو تاریخ
        //        /// </summary>
        //        [HttpGet("SearchCanceledByDate-twoDate-Count")]
        //        public async Task<IActionResult> SearchCanceledTicketsByTwoDateCount(TwoDateSearchCommand command)
        //        {
        //            if (!command.FirstPersianDate.Validate() || !command.SecondPersianDate.Validate())
        //                return BadReq(ApiMessage.WrongDate, new { Reason = $"Year between 1368 and 1411, Month 1 to 12, Day 1 to 31" });

        //            PersianCalendar persianCalendar = new PersianCalendar();
        //            DateTime firstMiadiParse = new DateTime(command.FirstPersianDate.Year, command.FirstPersianDate.Month, command.FirstPersianDate.Day, persianCalendar);
        //            DateTime secondMiladiParse = new DateTime(command.SecondPersianDate.Year, command.SecondPersianDate.Month, command.SecondPersianDate.Day, persianCalendar);
        //            var result = await _ticketService.SearchCanceledTicketsByDate(firstMiadiParse, secondMiladiParse);
        //            if (result == null)
        //                return OkResult(ApiMessage.NotHaveCanceledTicketsAtThisTime, new { CanceledTicketsCount = $"0 - any Canceled ticket not found in this time" });
        //            return OkResult(ApiMessage.TicketCanceledSearchedDateCountGetted, new { CanceledTicketsCount = result.Count });
        //        }
        //        // badan mitunim price-sum ro bara inActive o cancela ezaf konim
        //        #endregion

        //        #region Specials

        //        /// <summary>
        //        /// تغییر وضعیت بلیط های انجام شده به بازی شده
        //        /// </summary>
        //        [HttpPut("SetPerformedTicketsTo-Played")] 
        //        public async Task<IActionResult> SetPerformedTicketsToPlayed()
        //        {
        //            var result = await _ticketService.SetPerformedTicketsToPlayed();
        //            if (result == 0)
        //                return BadReq(ApiMessage.AnyTicketForChangingNotFound, new {Reasons = $"any reserved and expired tickets for changing not found"});
        //            if (result == 503)
        //                return BadReq(ApiMessage.ServiceUnAvailable, new { Reason = $"service unAvailable" });
        //            return OkResult(ApiMessage.PerformedTicketChangedToPlayed, new { TicketsChangingCount = result });
        //        }
        //        #endregion

        ///// <summary>
        ///// اضافه کردن بلیط خریده شده در سایت - به سبد خرید
        ///// </summary>
        //[HttpPost("{id}/AddTicketBasket")]
        //public async Task<IActionResult> AddTicketForBasket(AddTicketToBasketCommand command)
        //{
        //    if (!command.Validate())
        //        return BadReq(ApiMessage.WrongID, new { Reason = $"you must enter at least 1 id" });
        //    var result = await _ticketService.DeleteTicketsFromBasketBuy(command);
        //    if (result != null)
        //        return BadReq(ApiMessage.AllInActiveTicketsDeletedFaild, new { NotDeletedTickets = result });
        //    return OkResult(ApiMessage.AllInActiveTicketsDeletedSuccessfully, new { DeletedTicketCount = command.IDs.Count });
        //}

        //        /// <summary>
        //        /// اضافه کردن بلیط خریده شده بصورت حضوری
        //        /// </summary>
        //        [HttpPost("Add-Ticket-Presence/{id}")] //schedule id
        //        public async Task<IActionResult> AddTicketFromPresence(Guid id, AddTicketFromPresenceCommand command)
        //        {
        //            command.ScheduleId = id;
        //            if (!command.Validate())
        //                return BadReq(ApiMessage.EnterNumOfTicket, new { Reasons = $"1-enter schedule id, 2-enter user cellphone, 3-number of ticket must at least 1 and max 10" });

        //            var result = await _ticketService.AddTicketFromPresence(command);
        //            if (result == null)
        //                return BadReq(ApiMessage.TicketNotBuys, new { Reasons = $"1-number of ticket greater than schedule available ticket, 2-schedule is not active, 3-user is blocked, 4-user id is wrong, 5-schedule id is wrong" });
        //            return OkResult(ApiMessage.TicketBuyed, new { TicketInfo = result });
        //        }

        //        /// <summary>
        //        /// ثبت خرید و فعال کردن(رزرو) بلیط
        //        /// </summary>
        //        [HttpPut("EntryBuy/{id}")] // kharid sabt mishe o az capacity kam mishe
        //        public async Task<IActionResult> EntryBuyTicket(Guid id)
        //        {
        //            var result = await _ticketService.EntryBuyTicket(id);
        //            if (result == null)
        //                return BadReq(ApiMessage.TicketNotReserved, new { Reasons = $"1-number of tickets greather than schedule available capacity," +
        //                    $"2-schedule is not active, 3-ticket is not in BasketBuy(isn't inActive) , 4-ticket not found" });
        //            return OkResult(ApiMessage.TicketReserved, new { TicketInfo = result });
        //        }

        //        /// <summary>
        //        /// لغو بلیط
        //        /// </summary>
        //        [HttpPut("Cancel/{id}")]
        //        public async Task<IActionResult> CancelTicket(Guid id)
        //        {
        //            var result = await _ticketService.CancelTicket(id);
        //            if (result == null)
        //                return BadReq(ApiMessage.TicketNotCanceled, new { Reasons = $"1-ticket not reserved, 2-there is a problem when saveChange ticket. TryAgain!" });
        //            return OkResult(ApiMessage.TicketCanceled, new { ScheduleAvailableCapacity = result.Value });
        //        }

        /// <summary>
        /// عوض کزدن وضعیت یک بلیط
        /// </summary>
        [HttpPut("{id}/ChangeCondition")]
        public async Task<IActionResult> ChangeTicketCondition(Guid id, EditTicketConditionCommand command)
        {
            command.TicketId = id;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongTicketID, new { Reason = $"1-enter ticketID, 2-ChangeCondition must in = 1: inactive, 2: active, 3: canceled" });

            var result = await _ticketService.ChangeTicketCondition(command);
            if (result == null)
                return BadReq(ApiMessage.TicketNotChangedCondition, new { Reason = $"ticket not found" });
            return OkResult(ApiMessage.TicketChangedCondition, new { TicketCondition = $"{result} 1: inactive, 2: active, 3: canceled" });
        }

        /// <summary>
        /// گرفتن یک بلیط
        /// </summary>
        [HttpGet("{id}/GetOne")]
        public async Task<IActionResult> GetOneTicket(Guid id)
        {
            var result = await _ticketService.GetOneTicket(id);
            if (result == null)
                return BadReq(ApiMessage.TicketNotGetted, new { Reason = $"ticket not found, check the id and TryAgain!" });
            return OkResult(ApiMessage.TicketGetted, new { TicketInfo = result });
        }

        /// <summary>
        /// پاک کردن بلیط - از سبد خرید
        /// </summary>
        [HttpDelete("{id}/Delete")]
        public async Task<IActionResult> DeleteTicket(Guid id)
        {
            var result = await _ticketService.DeleteTicket(id);
            if (result)
                return OkResult(ApiMessage.TicketDeleted, new { IsDeleted = result });
            return BadReq(ApiMessage.TicketNotDeleted, new { Reason = $"1-ticket not found, check the id, 2-ticket isn't inActive" });
        }



        //        /// <summary>
        //        /// لغو یا برگردوندن سانس و دریافت بلیط های رزرو شده
        //        /// </summary>

        //        //add: all tickets count between two date time or in one datetime hame javaba tu hmin ( cancel, inactive, reserved)
        //        //add sell total price eFun
        //        //add sell total to user

        //        /// <summary>
        //        /// چک کردن درست عملکردن وضعیت فضای یک سانس - delete it from postman ck
        //        /// </summary>
        //        //[HttpGet("CheckProperlyPerformance-Schedule/{id}")] // scheduleId ( schedules model )
        //        //public async Task<IActionResult> CheckProperlyPerformanceSchedule(Guid id)
        //        //{
        //        //    var result = await _ticketService.CheckProperlyPerformanceSchedule(id);
        //        //    return OkResult(ApiMessage.Ok, new { ProperlyPerformance = result });
        //        //}

    }
}

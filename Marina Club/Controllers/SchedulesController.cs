using Microsoft.AspNetCore.Mvc;
using Marina_Club.Services.interfaces;
using System.Threading.Tasks;
using Marina_Club.Commands.Schedule;
using System;
using System.Globalization;
using Marina_Club.Commands;

namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ApiController
    {
        private readonly IScheduleService _scheduleService;
        public SchedulesController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        /// <summary>
        /// ساختن سانس
        /// </summary>
        [HttpPost("Create/{id}")] // fun id
        public async Task<IActionResult> CreateSchedule(Guid id, AddScheduleCommand command)
        {
            command.FunId = id;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reasons = $"1-wrong Id, 2-days number can't be null or equal to 0" });

            var result = await _scheduleService.CreateSchedule(command);
            if (result == null)
                return BadReq(ApiMessage.InvalidFunId);
            return OkResult(ApiMessage.SchedulesCreated, new { CreatedSchedules = result });
        }

        /// <summary>
        /// گرفتن همه سانس ها برای یک تفریح
        /// </summary>
        [HttpGet("All-Fun-Schedules/{id}")]
        public async Task<IActionResult> GetAllSchedulesForFun(Guid id)// fun id
        {
            var result = await _scheduleService.GetAllSchedulesForFun(id);
            if (result == null)
                return BadReq(ApiMessage.SchedulesNotExist, new { Reason = $"1-no schedule in this fun, 2-wrong fun id" });
            return OkResult(ApiMessage.GetAllScheduleForFun, new { AllFunSchedules = result });
        }

        /// <summary>
        /// گرفتن تعداد همه سانس ها برای یک تفریح
        /// </summary>
        [HttpGet("All-Fun-Schedules-Count/{id}")]
        public async Task<IActionResult> GetAllSchedulesForFunCount(Guid id)// fun id
        {
            var result = await _scheduleService.GetAllSchedulesForFun(id);
            if (result == null)
                return BadReq(ApiMessage.SchedulesNotExist, new { Reason = $"1-no schedule in this fun, 2-fun not found" });
            return OkResult(ApiMessage.GetAllScheduleForFun, new { AllFunSchedulesCount = result.Count });
        }

        /// <summary>
        /// لغو یا برگردوندن سانس
        /// </summary>
        [HttpPut("CancelOrReExist/{id}")]
        public async Task<IActionResult> CancelOrReExistSchedule(Guid id, CancelOrReExistScheduleCommand command)
        {
            command.ScheduleId = id;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reasons = $"1-wrong id, 2-IsExist can't be null" });

            var result = await _scheduleService.CancelOrReExistSchedule(command);
            if (!result)
                return OkResult(ApiMessage.CancelSchedule, new { IsScheduleExist = result });
            return OkResult(ApiMessage.ReExistSchedule, new { IsScheduleExist = result });
        }

        /// <summary>
        /// لغو یا برگردوندن سانس ها
        /// </summary>
        [HttpPut("ListCORE")]
        public async Task<IActionResult> ScheduleListCORE(ScheduleListCORECommand command)
        {
            if (!command.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reasons = $"1-IsExist can't be null, 2-IDs must have least 1 Id" });

            var result = await _scheduleService.ScheduleListCORE(command);
            if (!result)
                return OkResult(ApiMessage.CancelSchedules, new { IsCancel = result });
            return OkResult(ApiMessage.ReExistSchedules, new { IsReExist = result });
        }

        /// <summary>
        /// دریافت یک سانس با آیدی
        /// </summary>
        [HttpGet("GetOne/{id}")]
        public async Task<IActionResult> GetOneSchedule(Guid id)
        {
            var result = await _scheduleService.GetOneSchedule(id);
            if (result == null)
                return BadReq(ApiMessage.SchedulesNotExist, new { Reasons = $"schedule not found" });
            return OkResult(ApiMessage.ScheduleFound, new { ScheduleInfo = result });
        }

        #region DiscountPriceOptions

        /// <summary>
        /// تخفیف قیمت سانس ها با درصد تخفیف
        /// </summary>
        [HttpPut("ListDiscountPercent")]
        public async Task<IActionResult> DiscountPercentListSchedules(DiscountPercentListSchedulesCommand command)
        {
            if (!command.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reasons = $"1-you must enter least 1 scheduleID, 2-Discount percent must between 0 and 100" });

            var result = await _scheduleService.DiscountPercentListSchedules(command);
            if (result == null)
                return BadReq(ApiMessage.AnyScheduleForDiscountNotFound, new { Reasons = $"1-any schedule not found, 2-there is a problem when saveChanges. TryAgain!" });
            return OkResult(ApiMessage.ListDiscountPricePercent, new { ChangedSchedules = result });
        }

        /// <summary>
        /// تخفیف قیمت سانس ها با قیمت تخفیف
        /// </summary>
        [HttpPut("ListDiscountPrice")]
        public async Task<IActionResult> DiscountPriceListSchedules(DiscountPriceListSchedulesCommand command)
        {
            if (!command.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reasons = $"1-you must enter least 1 scheduleID, 2-Discount price must between 1.00 and 9999.99" });

            var result = await _scheduleService.DiscountPriceListSchedules(command);
            if (result == null)
                return BadReq(ApiMessage.AnyScheduleForDiscountNotFound, new { Reasons = $"1-any schedule not found, 2-there is a problem when saveChanges. TryAgain!" });
            return OkResult(ApiMessage.ListDiscountPrice, new { ChangedSchedules = result });
        }

        /// <summary>
        /// تخفیف قیمت تمام سانس های یک تفریح با درصد تخفیف
        /// </summary>
        [HttpPut("DiscountPercentFun/{id}")] // fun id
        public async Task<IActionResult> DiscountPercentAllFunSchedules(Guid id, DiscountPercentAllFunSchedulesCommand command)
        {
            command.FunId = id;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reasons = $"1-pls enter fun id, 2-Discount percent must between 0 and 100" });

            var result = await _scheduleService.DiscountPercentAllFunSchedules(command);
            if (result == null)
                return BadReq(ApiMessage.InvalidFunId, new { Reason = $"1-fun not found, 2-fun not have any schedule, 3-there is a problem when saveChanges. TryAgain!" });
            return OkResult(ApiMessage.ListDiscountPricePercent, new { ChangedSchedules = result });
        }

        /// <summary>
        /// تخفیف قیمت تمام سانس های یک تفریح با قیمت تخفیف
        /// </summary>
        [HttpPut("DiscountPriceFun/{id}")] //fun id 
        public async Task<IActionResult> DiscountPriceAllFunSchedules(Guid id, DiscountPriceAllFunSchedulesCommand command)
        {
            command.FunId = id;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reasons = $"1-pls enter fun id, 2-Discount price must between 1.00 and 9999.99" });

            var result = await _scheduleService.DiscountPriceAllFunSchedules(command);
            if (result == null)
                return BadReq(ApiMessage.InvalidFunId, new { Reason = $"1-fun not found, 2-fun not have any schedule, 3-there is a problem when saveChanges. TryAgain!" });
            return OkResult(ApiMessage.ListDiscountPrice, new { ChangedSchedules = result });
        }

        #endregion

        #region IncreasePriceOptions

        /// <summary>
        /// افزایش درصد قیمت لیست سانس ها
        /// </summary>
        [HttpPut("ListIncreasePricePercent")]
        public async Task<IActionResult> IncreaseListSchedulePricePercent(IncreaseListSchedulePricePercentCommand command)
        {
            if (!command.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reason = $"1-you must enter least 1 scheduleID, 2-IncreasePrice percent must between 0 and 200" });

            var result = await _scheduleService.IncreaseListSchedulePricePercent(command);
            if (result == null)
                return BadReq(ApiMessage.AnyScheduleForIncreaseNotFound, new { Reasons = $"1-any schedule not found, 2-there is a problem when saveChanges. TryAgain!" });
            return OkResult(ApiMessage.ListIncreasePricePercent, new { ChangedSchedules = result });
        }

        /// <summary>
        /// افزایش درصد قیمت کل سانس های یک تفریح
        /// </summary>
        [HttpPut("IncreaseFunPricePercent/{id}")] //fun id
        public async Task<IActionResult> IncreaseFunSchedulesPricePercent(Guid id, IncreaseFunSchedulesPricePercentCommand command)
        {
            command.FunId = id;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reason = $"1-pls enter funID, 2-IncreasePrice percent must between 0 and 200" });

            var result = await _scheduleService.IncreaseFunSchedulesPricePercent(command);
            if (result == null)
                return BadReq(ApiMessage.InvalidFunId, new { Reason = $"1-fun not found, 2-fun not have any schedule, 3-there is a problem when saveChanges. TryAgain!"});
            return OkResult(ApiMessage.FunIncreasePricePercent, new { ChangedSchedules = result });
        }

        /// <summary>
        /// افزایش قیمت کل سانس های یک تفریح
        /// </summary>
        [HttpPut("IncreaseFunPrice/{id}")] //fun id
        public async Task<IActionResult> IncreaseFunSchedulesPrice(Guid id, IncreaseFunSchedulesPriceCommand command)
        {
            command.FunId = id;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reasons = $"1-pls enter funID, 2-Increase price must between 1.00 and 9999.99" });

            var result = await _scheduleService.IncreaseFunSchedulesPrice(command);
            if (result == null)
                return BadReq(ApiMessage.InvalidFunId, new { Reason = $"1-fun not found, 2-fun not have any schedule, 3-there is a problem when saveChanges. TryAgain!" });
            return OkResult(ApiMessage.FunIncreasePrice, new { ChangedSchedules = result });
        }

        #endregion

        #region Search Options

        /// <summary>
        /// گرفتن همه سانس ها برای یک تفریح - با تاریخ
        /// </summary>
        [HttpGet("All-Fun-Schedules-Search/{id}")] // fun id
        public async Task<IActionResult> SearchInAllSchedulesForFun(Guid id, OneDateSearchCommand command)
        {
            if (!command.PersianDate.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reasons = $"1-Year must between or equal 1368 and 1410, 2-month must between or equal 1 and 12, 3-day must between or equal 1 and 31"});

            PersianCalendar excutePersian = new PersianCalendar();
            DateTime miladiParse = new DateTime(command.PersianDate.Year, command.PersianDate.Month, command.PersianDate.Day, excutePersian);

            var result = await _scheduleService.GetAllSchedulesForFun(id, miladiParse);

            if (result == null)
                return BadReq(ApiMessage.NoScheduleAtThisTime, new { Reason = $"1-no schedule in this date time, 2-wrong fun id" });
            return OkResult(ApiMessage.GetAllScheduleForFun, new { AllFoundedFunSchedules = result });
        }

        /// <summary>
        /// جست و جوی سانس ها با یک تاریخ - جست و جو بصورت شمسی
        /// </summary>
        [HttpGet("SearchByDate-oneDate")]
        public async Task<IActionResult> SearchScheduleByOneDate(OneDateSearchCommand command)
        {
            if (!command.PersianDate.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reasons = $"1-Year must between or equal 1368 and 1410, 2-month must between or equal 1 and 12, 3-day must between or equal 1 and 31" });

            PersianCalendar excutePersian = new PersianCalendar();
            DateTime miladiParse = new DateTime(command.PersianDate.Year, command.PersianDate.Month, command.PersianDate.Day, excutePersian);

            var result = await _scheduleService.SearchScheduleByDate(miladiParse);
            if (result == null)
                return BadReq(ApiMessage.NoScheduleAtThisTime);
            return OkResult(ApiMessage.ScheduleFound, new { FoundedSchedules = result });
        }

        /// <summary>
        /// جست و جوی سانس ها با تاریخ بین دو تاریخ - جست و جو بصورت شمسی
        /// </summary>
        [HttpGet("SearchByDate-twoDate")]
        public async Task<IActionResult> SearchScheduleByTwoDate(TwoDateSearchCommand command) // edited
        {
            if (!command.FirstPersianDate.Validate() || !command.SecondPersianDate.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reasons = $"1-Year must between or equal 1368 and 1410, 2-month must between or equal 1 and 12, 3-day must between or equal 1 and 31" });

            PersianCalendar persianInput = new PersianCalendar();
            DateTime miladiFirstInputParse = new DateTime(command.FirstPersianDate.Year, command.FirstPersianDate.Month, command.FirstPersianDate.Day, persianInput);
            DateTime miladiSecondInputParse = new DateTime(command.SecondPersianDate.Year, command.SecondPersianDate.Month, command.SecondPersianDate.Day, persianInput);

            var result = await _scheduleService.SearchScheduleByDate(miladiFirstInputParse, miladiSecondInputParse);
            if (result == null)
                return BadReq(ApiMessage.NoScheduleAtThisTime);
            return OkResult(ApiMessage.ScheduleFound, new { FoundedSchedules = result });
        }

        /// <summary>
        /// گرفتن تعداد همه سانس ها برای یک تفریح - با تاریخ
        /// </summary>
        [HttpGet("All-Fun-Schedules-Search-Count/{id}")] // fun id
        public async Task<IActionResult> SearchInAllSchedulesForFunCount(Guid id, OneDateSearchCommand command)
        {
            if (!command.PersianDate.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reasons = $"1-Year must between or equal 1368 and 1410, 2-month must between or equal 1 and 12, 3-day must between or equal 1 and 31" });

            PersianCalendar excutePersian = new PersianCalendar();
            DateTime miladiParse = new DateTime(command.PersianDate.Year, command.PersianDate.Month, command.PersianDate.Day, excutePersian);
            var result = await _scheduleService.GetAllSchedulesForFun(id, miladiParse);

            if (result == null)
                return BadReq(ApiMessage.NoScheduleAtThisTime, new { Reason = $"1-no schedule in this date time, 2-wrong fun id" });
            return OkResult(ApiMessage.GetAllScheduleForFunAtThisTime, new { AllFoundedFunSchedulesCount = result.Count });
        }

        /// <summary>
        /// جست و جو و دریافت تعداد سانس ها با یک تاریخ - جست و جو بصورت شمسی
        /// </summary>
        [HttpGet("SearchByDate-oneDate-Count")]
        public async Task<IActionResult> SearchScheduleByOneDateCount(OneDateSearchCommand command)
        {
            if (!command.PersianDate.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reasons = $"1-Year must between or equal 1368 and 1410, 2-month must between or equal 1 and 12, 3-day must between or equal 1 and 31" });

            PersianCalendar excutePersian = new PersianCalendar();
            DateTime miladiParse = new DateTime(command.PersianDate.Year, command.PersianDate.Month, command.PersianDate.Day, excutePersian);
            var result = await _scheduleService.SearchScheduleByDate(miladiParse);
            if (result == null)
                return BadReq(ApiMessage.NoScheduleAtThisTime);
            return OkResult(ApiMessage.ScheduleFound, new { FoundedSchedulesCount = result.Count });
        }

        /// <summary>
        /// جست و جو و دریافت تعداد سانس ها با تاریخ بین دو تاریخ - جست و جو بصورت شمسی
        /// </summary>
        [HttpGet("SearchByDate-twoDate-Count")]
        public async Task<IActionResult> SearchScheduleByTwoDateCount(TwoDateSearchCommand command) // edited
        {
            if (!command.FirstPersianDate.Validate() || !command.SecondPersianDate.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reasons = $"1-Year must between or equal 1368 and 1410, 2-month must between or equal 1 and 12, 3-day must between or equal 1 and 31" });

            PersianCalendar persianInput = new PersianCalendar();
            DateTime miladiFirstInputParse = new DateTime(command.FirstPersianDate.Year, command.FirstPersianDate.Month, command.FirstPersianDate.Day, persianInput);
            DateTime miladiSecondInputParse = new DateTime(command.SecondPersianDate.Year, command.SecondPersianDate.Month, command.SecondPersianDate.Day, persianInput);

            var result = await _scheduleService.SearchScheduleByDate(miladiFirstInputParse, miladiSecondInputParse);
            if (result == null)
                return BadReq(ApiMessage.NoScheduleAtThisTime);
            return OkResult(ApiMessage.ScheduleFound, new { FoundedSchedulesCount = result.Count });
        }
        #endregion

        #region Specials

        /// <summary>
        /// غیرفعال کردن همه سانس های تاریخ گذشته
        /// </summary>
        [HttpPut("DisActiveAllExpired")]
        public async Task<IActionResult> DisActiveAllExpiredSchedules()
        {
            var result = await _scheduleService.DisActiveAllExpiredSchedules();
            if (result == null)
                return BadReq(ApiMessage.NotHaveAnyExpiredActiveScheduleYet, new { ExpiredActiveSchedulesCount = $"1-any active expired schedule not found, 2-there is a problem when save changes. TryAgain!" });
            return OkResult(ApiMessage.ExpiredActiveSchedulesDisActived, new { DisActivedSchedulesCount = result.Count });
        }

        /// <summary>
        /// اضافه کردن ظرفیت سانس
        /// </summary>
        [HttpPut("IncreaseCapacity/{id}")]
        public async Task<IActionResult> IncreaseScheduleCapacity(Guid id, CapacityCommand command)
        {
            command.ScheduleId = id;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reasons = $"1-enter scheduleID, 2-capacity must between 0 and 51" });

            var result = await _scheduleService.IncreaseScheduleCapacity(command);
            if (result == 404)
                return BadReq(ApiMessage.SchedulesNotExist, new { Reasons = $"1-schedule is expired, 2-schedule not found, 3-there is a problem when saveChanges. TryAgain!" });
            return OkResult(ApiMessage.ExpiredActiveSchedulesDisActived, new { ScheduleAvailableCapacity = result });
        }

        /// <summary>
        /// کم کردن ظرفیت سانس
        /// </summary>
        [HttpPut("ReduceCapacity/{id}")]
        public async Task<IActionResult> ReduceScheduleCapacity(Guid id, CapacityCommand command)
        {
            command.ScheduleId = id;
            if (!command.Validate())
                return BadReq(ApiMessage.WrongInformation, new { Reasons = $"1-enter scheduleID, 2-capacity must between 0 and 51" });

            var result = await _scheduleService.ReduceScheduleCapacity(command);
            if (result == 404)
                return BadReq(ApiMessage.SchedulesNotExist, new { Reasons = $"1-schedule is expired, 2-schedule not found, 3-there is a problem when saveChanges. TryAgain!" });
            return OkResult(ApiMessage.ExpiredActiveSchedulesDisActived, new { ScheduleAvailableCapacity = result });
        }
        #endregion
    }
}

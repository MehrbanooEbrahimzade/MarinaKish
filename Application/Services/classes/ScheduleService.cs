using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Commands.Schedule;
using Application.Dtos;
using Application.Exceptions;
using Application.Mappers;
using Application.Services.interfaces;
using Domain.IConfiguration;
using Domain.RepasitoryInterfaces;
using Infrastructure.Extensions;
using Microsoft.Extensions.Logging;

namespace Application.Services.classes
{
    public class ScheduleService : IScheduleService
    {

        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork; //ghablan repository model mad nazaro inject mikardim 
        public ScheduleService(ILogger logger, IUnitOfWork unitOfWork)
        {
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }

        public async Task AddSpecialOffer(AddSpecialOfferCommand command)
        {
            var searchnameRecreation = await _unitOfWork.Schedules.GetByIdAsync(command.ShceduleId);
            if (searchnameRecreation == null)
                throw new Exception("چنین سانسی وجود ندرد");


            decimal DiscountNumber = command.AddPercent.Value;
            decimal Discount = DiscountNumber / 100;
            decimal resultAmount = searchnameRecreation.Price;
            command.Price = Discount * resultAmount;

            //command.Price -= (command.AddPercent.Value * searchnameRecreation.Price) / 100;

            var addDiscountamount = command.AddPercent.ToModel();

            searchnameRecreation.UpdateSpecialOffer(command.Price, addDiscountamount);
            await _unitOfWork.CompleteAsync();

        }
        public async Task UpdateSpecialOff(UpdateSpecialFunCommand command)
        {
            var specialOffer = await _unitOfWork.Schedules.GetByIdAsync(command.ShceduleId);
            if (specialOffer is null)
            {
                throw new NotFoundExeption(nameof(UpdateSpecialFunCommand), command.ShceduleId, " schedule is ");
            }
            specialOffer.UpdateSpecialOffer(command.Price, command.AddPercent.ToModel());
            await _unitOfWork.CompleteAsync();
        }



        /// <summary>
        /// دریافت یک سانس با ایدی سانس
        /// </summary>
        public async Task<ScheduleDto> GetScheduleById(Guid id)
        {
            var Get = await _unitOfWork.Schedules.GetByIdAsync(id);
            if (Get == null)
                throw new Exception("چنین سانسی یافت نشد");

            return Get.ToDto();
        }

        /// <summary>
        ///  دریافت همه سانس با تاریخ
        /// </summary>
        public async Task<List<ScheduleDto>> GetAllSchedule(GetAllByDateTimeCommand command)
        {

            var GetAll = await _unitOfWork.Schedules.GetAllByDateAsync(command.FunId, command.DateTime);

            if (GetAll == null)
                throw new Exception("چنین سانسی هایی یافت نشد");

            return GetAll.ToDto();
        }


        /// <summary>
        /// دریافت همه سانس های یک تفریح
        /// </summary>
        public async Task<List<ScheduleDto>> GetSchedulesForFun(Guid funId)
        {
            var GetAll = await _unitOfWork.Schedules.GetSchedulesForFunAsync(funId);
            if (GetAll == null)
                throw new Exception("چنین سانسی یافت نشد");
            return GetAll.ToDto();
        }



        /// <summary>
        /// حذف لیستی از سانس 
        /// </summary>
        public async Task<bool> DeleteSchedule(DeleteListCommand command)
        {
            foreach (var item in command.IDs)
            {
                var result = await _unitOfWork.Schedules.DeleteAsync(item);
                if (result == false)
                    throw new Exception("چنین سانسی یافت نشد");
            }

            await _unitOfWork.CompleteAsync();
            return true;
        }


    }
}

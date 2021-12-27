using Application.Commands.ScheduleInfo;
using Application.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Marina_Club.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleInformationController : ControllerBase
    {
        private readonly IScheduleInfoService _scheduleInfoService;
        public ScheduleInformationController(IScheduleInfoService scheduleInfoService)
        {
            _scheduleInfoService = scheduleInfoService;
        }

        [HttpPost]
        public async Task AddScheduleInfoAsync(AddScheduleInfoCommand command)
        {
            var result = await _scheduleInfoService.AddScheduleInfoAsync(command);


        }


    }
}

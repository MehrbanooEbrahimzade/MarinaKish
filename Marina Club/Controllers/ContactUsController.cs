using System;
using System.Threading.Tasks;
using Application.Commands.ContactUs;
using Application.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ApiController
    {
        private readonly IContactUsService _contactUsService;
        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        /// <summary>
        /// اضافه کردن ContactUs
        /// </summary>
        [HttpPost("Add")]
        public async Task<IActionResult> AddContactUsAsync(AddContactUsCommand command)
        {
            if (!command.Validate())
            {
                return BadReq(ApiMessage.ContactUsWrongInformation,
                    new { Reason = $"Make a Problem When ContactUs Add. TryAgain!" });
            }
            _contactUsService.AddContactUsAsync(command);
            return OkResult(ApiMessage.ContactUsAdded);
        }

        /// <summary>
        /// دریافت ContactUs
        /// </summary>
        [HttpGet("{id}/Get")]
        public async Task<IActionResult> GetContactUsByIdAsync(Guid id)
        {
            var result = await _contactUsService.GetContactUsByIdAsync(id);

            return result is null ?
                 BadReq(ApiMessage.ContactUsNotExisted,
                    new { Reason = $"ContactUs Not Exist With This id . TryAgain!" })
                : OkResult(ApiMessage.ContactUsGet, result);
        }

        /// <summary>
        /// ویرایش قسمت درباره ما ContactUs
        /// </summary>
        [HttpPut("{id}/EditAboutMariana")]
        public async Task<IActionResult> UpdateContactUsAboutMarianaAsync
            (Guid id, UpdateContactUsAboutMarianaContactUsCommand command)
        {
            command.Id = id;
            if (!command.Validate())
            {
                return BadReq(ApiMessage.ContactUsWrongInformation, new
                { Reasons = $"1-Wrong ContactUsId, 2-Wrong Command Information" });
            }

            await _contactUsService.UpdateContactUsAboutMarianaAsync(command);
            return OkResult(ApiMessage.ContactUsAboutMarianaUpdated);
        }

        /// <summary>
        /// ویرایش قسمت قوانین ContactUs 
        /// </summary>
        [HttpPut("{id}/EditRules")]
        public async Task<IActionResult> UpdateContactUsRulesAsync
            (Guid id, UpdateContactUsRulesCommand command)
        {
            command.Id = id;
            if (!command.Validate())
            {
                return BadReq(ApiMessage.ContactUsWrongInformation, new
                    {Reason = $"1-Wrong ContactUsId, 2-Wrong Command Information"});
            }

            await _contactUsService.UpdateContactUsRulesAsync(command);
            return OkResult(ApiMessage.ContactUsRulesUpdated);
        }

        /// <summary>
        /// ویرایش ایمیل ContactUs
        /// </summary>
        [HttpPut("{id}/EditEmail")]
        public async Task<IActionResult> UpdateContactEmailAsync(Guid id, UpdateContactUsEmailCommand command)
        {
            command.Id = id;
            if (!command.Validate())
            {
                return BadReq(ApiMessage.ContactUsWrongInformation, new
                    { Reason = $"1-Wrong ContactUsId, 2-Wrong Command Information" });
            }

            await _contactUsService.UpdateContactUsEmailAsync(command);
            return OkResult(ApiMessage.ContactUsEmailUpdated);
        }

        /// <summary>
        /// ویرایش شماره تلفن ContactUs
        /// </summary>
        [HttpPut("{id}/EditPhoneNumber")]
        public async Task<IActionResult> UpdateContactUsPhoneNumberAsync(Guid id, UpdateContactUsPhoneNumberCommand command)
        {
            command.Id = id;
            if (!command.Validate())
            {
                return BadReq(ApiMessage.ContactUsWrongInformation, new
                    { Reason = $"1-Wrong ContactUsId, 2-Wrong Command Information" });
            }

            await _contactUsService.UpdateContactUsPhoneNumberAsync(command);
            return OkResult(ApiMessage.ContactUsPhoneNumberUpdated);
        }

        /// <summary>
        /// ویرایش آدرس لینکدین ContactUs
        /// </summary>
        [HttpPut("{id}/EditUrlLinkedin")]
        public async Task<IActionResult> UpdateContactUsUrlLinkedinAsync(Guid id, UpdateContactUsUrlLinkedinCommand command)
        {
            command.Id = id;
            if (!command.Validate())
            {
                return BadReq(ApiMessage.ContactUsWrongInformation, new
                    { Reason = $"1-Wrong ContactUsId, 2-Wrong Command Information" });
            }

            await _contactUsService.UpdateContactUsUrlLinkedinAsync(command);
            return OkResult(ApiMessage.ContactUsUrlLinkedinUpdated);
        }

        /// <summary>
        /// ویرایش آدرس اینستگرام ContactUs
        /// </summary>
        [HttpPut("{id}/EditUrlInstagram")]
        public async Task<IActionResult> UpdateContactUsUrlInstagramAsync(Guid id, UpdateContactUsUrlInstagramCommand command)
        {
            command.Id = id;
            if (!command.Validate())
            {
                return BadReq(ApiMessage.ContactUsWrongInformation, new
                    { Reason = $"1-Wrong ContactUsId, 2-Wrong Command Information" });
            }

            await _contactUsService.UpdateContactUsUrlInstagramAsync(command);
            return OkResult(ApiMessage.ContactUsUrlInstagramUpdated);
        }
    }
}

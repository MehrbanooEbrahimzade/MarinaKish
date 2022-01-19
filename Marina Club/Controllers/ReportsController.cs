﻿using Application.Services.interfaces;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marina_Club.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ApiController
    {
        private readonly ITicketService _ticketService;
        public ReportsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }
        [HttpGet]
        public async Task<IActionResult> GetReportAsync([FromBody]ReportQuerySearch search)
        {
            var tickets = await _ticketService.GetReportByFunType(search);
            return OkResult(ApiMessage.Ok, tickets);
        }
        [HttpGet("Reports")]
        public async Task<IActionResult> GetPersentOfSales([FromBody] ReportQuerySearch search)
        {
            var tickets = await _ticketService.GetPercentOfSales(search);
            return OkResult(ApiMessage.Ok, tickets);
        }
    }
}

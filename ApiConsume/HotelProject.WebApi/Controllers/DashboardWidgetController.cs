﻿using HotelProject.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardWidgetController : ControllerBase
    {
        private readonly IStaffService _staffService;
        private readonly IBookingService _bookingService;
        private readonly IAppUserService _appUserService;
        private readonly IRoomService _roomService;

        public DashboardWidgetController(IStaffService staffService, IBookingService bookingService, IAppUserService appUserService, IRoomService roomService)
        {
            _staffService = staffService;
            _bookingService = bookingService;
            _appUserService = appUserService;
            _roomService = roomService;
        }

        [HttpGet("GetStaffCount")]
        public IActionResult GetStaffCount()
        {
            var value = _staffService.TGetStaffCount();
            return Ok(value);
        }
        [HttpGet("GetBookingCount")]
        public IActionResult GetBookingCount()
        {
            var value = _bookingService.TGetBookingCount();
            return Ok(value);
        }
        [HttpGet("GetAppUserCount")]
        public IActionResult GetAppUserCount()
        {
            var value = _appUserService.TGetUserCount();
            return Ok(value);
        }
        [HttpGet("GetRoomCount")]
        public IActionResult GetRoomCount()
        {
            var value = _roomService.TGetRoomCount();
            return Ok(value);
        }
    }
}

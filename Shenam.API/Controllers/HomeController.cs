﻿//====================================================
//Copyright(c) Coalition of Good-Hearted Engineers
//Free To Use To Find Comfort and Peace
//====================================================

using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Shenam.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController:RESTFulController
    {
        [HttpGet]
        public ActionResult<string> Get() => 
            Ok("Hello Mario, Project working.");
    }
}

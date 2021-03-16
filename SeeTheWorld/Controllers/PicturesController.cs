﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;
using SeeTheWorld.Dto;
using SeeTheWorld.Entities;
using SeeTheWorld.Services;

namespace SeeTheWorld.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PicturesController : ControllerBase
    {
        private ILogger<PicturesController> Logger { get; }
        private IPictureService PictureService { get; }

        private IMapper Mapper { get; }

        public PicturesController(ILogger<PicturesController> logger, IPictureService pictureService, IMapper mapper)
        {
            Logger = logger
                     ?? throw new ArgumentNullException(nameof(logger));
            PictureService = pictureService
                             ?? throw new ArgumentNullException(nameof(pictureService));
            Mapper = mapper
                     ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PictureDto>>> GetPictures([FromQuery] uint? number)
        {
            Logger.LogInformation($"Match method {nameof(GetPictures)}");
            var pictures = 
                await PictureService.GetPictures(number ?? 1);
            return Ok(
                Mapper.Map<IEnumerable<PictureDto>>(pictures)
            );
        }

        public IActionResult PostPicture([FromBody] PictureDto picture)
        {
            Logger.LogInformation($"Match method {nameof(PostPicture)}");
            PictureService.PutPicture(Mapper.Map<PictureEntity>(picture));
            return NoContent();
        }

    }
}

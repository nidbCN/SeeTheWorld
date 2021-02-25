using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SeeTheWorld.Services;
using System;

namespace SeeTheWorld.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PicturesController : ControllerBase
    {
        public ILogger<PicturesController> Logger { get; }
        public IPictureService PictureService { get; }


        public PicturesController(ILogger<PicturesController> logger, IPictureService pictureService)
        {
            Logger = logger
                ?? throw new  ArgumentNullException(nameof(logger));
            PictureService = pictureService
                             ?? throw new ArgumentNullException(nameof(pictureService));
        }

        [HttpGet]
        public IActionResult GetPictures([FromQuery]uint? number)
        {
            return number == null
                ? Ok(PictureService.GetPicture())
                : Ok(PictureService.GetPictures((uint) number));
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SeeTheWorld.Dto;
using SeeTheWorld.Entities;
using SeeTheWorld.Services;
using SLMapper.Interfaces;
using System.Linq;

namespace SeeTheWorld.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class PicturesController : ControllerBase
    {
        /// <summary>
        /// 日志
        /// </summary>
        private readonly ILogger<PicturesController> _logger;

        /// <summary>
        /// 图片服务
        /// </summary>
        private readonly IPictureService _pictureService;

        private readonly IMapper _mapper;

        public PicturesController(
            ILogger<PicturesController> logger,
            IPictureService pictureService,
            IMapper mapper)
        {
            _logger = logger
                     ?? throw new ArgumentNullException(nameof(logger));
            _pictureService = pictureService
                             ?? throw new ArgumentNullException(nameof(pictureService));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PictureDto>>> GetPictures([FromQuery] uint? number)
        {
            _logger.LogInformation($"Match method {nameof(GetPictures)}");
            
            var pictures =
                await _pictureService.GetPictures(number);


            return Ok(
                pictures.Select(x =>
                    _mapper.MapBack<PictureDto, PictureEntity>(x)));
        }

        [HttpPost]
        public IActionResult PostPicture([FromBody] PictureDto picture)
        {
            _logger.LogInformation($"Match method {nameof(PostPicture)}");
            
            _pictureService.PutPicture(
                _mapper.MapTo<PictureDto,PictureEntity>(picture));

            return NoContent();
        }

    }
}
